#if _DYNAMIC_XMLSERIALIZER_COMPILATION
[assembly:System.Security.AllowPartiallyTrustedCallers()]
[assembly:System.Security.SecurityTransparent()]
[assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif
[assembly:System.Reflection.AssemblyVersionAttribute("7.5.8.2022")]
[assembly:System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId=@"03ffc8e4-fc25-428c-9096-b0bbae0f0453,", Version=@"4.0.0.0")]
namespace Microsoft.Xml.Serialization.GeneratedAssembly {

    public class XmlSerializationWriterIcoUniDataExchangeservice : System.Xml.Serialization.XmlSerializationWriter {

        public void Write1_OpenSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"OpenSession", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"A2", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"A3", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write2_OpenSessionInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write3_CloseSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"CloseSession", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write4_CloseSessionInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write5_GetFileList(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"GetFileList", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"A2", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write6_GetFileListInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write7_UploadFile(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"UploadFile", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"A2", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"A3", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementStringRaw(@"A4", @"", FromByteArrayBase64(((global::System.Byte[])p[3])), new System.Xml.XmlQualifiedName(@"base64Binary", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write8_UploadFileInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write9_DownloadFile(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"DownloadFile", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementStringRaw(@"A2", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[1])), new System.Xml.XmlQualifiedName(@"int", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write10_DownloadFileInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write11_UploadFileAndTime(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"UploadFileAndTime", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"A2", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"A3", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementStringRaw(@"A4", @"", FromDateTime(((global::System.DateTime)p[3])), new System.Xml.XmlQualifiedName(@"dateTime", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementStringRaw(@"A5", @"", FromDateTime(((global::System.DateTime)p[4])), new System.Xml.XmlQualifiedName(@"dateTime", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WriteElementStringRaw(@"A6", @"", FromByteArrayBase64(((global::System.Byte[])p[5])), new System.Xml.XmlQualifiedName(@"base64Binary", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write12_UploadFileAndTimeInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write13_GetMaxDate(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"GetMaxDate", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"A2", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write14_GetMaxDateInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        public void Write15_SetDownloaded(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"SetDownloaded", @"urn:coUniDataExchangeIntf-IcoUniDataExchange", null, true);
            if (pLength > 0) {
                WriteElementString(@"A1", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementStringRaw(@"A2", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[1])), new System.Xml.XmlQualifiedName(@"int", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementStringRaw(@"A3", @"", FromDateTime(((global::System.DateTime)p[2])), new System.Xml.XmlQualifiedName(@"dateTime", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write16_SetDownloadedInHeaders(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            if (pLength > 0) {
                for (int i = 0; i < pLength; i++) {
                    if (p[i] != null) {
                        WritePotentiallyReferencingElement(null, null, p[i], p[i].GetType(), true, false);
                    }
                }
            }
            WriteReferencedElements();
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderIcoUniDataExchangeservice : System.Xml.Serialization.XmlSerializationReader {

        public object[] Read1_OpenSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read1_OpenSessionResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[0]);
                        try {
                            p[0] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[0]);
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read1_OpenSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read2_OpenSessionResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read3_CloseSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            p[0] = new global::System.Int32();
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read3_CloseSessionResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id5_int, id4_Item, out fixup.Ids[0]);
                        if (rre != null) {
                            try {
                                p[0] = (global::System.Int32)rre;
                            }
                            catch (System.InvalidCastException) {
                                throw CreateInvalidCastException(typeof(global::System.Int32), rre, null);
                            }
                            Referenced(p[0]);
                        }
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read3_CloseSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read4_CloseSessionResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read5_GetFileListResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read5_GetFileListResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations7 = 0;
            int readerCount7 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[0]);
                        try {
                            p[0] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[0]);
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations7, ref readerCount7);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read5_GetFileListResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read6_GetFileListResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations8, ref readerCount8);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read7_UploadFileResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            p[0] = new global::System.Int32();
            Reader.MoveToContent();
            int whileIterations9 = 0;
            int readerCount9 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read7_UploadFileResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations10 = 0;
            int readerCount10 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id5_int, id4_Item, out fixup.Ids[0]);
                        if (rre != null) {
                            try {
                                p[0] = (global::System.Int32)rre;
                            }
                            catch (System.InvalidCastException) {
                                throw CreateInvalidCastException(typeof(global::System.Int32), rre, null);
                            }
                            Referenced(p[0]);
                        }
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations10, ref readerCount10);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read7_UploadFileResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read8_UploadFileResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read9_DownloadFileResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read9_DownloadFileResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations13 = 0;
            int readerCount13 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id6_base64Binary, id4_Item, out fixup.Ids[0]);
                        try {
                            p[0] = (global::System.Byte[])rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.Byte[]), rre, null);
                        }
                        Referenced(p[0]);
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations13, ref readerCount13);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read9_DownloadFileResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read10_DownloadFileResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations14 = 0;
            int readerCount14 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations14, ref readerCount14);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read11_UploadFileAndTimeResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            p[0] = new global::System.Int32();
            Reader.MoveToContent();
            int whileIterations15 = 0;
            int readerCount15 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations15, ref readerCount15);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read11_UploadFileAndTimeResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations16 = 0;
            int readerCount16 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id5_int, id4_Item, out fixup.Ids[0]);
                        if (rre != null) {
                            try {
                                p[0] = (global::System.Int32)rre;
                            }
                            catch (System.InvalidCastException) {
                                throw CreateInvalidCastException(typeof(global::System.Int32), rre, null);
                            }
                            Referenced(p[0]);
                        }
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations16, ref readerCount16);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read11_UploadFileAndTimeResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read12_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations17 = 0;
            int readerCount17 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations17, ref readerCount17);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read13_GetMaxDateResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            p[0] = new global::System.DateTime();
            Reader.MoveToContent();
            int whileIterations18 = 0;
            int readerCount18 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations18, ref readerCount18);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read13_GetMaxDateResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations19 = 0;
            int readerCount19 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_dateTime, id4_Item, out fixup.Ids[0]);
                        if (rre != null) {
                            try {
                                p[0] = (global::System.DateTime)rre;
                            }
                            catch (System.InvalidCastException) {
                                throw CreateInvalidCastException(typeof(global::System.DateTime), rre, null);
                            }
                            Referenced(p[0]);
                        }
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations19, ref readerCount19);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read13_GetMaxDateResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read14_GetMaxDateResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations20 = 0;
            int readerCount20 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations20, ref readerCount20);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        public object[] Read15_SetDownloadedResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            p[0] = new global::System.Int32();
            Reader.MoveToContent();
            int whileIterations21 = 0;
            int readerCount21 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations21, ref readerCount21);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read15_SetDownloadedResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations22 = 0;
            int readerCount22 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id1_return && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id5_int, id4_Item, out fixup.Ids[0]);
                        if (rre != null) {
                            try {
                                p[0] = (global::System.Int32)rre;
                            }
                            catch (System.InvalidCastException) {
                                throw CreateInvalidCastException(typeof(global::System.Int32), rre, null);
                            }
                            Referenced(p[0]);
                        }
                        IsReturnValue = false;
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations22, ref readerCount22);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read15_SetDownloadedResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read16_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations23 = 0;
            int readerCount23 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/") == "0") {
                        if (Reader.GetAttribute("id", null) != null) { ReadReferencedElement(); } else { UnknownNode((object)p); } continue;
                    }
                    string refElemId = null;
                    object refElem = ReadReferencingElement(null, null, true, out refElemId);
                    if (refElemId != null) {
                        hrefList.Add(refElemId);
                        hrefListIsObject.Add(false);
                    }
                    else if (refElem != null) {
                        hrefList.Add(refElem);
                        hrefListIsObject.Add(true);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations23, ref readerCount23);
            }
            int isObjectIndex = 0;
            foreach (object obj in hrefList) {
                bool isReferenced = true;
                bool isObject = (bool)hrefListIsObject[isObjectIndex++];
                object refObj = isObject ? obj : GetTarget((string)obj);
                if (refObj == null) continue;
                System.Type refObjType = refObj.GetType();
                string refObjId = null;
                isReferenced = false;
                if (isObject && isReferenced) Referenced(refObj); // need to mark this obj as ref'd since we didn't do GetTarget
            }
            ReadReferencedElements();
            return p;
        }

        protected override void InitCallbacks() {
        }

        string id4_Item;
        string id5_int;
        string id3_string;
        string id1_return;
        string id2_Item;
        string id6_base64Binary;
        string id7_dateTime;

        protected override void InitIDs() {
            id4_Item = Reader.NameTable.Add(@"http://www.w3.org/2001/XMLSchema");
            id5_int = Reader.NameTable.Add(@"int");
            id3_string = Reader.NameTable.Add(@"string");
            id1_return = Reader.NameTable.Add(@"return");
            id2_Item = Reader.NameTable.Add(@"");
            id6_base64Binary = Reader.NameTable.Add(@"base64Binary");
            id7_dateTime = Reader.NameTable.Add(@"dateTime");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReaderIcoUniDataExchangeservice();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriterIcoUniDataExchangeservice();
        }
    }

    public sealed class ArrayOfObjectSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"OpenSession", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write1_OpenSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer1 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"OpenSessionResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read1_OpenSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer2 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"OpenSessionInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write2_OpenSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer3 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"OpenSessionResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read2_OpenSessionResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer4 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"CloseSession", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write3_CloseSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer5 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"CloseSessionResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read3_CloseSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer6 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"CloseSessionInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write4_CloseSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer7 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"CloseSessionResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read4_CloseSessionResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer8 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetFileList", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write5_GetFileList((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer9 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetFileListResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read5_GetFileListResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer10 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetFileListInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write6_GetFileListInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer11 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetFileListResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read6_GetFileListResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer12 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFile", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write7_UploadFile((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer13 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read7_UploadFileResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer14 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write8_UploadFileInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer15 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read8_UploadFileResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer16 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DownloadFile", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write9_DownloadFile((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer17 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DownloadFileResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read9_DownloadFileResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer18 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DownloadFileInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write10_DownloadFileInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer19 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DownloadFileResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read10_DownloadFileResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer20 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileAndTime", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write11_UploadFileAndTime((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer21 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileAndTimeResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read11_UploadFileAndTimeResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer22 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileAndTimeInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write12_UploadFileAndTimeInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer23 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"UploadFileAndTimeResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read12_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer24 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetMaxDate", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write13_GetMaxDate((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer25 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetMaxDateResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read13_GetMaxDateResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer26 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetMaxDateInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write14_GetMaxDateInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer27 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"GetMaxDateResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read14_GetMaxDateResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer28 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"SetDownloaded", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write15_SetDownloaded((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer29 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"SetDownloadedResponse", @"urn:coUniDataExchangeIntf-IcoUniDataExchange");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read15_SetDownloadedResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer30 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"SetDownloadedInHeaders", @"http://tempuri.org/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterIcoUniDataExchangeservice)writer).Write16_SetDownloadedInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer31 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"SetDownloadedResponseOutHeaders", @"http://tempuri.org/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderIcoUniDataExchangeservice)reader).Read16_Item();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderIcoUniDataExchangeservice(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterIcoUniDataExchangeservice(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):Response"] = @"Read1_OpenSessionResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):OutHeaders"] = @"Read2_OpenSessionResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):Response"] = @"Read3_CloseSessionResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):OutHeaders"] = @"Read4_CloseSessionResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):Response"] = @"Read5_GetFileListResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):OutHeaders"] = @"Read6_GetFileListResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):Response"] = @"Read7_UploadFileResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):OutHeaders"] = @"Read8_UploadFileResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):Response"] = @"Read9_DownloadFileResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):OutHeaders"] = @"Read10_DownloadFileResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):Response"] = @"Read11_UploadFileAndTimeResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):OutHeaders"] = @"Read12_Item";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):Response"] = @"Read13_GetMaxDateResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):OutHeaders"] = @"Read14_GetMaxDateResponseOutHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):Response"] = @"Read15_SetDownloadedResponse";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):OutHeaders"] = @"Read16_Item";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String)"] = @"Write1_OpenSession";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):InHeaders"] = @"Write2_OpenSessionInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String)"] = @"Write3_CloseSession";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):InHeaders"] = @"Write4_CloseSessionInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String)"] = @"Write5_GetFileList";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):InHeaders"] = @"Write6_GetFileListInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[])"] = @"Write7_UploadFile";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):InHeaders"] = @"Write8_UploadFileInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32)"] = @"Write9_DownloadFile";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):InHeaders"] = @"Write10_DownloadFileInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[])"] = @"Write11_UploadFileAndTime";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):InHeaders"] = @"Write12_UploadFileAndTimeInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String)"] = @"Write13_GetMaxDate";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):InHeaders"] = @"Write14_GetMaxDateInHeaders";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime)"] = @"Write15_SetDownloaded";
                    _tmp[@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):InHeaders"] = @"Write16_SetDownloadedInHeaders";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):OutHeaders", new ArrayOfObjectSerializer15());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String)", new ArrayOfObjectSerializer());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[])", new ArrayOfObjectSerializer12());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):Response", new ArrayOfObjectSerializer17());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer1());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):Response", new ArrayOfObjectSerializer29());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):Response", new ArrayOfObjectSerializer13());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[])", new ArrayOfObjectSerializer20());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):OutHeaders", new ArrayOfObjectSerializer11());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):InHeaders", new ArrayOfObjectSerializer18());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):Response", new ArrayOfObjectSerializer5());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String)", new ArrayOfObjectSerializer24());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):Response", new ArrayOfObjectSerializer21());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String)", new ArrayOfObjectSerializer4());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):InHeaders", new ArrayOfObjectSerializer6());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):Response", new ArrayOfObjectSerializer25());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):InHeaders", new ArrayOfObjectSerializer22());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer2());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):InHeaders", new ArrayOfObjectSerializer10());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String)", new ArrayOfObjectSerializer8());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32)", new ArrayOfObjectSerializer16());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFile(System.String, System.String, System.String, Byte[]):InHeaders", new ArrayOfObjectSerializer14());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String OpenSession(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer3());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime)", new ArrayOfObjectSerializer28());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):InHeaders", new ArrayOfObjectSerializer26());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.String GetFileList(System.String, System.String):Response", new ArrayOfObjectSerializer9());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):InHeaders", new ArrayOfObjectSerializer30());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 SetDownloaded(System.String, Int32, System.DateTime):OutHeaders", new ArrayOfObjectSerializer31());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 CloseSession(System.String):OutHeaders", new ArrayOfObjectSerializer7());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:System.DateTime GetMaxDate(System.String, System.String):OutHeaders", new ArrayOfObjectSerializer27());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Int32 UploadFileAndTime(System.String, System.String, System.String, System.DateTime, System.DateTime, Byte[]):OutHeaders", new ArrayOfObjectSerializer23());
                    _tmp.Add(@"UnigestUp.UnicontUpload.IcoUniDataExchangeservice:Byte[] DownloadFile(System.String, Int32):OutHeaders", new ArrayOfObjectSerializer19());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::UnigestUp.UnicontUpload.IcoUniDataExchangeservice)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            return null;
        }
    }
}
