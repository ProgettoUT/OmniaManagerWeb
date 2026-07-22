#if _DYNAMIC_XMLSERIALIZER_COMPILATION
[assembly:System.Security.AllowPartiallyTrustedCallers()]
[assembly:System.Security.SecurityTransparent()]
[assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif
[assembly:System.Reflection.AssemblyVersionAttribute("7.21.10.2025")]
[assembly:System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId=@"f4d2eb52-8634-4f9b-a290-5a2034dd931a,", Version=@"4.0.0.0")]
namespace Microsoft.Xml.Serialization.GeneratedAssembly {

    public class XmlSerializationWriterVisure : System.Xml.Serialization.XmlSerializationWriter {

        public void Write3_VisuraPra(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"VisuraPra", @"http://utools.auaonline.it/", null, false);
            if (pLength > 0) {
                WriteElementString(@"AgenziaMadre", @"http://utools.auaonline.it/", ((global::System.String)p[0]));
            }
            if (pLength > 1) {
                WriteElementString(@"Utente", @"http://utools.auaonline.it/", ((global::System.String)p[1]));
            }
            if (pLength > 2) {
                WriteElementString(@"Targa", @"http://utools.auaonline.it/", ((global::System.String)p[2]));
            }
            if (pLength > 3) {
                WriteElementStringRaw(@"CodiceSerieTarga", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[3])));
            }
            if (pLength > 4) {
                WriteElementString(@"Token", @"http://utools.auaonline.it/", ((global::System.String)p[4]));
            }
            WriteEndElement();
        }

        public void Write4_VisuraPraInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write5_ElencoVisure(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"ElencoVisure", @"http://utools.auaonline.it/", null, false);
            if (pLength > 0) {
                WriteElementStringRaw(@"Inizio", @"http://utools.auaonline.it/", FromDateTime(((global::System.DateTime)p[0])));
            }
            if (pLength > 1) {
                WriteElementStringRaw(@"Fine", @"http://utools.auaonline.it/", FromDateTime(((global::System.DateTime)p[1])));
            }
            if (pLength > 2) {
                WriteElementString(@"Token", @"http://utools.auaonline.it/", ((global::System.String)p[2]));
            }
            WriteEndElement();
        }

        public void Write6_ElencoVisureInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write7_ReportVisure(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"ReportVisure", @"http://utools.auaonline.it/", null, false);
            if (pLength > 0) {
                WriteElementStringRaw(@"Inizio", @"http://utools.auaonline.it/", FromDateTime(((global::System.DateTime)p[0])));
            }
            if (pLength > 1) {
                WriteElementStringRaw(@"Fine", @"http://utools.auaonline.it/", FromDateTime(((global::System.DateTime)p[1])));
            }
            if (pLength > 2) {
                WriteElementString(@"Token", @"http://utools.auaonline.it/", ((global::System.String)p[2]));
            }
            WriteEndElement();
        }

        public void Write8_ReportVisureInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write9_RegistraLottoAvvisi(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"RegistraLottoAvvisi", @"http://utools.auaonline.it/", null, false);
            if (pLength > 0) {
                WriteElementString(@"Ambiente", @"http://utools.auaonline.it/", ((global::System.String)p[0]));
            }
            if (pLength > 1) {
                WriteElementString(@"CodiceAgenzia", @"http://utools.auaonline.it/", ((global::System.String)p[1]));
            }
            if (pLength > 2) {
                WriteElementString(@"Localita", @"http://utools.auaonline.it/", ((global::System.String)p[2]));
            }
            if (pLength > 3) {
                WriteElementStringRaw(@"MeseAvvisi", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[3])));
            }
            if (pLength > 4) {
                WriteElementStringRaw(@"AnnoAvvisi", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[4])));
            }
            if (pLength > 5) {
                WriteElementString(@"NomeLotto", @"http://utools.auaonline.it/", ((global::System.String)p[5]));
            }
            if (pLength > 6) {
                WriteElementString(@"IdCampagna", @"http://utools.auaonline.it/", ((global::System.String)p[6]));
            }
            if (pLength > 7) {
                WriteElementStringRaw(@"Destinatari", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[7])));
            }
            if (pLength > 8) {
                WriteElementStringRaw(@"Titoli", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[8])));
            }
            if (pLength > 9) {
                WriteElementStringRaw(@"Comunicazioni", @"http://utools.auaonline.it/", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)p[9])));
            }
            if (pLength > 10) {
                WriteElementString(@"Token", @"http://utools.auaonline.it/", ((global::System.String)p[10]));
            }
            WriteEndElement();
        }

        public void Write10_RegistraLottoAvvisiInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderVisure : System.Xml.Serialization.XmlSerializationReader {

        public object[] Read3_VisuraPraResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id1_VisuraPraResponse, id2_httputoolsauaonlineit)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations1 = 0;
                    int readerCount1 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id3_VisuraPraResult && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                                p[0] = Read2_Visura(false, true);
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @"http://utools.auaonline.it/:VisuraPraResult");
                            }
                        }
                        else {
                            UnknownNode((object)p, @"http://utools.auaonline.it/:VisuraPraResult");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations1, ref readerCount1);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://utools.auaonline.it/:VisuraPraResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            return p;
        }

        public object[] Read4_VisuraPraResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            return p;
        }

        public object[] Read5_ElencoVisureResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id4_ElencoVisureResponse, id2_httputoolsauaonlineit)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations4 = 0;
                    int readerCount4 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id5_ElencoVisureResult && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                                p[0] = (global::System.Data.DataSet)ReadSerializable(( System.Xml.Serialization.IXmlSerializable)new global::System.Data.DataSet());
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @"http://utools.auaonline.it/:ElencoVisureResult");
                            }
                        }
                        else {
                            UnknownNode((object)p, @"http://utools.auaonline.it/:ElencoVisureResult");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations4, ref readerCount4);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://utools.auaonline.it/:ElencoVisureResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            return p;
        }

        public object[] Read6_ElencoVisureResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            return p;
        }

        public object[] Read7_ReportVisureResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id6_ReportVisureResponse, id2_httputoolsauaonlineit)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations7 = 0;
                    int readerCount7 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id7_ReportVisureResult && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                                p[0] = (global::System.Data.DataSet)ReadSerializable(( System.Xml.Serialization.IXmlSerializable)new global::System.Data.DataSet());
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @"http://utools.auaonline.it/:ReportVisureResult");
                            }
                        }
                        else {
                            UnknownNode((object)p, @"http://utools.auaonline.it/:ReportVisureResult");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations7, ref readerCount7);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://utools.auaonline.it/:ReportVisureResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            return p;
        }

        public object[] Read8_ReportVisureResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations8, ref readerCount8);
            }
            return p;
        }

        public object[] Read9_RegistraLottoAvvisiResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations9 = 0;
            int readerCount9 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id8_RegistraLottoAvvisiResponse, id2_httputoolsauaonlineit)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations10 = 0;
                    int readerCount10 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id9_RegistraLottoAvvisiResult && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                                {
                                    p[0] = Reader.ReadElementString();
                                }
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @"http://utools.auaonline.it/:RegistraLottoAvvisiResult");
                            }
                        }
                        else {
                            UnknownNode((object)p, @"http://utools.auaonline.it/:RegistraLottoAvvisiResult");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations10, ref readerCount10);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://utools.auaonline.it/:RegistraLottoAvvisiResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            return p;
        }

        public object[] Read10_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            return p;
        }

        global::Visure.VisureOMW.Visura Read2_Visura(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_Visura && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_httputoolsauaonlineit)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Visure.VisureOMW.Visura o;
            o = new global::Visure.VisureOMW.Visura();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id11_CodiceEsito && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                        o.@CodiceEsito = Read1_Object(false, true);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id12_Errore && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                        {
                            o.@Errore = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id13_VisuraRichiesta && (object) Reader.NamespaceURI == (object)id2_httputoolsauaonlineit)) {
                        {
                            o.@VisuraRichiesta = ToByteArrayBase64(false);
                        }
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)o, @"http://utools.auaonline.it/:CodiceEsito, http://utools.auaonline.it/:Errore, http://utools.auaonline.it/:VisuraRichiesta");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://utools.auaonline.it/:CodiceEsito, http://utools.auaonline.it/:Errore, http://utools.auaonline.it/:VisuraRichiesta");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            ReadEndElement();
            return o;
        }

        global::System.Object Read1_Object(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
                if (isNull) {
                    if (xsiType != null) return (global::System.Object)ReadTypedNull(xsiType);
                    else return null;
                }
                if (xsiType == null) {
                    return ReadTypedPrimitive(new System.Xml.XmlQualifiedName("anyType", "http://www.w3.org/2001/XMLSchema"));
                }
                else if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_Visura && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_httputoolsauaonlineit))
                    return Read2_Visura(isNullable, false);
                else
                    return ReadTypedPrimitive((System.Xml.XmlQualifiedName)xsiType);
                }
                if (isNull) return null;
                global::System.Object o;
                o = new global::System.Object();
                bool[] paramsRead = new bool[0];
                while (Reader.MoveToNextAttribute()) {
                    if (!IsXmlnsAttribute(Reader.Name)) {
                        UnknownNode((object)o);
                    }
                }
                Reader.MoveToElement();
                if (Reader.IsEmptyElement) {
                    Reader.Skip();
                    return o;
                }
                Reader.ReadStartElement();
                Reader.MoveToContent();
                int whileIterations13 = 0;
                int readerCount13 = ReaderCount;
                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                        UnknownNode((object)o, @"");
                    }
                    else {
                        UnknownNode((object)o, @"");
                    }
                    Reader.MoveToContent();
                    CheckReaderCount(ref whileIterations13, ref readerCount13);
                }
                ReadEndElement();
                return o;
            }

            protected override void InitCallbacks() {
            }

            string id8_RegistraLottoAvvisiResponse;
            string id5_ElencoVisureResult;
            string id7_ReportVisureResult;
            string id3_VisuraPraResult;
            string id13_VisuraRichiesta;
            string id9_RegistraLottoAvvisiResult;
            string id6_ReportVisureResponse;
            string id10_Visura;
            string id2_httputoolsauaonlineit;
            string id1_VisuraPraResponse;
            string id4_ElencoVisureResponse;
            string id12_Errore;
            string id11_CodiceEsito;

            protected override void InitIDs() {
                id8_RegistraLottoAvvisiResponse = Reader.NameTable.Add(@"RegistraLottoAvvisiResponse");
                id5_ElencoVisureResult = Reader.NameTable.Add(@"ElencoVisureResult");
                id7_ReportVisureResult = Reader.NameTable.Add(@"ReportVisureResult");
                id3_VisuraPraResult = Reader.NameTable.Add(@"VisuraPraResult");
                id13_VisuraRichiesta = Reader.NameTable.Add(@"VisuraRichiesta");
                id9_RegistraLottoAvvisiResult = Reader.NameTable.Add(@"RegistraLottoAvvisiResult");
                id6_ReportVisureResponse = Reader.NameTable.Add(@"ReportVisureResponse");
                id10_Visura = Reader.NameTable.Add(@"Visura");
                id2_httputoolsauaonlineit = Reader.NameTable.Add(@"http://utools.auaonline.it/");
                id1_VisuraPraResponse = Reader.NameTable.Add(@"VisuraPraResponse");
                id4_ElencoVisureResponse = Reader.NameTable.Add(@"ElencoVisureResponse");
                id12_Errore = Reader.NameTable.Add(@"Errore");
                id11_CodiceEsito = Reader.NameTable.Add(@"CodiceEsito");
            }
        }

        public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
            protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
                return new XmlSerializationReaderVisure();
            }
            protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
                return new XmlSerializationWriterVisure();
            }
        }

        public sealed class ArrayOfObjectSerializer : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"VisuraPra", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write3_VisuraPra((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer1 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"VisuraPraResponse", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read3_VisuraPraResponse();
            }
        }

        public sealed class ArrayOfObjectSerializer2 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"VisuraPraInHeaders", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write4_VisuraPraInHeaders((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer3 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"VisuraPraResponseOutHeaders", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read4_VisuraPraResponseOutHeaders();
            }
        }

        public sealed class ArrayOfObjectSerializer4 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ElencoVisure", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write5_ElencoVisure((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer5 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ElencoVisureResponse", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read5_ElencoVisureResponse();
            }
        }

        public sealed class ArrayOfObjectSerializer6 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ElencoVisureInHeaders", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write6_ElencoVisureInHeaders((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer7 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ElencoVisureResponseOutHeaders", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read6_ElencoVisureResponseOutHeaders();
            }
        }

        public sealed class ArrayOfObjectSerializer8 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ReportVisure", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write7_ReportVisure((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer9 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ReportVisureResponse", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read7_ReportVisureResponse();
            }
        }

        public sealed class ArrayOfObjectSerializer10 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ReportVisureInHeaders", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write8_ReportVisureInHeaders((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer11 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ReportVisureResponseOutHeaders", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read8_ReportVisureResponseOutHeaders();
            }
        }

        public sealed class ArrayOfObjectSerializer12 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"RegistraLottoAvvisi", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write9_RegistraLottoAvvisi((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer13 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"RegistraLottoAvvisiResponse", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read9_RegistraLottoAvvisiResponse();
            }
        }

        public sealed class ArrayOfObjectSerializer14 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"RegistraLottoAvvisiInHeaders", @"http://utools.auaonline.it/");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriterVisure)writer).Write10_RegistraLottoAvvisiInHeaders((object[])objectToSerialize);
            }
        }

        public sealed class ArrayOfObjectSerializer15 : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"RegistraLottoAvvisiResponseOutHeaders", @"http://utools.auaonline.it/");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReaderVisure)reader).Read10_Item();
            }
        }

        public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
            public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderVisure(); } }
            public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterVisure(); } }
            System.Collections.Hashtable readMethods = null;
            public override System.Collections.Hashtable ReadMethods {
                get {
                    if (readMethods == null) {
                        System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                        _tmp[@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):Response"] = @"Read3_VisuraPraResponse";
                        _tmp[@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):OutHeaders"] = @"Read4_VisuraPraResponseOutHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):Response"] = @"Read5_ElencoVisureResponse";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):OutHeaders"] = @"Read6_ElencoVisureResponseOutHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):Response"] = @"Read7_ReportVisureResponse";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):OutHeaders"] = @"Read8_ReportVisureResponseOutHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):Response"] = @"Read9_RegistraLottoAvvisiResponse";
                        _tmp[@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):OutHeaders"] = @"Read10_Item";
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
                        _tmp[@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String)"] = @"Write3_VisuraPra";
                        _tmp[@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):InHeaders"] = @"Write4_VisuraPraInHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String)"] = @"Write5_ElencoVisure";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):InHeaders"] = @"Write6_ElencoVisureInHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String)"] = @"Write7_ReportVisure";
                        _tmp[@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):InHeaders"] = @"Write8_ReportVisureInHeaders";
                        _tmp[@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String)"] = @"Write9_RegistraLottoAvvisi";
                        _tmp[@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):InHeaders"] = @"Write10_RegistraLottoAvvisiInHeaders";
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
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String)", new ArrayOfObjectSerializer4());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):OutHeaders", new ArrayOfObjectSerializer15());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):Response", new ArrayOfObjectSerializer5());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):InHeaders", new ArrayOfObjectSerializer6());
                        _tmp.Add(@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):OutHeaders", new ArrayOfObjectSerializer3());
                        _tmp.Add(@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String)", new ArrayOfObjectSerializer());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):Response", new ArrayOfObjectSerializer13());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):InHeaders", new ArrayOfObjectSerializer10());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String)", new ArrayOfObjectSerializer12());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):OutHeaders", new ArrayOfObjectSerializer11());
                        _tmp.Add(@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):Response", new ArrayOfObjectSerializer1());
                        _tmp.Add(@"Visure.VisureOMW.Visure:Visure.VisureOMW.Visura VisuraPra(System.String, System.String, System.String, Int32, System.String):InHeaders", new ArrayOfObjectSerializer2());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.String RegistraLottoAvvisi(System.String, System.String, System.String, Int32, Int32, System.String, System.String, Int32, Int32, Int32, System.String):InHeaders", new ArrayOfObjectSerializer14());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String):Response", new ArrayOfObjectSerializer9());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ReportVisure(System.DateTime, System.DateTime, System.String)", new ArrayOfObjectSerializer8());
                        _tmp.Add(@"Visure.VisureOMW.Visure:System.Data.DataSet ElencoVisure(System.DateTime, System.DateTime, System.String):OutHeaders", new ArrayOfObjectSerializer7());
                        if (typedSerializers == null) typedSerializers = _tmp;
                    }
                    return typedSerializers;
                }
            }
            public override System.Boolean CanSerialize(System.Type type) {
                if (type == typeof(global::Visure.VisureOMW.Visure)) return true;
                return false;
            }
            public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
                return null;
            }
        }
    }
