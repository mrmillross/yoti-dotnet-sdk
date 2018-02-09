﻿using System;
using System.Configuration;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Example.Models;
using Yoti.Auth;

namespace Example.Controllers
{
    public class AccountController : Controller
    {
        public static byte[] PhotoBytes { get; set; }

        public ActionResult LogIn()
        {
            ViewBag.YotiAppId = ConfigurationManager.AppSettings["Yoti.AppId"];
            return View();
        }

        // GET: Account/Connect?token
        public ActionResult Connect(string token)
        {
            try
            {
                string sdkId = ConfigurationManager.AppSettings["Yoti.SdkId"];
                var privateKeyStream = System.IO.File.OpenText(Server.MapPath("~/application-key.pem"));
                var yotiClient = new YotiClient(sdkId, privateKeyStream);

                var activityDetails = yotiClient.GetActivityDetails(token);
                if (activityDetails.Outcome == ActivityOutcome.Success)
                {
                    var yotiProfile = activityDetails.UserProfile;

                    User user = UserManager.GetUserByYotiId(yotiProfile.Id);

                    if (user == null)
                    {
                        user = new User
                        {
                            YotiId = yotiProfile.Id
                        };
                    }

                    if (yotiProfile.Selfie != null)
                    {
                        user.Base64Photo = yotiProfile.Selfie.Base64URI;
                        user.Photo = yotiProfile.Selfie.Data;
                        PhotoBytes = user.Photo;
                    }
                    else
                    {
                        ViewBag.Message = "No photo provided, change the application settings to request a photo from the user for this demo";
                    }

                    UpdateAttributesIfPresent(yotiProfile, user);

                    //This key uses the  format: age_[over|under]:[1-999] and is dynamically
                    //generated based on the dashboard attribute Age / Verify Condition
                    user.IsAgeVerified = yotiProfile.OtherAttributes["age_over:18"].ToString();

                    UserManager.SaveUser(user);

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        },
                        "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);

                    return View(user);
                }
                else
                {
                    return RedirectToAction("LoginFailure");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
                return View();
            }
        }

        private static void UpdateAttributesIfPresent(YotiUserProfile yotiProfile, User user)
        {
            Type userType = user.GetType();
            foreach (PropertyInfo yotiProfileProperty in yotiProfile.GetType().GetProperties())
            {
                if (!yotiProfileProperty.CanRead || (yotiProfileProperty.GetIndexParameters().Length > 0))
                    continue;

                PropertyInfo userProperty = userType.GetProperty(yotiProfileProperty.Name);
                if ((userProperty != null) && (userProperty.CanWrite) && yotiProfileProperty.Name != "Id")
                    userProperty.SetValue(user, yotiProfileProperty.GetValue(yotiProfile, null), null);
            }
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            ViewBag.YotiAppId = ConfigurationManager.AppSettings["Yoti.AppId"];
            return View();
        }

        public ActionResult LoginFailure()
        {
            ViewBag.YotiAppId = ConfigurationManager.AppSettings["Yoti.AppId"];
            return View();
        }

        public FileContentResult DownloadImageFile()
        {
            if (PhotoBytes == null)
                throw new InvalidOperationException("The 'PhotoBytes' variable has not been set");

            return File(PhotoBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "YotiSelfie.jpg");
        }
    }
}