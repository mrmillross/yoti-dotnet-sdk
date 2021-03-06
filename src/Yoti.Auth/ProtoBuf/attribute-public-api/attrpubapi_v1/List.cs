// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: List.proto
#pragma warning disable 1591, 0612, 3021

#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;

namespace AttrpubapiV1
{
    /// <summary>Holder for reflection information generated from List.proto</summary>
    public static partial class ListReflection
    {
        #region Descriptor

        /// <summary>File descriptor for List.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }

        private static pbr::FileDescriptor descriptor;

        static ListReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "CgpMaXN0LnByb3RvEg1hdHRycHViYXBpX3YxGg9BdHRyaWJ1dGUucHJvdG8i",
                  "UwoOQXR0cmlidXRlQW5kSWQSKwoJYXR0cmlidXRlGAEgASgLMhguYXR0cnB1",
                  "YmFwaV92MS5BdHRyaWJ1dGUSFAoMYXR0cmlidXRlX2lkGAIgASgMIlIKEkF0",
                  "dHJpYnV0ZUFuZElkTGlzdBI8ChVhdHRyaWJ1dGVfYW5kX2lkX2xpc3QYASAD",
                  "KAsyHS5hdHRycHViYXBpX3YxLkF0dHJpYnV0ZUFuZElkIj0KDUF0dHJpYnV0",
                  "ZUxpc3QSLAoKYXR0cmlidXRlcxgBIAMoCzIYLmF0dHJwdWJhcGlfdjEuQXR0",
                  "cmlidXRlQiMKFmNvbS55b3RpLmF0dHJwdWJhcGlfdjFCCUF0dHJQcm90b2IG",
                  "cHJvdG8z"));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { global::AttrpubapiV1.AttributeReflection.Descriptor, },
                new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AttrpubapiV1.AttributeAndId), global::AttrpubapiV1.AttributeAndId.Parser, new[]{ "Attribute", "AttributeId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AttrpubapiV1.AttributeAndIdList), global::AttrpubapiV1.AttributeAndIdList.Parser, new[]{ "AttributeAndIdList_" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AttrpubapiV1.AttributeList), global::AttrpubapiV1.AttributeList.Parser, new[]{ "Attributes" }, null, null, null)
                }));
        }

        #endregion Descriptor
    }

    #region Messages

    /// <summary>
    ///  AttributeAndId is a simple container for holding an attribute's value
    ///  alongside its ID.
    /// </summary>
    public sealed partial class AttributeAndId : pb::IMessage<AttributeAndId>
    {
        private static readonly pb::MessageParser<AttributeAndId> _parser = new pb::MessageParser<AttributeAndId>(() => new AttributeAndId());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<AttributeAndId> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::AttrpubapiV1.ListReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndId()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndId(AttributeAndId other) : this()
        {
            Attribute = other.attribute_ != null ? other.Attribute.Clone() : null;
            attributeId_ = other.attributeId_;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndId Clone()
        {
            return new AttributeAndId(this);
        }

        /// <summary>Field number for the "attribute" field.</summary>
        public const int AttributeFieldNumber = 1;

        private global::AttrpubapiV1.Attribute attribute_;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::AttrpubapiV1.Attribute Attribute
        {
            get { return attribute_; }
            set
            {
                attribute_ = value;
            }
        }

        /// <summary>Field number for the "attribute_id" field.</summary>
        public const int AttributeIdFieldNumber = 2;

        private pb::ByteString attributeId_ = pb::ByteString.Empty;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pb::ByteString AttributeId
        {
            get { return attributeId_; }
            set
            {
                attributeId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as AttributeAndId);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(AttributeAndId other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!object.Equals(Attribute, other.Attribute)) return false;
            if (AttributeId != other.AttributeId) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (attribute_ != null) hash ^= Attribute.GetHashCode();
            if (AttributeId.Length != 0) hash ^= AttributeId.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (attribute_ != null)
            {
                output.WriteRawTag(10);
                output.WriteMessage(Attribute);
            }
            if (AttributeId.Length != 0)
            {
                output.WriteRawTag(18);
                output.WriteBytes(AttributeId);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (attribute_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(Attribute);
            }
            if (AttributeId.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(AttributeId);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(AttributeAndId other)
        {
            if (other == null)
            {
                return;
            }
            if (other.attribute_ != null)
            {
                if (attribute_ == null)
                {
                    attribute_ = new global::AttrpubapiV1.Attribute();
                }
                Attribute.MergeFrom(other.Attribute);
            }
            if (other.AttributeId.Length != 0)
            {
                AttributeId = other.AttributeId;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;

                    case 10:
                        {
                            if (attribute_ == null)
                            {
                                attribute_ = new global::AttrpubapiV1.Attribute();
                            }
                            input.ReadMessage(attribute_);
                            break;
                        }
                    case 18:
                        {
                            AttributeId = input.ReadBytes();
                            break;
                        }
                }
            }
        }
    }

    public sealed partial class AttributeAndIdList : pb::IMessage<AttributeAndIdList>
    {
        private static readonly pb::MessageParser<AttributeAndIdList> _parser = new pb::MessageParser<AttributeAndIdList>(() => new AttributeAndIdList());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<AttributeAndIdList> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::AttrpubapiV1.ListReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndIdList()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndIdList(AttributeAndIdList other) : this()
        {
            attributeAndIdList_ = other.attributeAndIdList_.Clone();
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeAndIdList Clone()
        {
            return new AttributeAndIdList(this);
        }

        /// <summary>Field number for the "attribute_and_id_list" field.</summary>
        public const int AttributeAndIdList_FieldNumber = 1;

        private static readonly pb::FieldCodec<global::AttrpubapiV1.AttributeAndId> _repeated_attributeAndIdList_codec
            = pb::FieldCodec.ForMessage(10, global::AttrpubapiV1.AttributeAndId.Parser);

        private readonly pbc::RepeatedField<global::AttrpubapiV1.AttributeAndId> attributeAndIdList_ = new pbc::RepeatedField<global::AttrpubapiV1.AttributeAndId>();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::AttrpubapiV1.AttributeAndId> AttributeAndIdList_
        {
            get { return attributeAndIdList_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as AttributeAndIdList);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(AttributeAndIdList other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!attributeAndIdList_.Equals(other.attributeAndIdList_)) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            hash ^= attributeAndIdList_.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            attributeAndIdList_.WriteTo(output, _repeated_attributeAndIdList_codec);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            size += attributeAndIdList_.CalculateSize(_repeated_attributeAndIdList_codec);
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(AttributeAndIdList other)
        {
            if (other == null)
            {
                return;
            }
            attributeAndIdList_.Add(other.attributeAndIdList_);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;

                    case 10:
                        {
                            attributeAndIdList_.AddEntriesFrom(input, _repeated_attributeAndIdList_codec);
                            break;
                        }
                }
            }
        }
    }

    public sealed partial class AttributeList : pb::IMessage<AttributeList>
    {
        private static readonly pb::MessageParser<AttributeList> _parser = new pb::MessageParser<AttributeList>(() => new AttributeList());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<AttributeList> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::AttrpubapiV1.ListReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeList()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeList(AttributeList other) : this()
        {
            attributes_ = other.attributes_.Clone();
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public AttributeList Clone()
        {
            return new AttributeList(this);
        }

        /// <summary>Field number for the "attributes" field.</summary>
        public const int AttributesFieldNumber = 1;

        private static readonly pb::FieldCodec<global::AttrpubapiV1.Attribute> _repeated_attributes_codec
            = pb::FieldCodec.ForMessage(10, global::AttrpubapiV1.Attribute.Parser);

        private readonly pbc::RepeatedField<global::AttrpubapiV1.Attribute> attributes_ = new pbc::RepeatedField<global::AttrpubapiV1.Attribute>();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::AttrpubapiV1.Attribute> Attributes
        {
            get { return attributes_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as AttributeList);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(AttributeList other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!attributes_.Equals(other.attributes_)) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            hash ^= attributes_.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            attributes_.WriteTo(output, _repeated_attributes_codec);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            size += attributes_.CalculateSize(_repeated_attributes_codec);
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(AttributeList other)
        {
            if (other == null)
            {
                return;
            }
            attributes_.Add(other.attributes_);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;

                    case 10:
                        {
                            attributes_.AddEntriesFrom(input, _repeated_attributes_codec);
                            break;
                        }
                }
            }
        }
    }

    #endregion Messages
}

#endregion Designer generated code