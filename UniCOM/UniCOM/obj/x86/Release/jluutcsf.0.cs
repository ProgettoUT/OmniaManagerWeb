#if _DYNAMIC_XMLSERIALIZER_COMPILATION
[assembly:System.Security.AllowPartiallyTrustedCallers()]
[assembly:System.Security.SecurityTransparent()]
[assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif
[assembly:System.Reflection.AssemblyVersionAttribute("7.6.9.2022")]
[assembly:System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId=@"a9a4e7e3-900f-4791-a151-392cbfa3ede0,", Version=@"4.0.0.0")]
namespace Microsoft.Xml.Serialization.GeneratedAssembly {

    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        void Write10_smsNUMBER(object s) {
            global::UniCom.Netfun.smsNUMBER o = (global::UniCom.Netfun.smsNUMBER)s;
            WriteNullableStringEncoded(@"number", @"", ((global::System.String)o.@number), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"tokens", @"", ((global::System.String)o.@tokens), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"id", @"", ((global::System.String)o.@id), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
        }

        void Write12_subaccountINFO(object s) {
            global::UniCom.Netfun.subaccountINFO o = (global::UniCom.Netfun.subaccountINFO)s;
            WriteNullableStringEncoded(@"username", @"", ((global::System.String)o.@username), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"email", @"", ((global::System.String)o.@email), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"password", @"", ((global::System.String)o.@password), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"name", @"", ((global::System.String)o.@name), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"lastname", @"", ((global::System.String)o.@lastname), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"tel", @"", ((global::System.String)o.@tel), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"cel", @"", ((global::System.String)o.@cel), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"fax", @"", ((global::System.String)o.@fax), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"address", @"", ((global::System.String)o.@address), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"city", @"", ((global::System.String)o.@city), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"cap", @"", ((global::System.String)o.@cap), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"province", @"", ((global::System.String)o.@province), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"notes", @"", ((global::System.String)o.@notes), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
        }

        void Write13_subaccountUpdateINFO(object s) {
            global::UniCom.Netfun.subaccountUpdateINFO o = (global::UniCom.Netfun.subaccountUpdateINFO)s;
            WriteNullableStringEncoded(@"username", @"", ((global::System.String)o.@username), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"email", @"", ((global::System.String)o.@email), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"password", @"", ((global::System.String)o.@password), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"name", @"", ((global::System.String)o.@name), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"lastname", @"", ((global::System.String)o.@lastname), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"tel", @"", ((global::System.String)o.@tel), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"cel", @"", ((global::System.String)o.@cel), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"fax", @"", ((global::System.String)o.@fax), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"address", @"", ((global::System.String)o.@address), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"city", @"", ((global::System.String)o.@city), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"cap", @"", ((global::System.String)o.@cap), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"province", @"", ((global::System.String)o.@province), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"notes", @"", ((global::System.String)o.@notes), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            if (o.@statusSpecified) {
                if (o.@status != null) {
                    WriteNullableStringEncodedRaw(@"status", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@status)), new System.Xml.XmlQualifiedName(@"boolean", @"http://www.w3.org/2001/XMLSchema"));
                }
                else {
                    WriteNullTagLiteral(@"status", @"");
                }
            }
        }

        void Write14_smsOPTIONS(object s) {
            global::UniCom.Netfun.smsOPTIONS o = (global::UniCom.Netfun.smsOPTIONS)s;
            WriteNullableStringEncoded(@"gateway", @"", ((global::System.String)o.@gateway), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"date", @"", ((global::System.String)o.@date), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"charset", @"", ((global::System.String)o.@charset), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"wappush", @"", ((global::System.String)o.@wappush), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
        }

        void Write15_smsDELIVERYFILTERS(object s) {
            global::UniCom.Netfun.smsDELIVERYFILTERS o = (global::UniCom.Netfun.smsDELIVERYFILTERS)s;
            WriteNullableStringEncoded(@"status", @"", ((global::System.String)o.@status), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"details", @"", ((global::System.String)o.@details), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            WriteNullableStringEncoded(@"receivers", @"", ((global::System.String)o.@receivers), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
        }

        public void Write16_getCreditSubaccountAsTotSms(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getCreditSubaccountAsTotSms", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"subaccountName", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"number", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"gateway", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WriteElementString(@"wapPush", @"", ((global::System.String)p[5]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 6) {
                WriteElementString(@"delivery", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 7) {
                WriteElementString(@"sms", @"", ((global::System.String)p[7]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write17_Item(object[] p) {
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

        public void Write18_addTransactionSubaccount(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"addTransactionSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"subaccountName", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"transactionValue", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"costSMS", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WriteElementString(@"transactionDescr", @"", ((global::System.String)p[5]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 6) {
                WriteElementString(@"newCredit", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write19_Item(object[] p) {
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

        public void Write20_addSubaccount(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"addSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WritePotentiallyReferencingElement(@"subaccountInfo", @"", ((global::UniCom.Netfun.subaccountINFO)p[2]), null, false, false);
            }
            if (pLength > 3) {
                WriteElementString(@"id", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write21_addSubaccountInHeaders(object[] p) {
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

        public void Write22_updateSubaccount(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"updateSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"subaccountName", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WritePotentiallyReferencingElement(@"subaccountInfo", @"", ((global::UniCom.Netfun.subaccountUpdateINFO)p[3]), null, false, false);
            }
            if (pLength > 4) {
                WriteElementString(@"id", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write23_updateSubaccountInHeaders(object[] p) {
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

        public void Write24_deleteSubaccount(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"deleteSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"subaccountName", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"id", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write25_deleteSubaccountInHeaders(object[] p) {
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

        public void Write26_createSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"createSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"expirySeconds", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"deleteOtherSessions", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"sessionKey", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write27_createSessionInHeaders(object[] p) {
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

        public void Write28_aliveSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"aliveSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"sessionKey", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"expirySeconds", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"expiryTimestamp", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write29_aliveSessionInHeaders(object[] p) {
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

        public void Write30_isValidSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"isValidSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"sessionKey", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write31_isValidSessionInHeaders(object[] p) {
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

        public void Write32_deleteSession(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"deleteSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"sessionKey", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write33_deleteSessionInHeaders(object[] p) {
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

        public void Write34_deleteAllSessionUser(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"deleteAllSessionUser", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write35_deleteAllSessionUserInHeaders(object[] p) {
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

        public void Write36_getErrorDescr(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getErrorDescr", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"errorCode", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write37_getErrorDescrInHeaders(object[] p) {
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

        public void Write38_sendSmsSimple(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"sendSmsSimple", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"numbers", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"text", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"sender", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WriteElementString(@"gateway", @"", ((global::System.String)p[5]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 6) {
                WriteElementString(@"sendingID", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write39_sendSmsSimpleInHeaders(object[] p) {
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

        public void Write40_sendSmsAdvanced(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"sendSmsAdvanced", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WritePotentiallyReferencingElement(@"numbers", @"", ((global::UniCom.Netfun.smsNUMBER[])p[2]), null, false, false);
            }
            if (pLength > 3) {
                WriteElementString(@"text", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"sender", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WritePotentiallyReferencingElement(@"options", @"", ((global::UniCom.Netfun.smsOPTIONS)p[5]), null, false, false);
            }
            if (pLength > 6) {
                WriteElementString(@"sendingID", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write41_sendSmsAdvancedInHeaders(object[] p) {
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

        public void Write42_getDelivery(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getDelivery", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"sendingID", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"responseType", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WritePotentiallyReferencingElement(@"filters", @"", ((global::UniCom.Netfun.smsDELIVERYFILTERS)p[4]), null, false, false);
            }
            if (pLength > 5) {
                WriteElementString(@"list", @"", ((global::System.String)p[5]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 6) {
                WriteElementString(@"format", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write43_getDeliveryInHeaders(object[] p) {
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

        public void Write44_getCredit(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getCredit", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"credit", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write45_getCreditInHeaders(object[] p) {
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

        public void Write46_getCreditAsTotSms(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getCreditAsTotSms", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"number", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"gateway", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 4) {
                WriteElementString(@"wapPush", @"", ((global::System.String)p[4]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 5) {
                WriteElementString(@"delivery", @"", ((global::System.String)p[5]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 6) {
                WriteElementString(@"sms", @"", ((global::System.String)p[6]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write47_getCreditAsTotSmsInHeaders(object[] p) {
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

        public void Write48_getCreditSubaccount(object[] p) {
            WriteStartDocument();
            int pLength = p.Length;
            WriteStartElement(@"getCreditSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", null, true);
            if (pLength > 0) {
                WriteElementString(@"username", @"", ((global::System.String)p[0]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 1) {
                WriteElementString(@"password", @"", ((global::System.String)p[1]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 2) {
                WriteElementString(@"subaccountName", @"", ((global::System.String)p[2]), new System.Xml.XmlQualifiedName(@"string", @"http://www.w3.org/2001/XMLSchema"));
            }
            if (pLength > 3) {
                WriteElementString(@"credit", @"", ((global::System.String)p[3]), new System.Xml.XmlQualifiedName(@"integer", @"http://www.w3.org/2001/XMLSchema"));
            }
            WriteEndElement();
            WriteReferencedElements();
        }

        public void Write49_getCreditSubaccountInHeaders(object[] p) {
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

        public void Write50_Newlot(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"Newlot", @"http://webservice.koine.org", null, false);
            if (pLength > 0) {
                Write5_Identity(@"Identity", @"", ((global::UniCom.SiComunica.Identity)p[0]), true, false);
            }
            if (pLength > 1) {
                WriteNullableStringLiteral(@"JobCode", @"", ((global::System.String)p[1]));
            }
            if (pLength > 2) {
                WriteNullableStringLiteral(@"LotName", @"", ((global::System.String)p[2]));
            }
            if (pLength > 3) {
                WriteNullableStringLiteral(@"PostService", @"", ((global::System.String)p[3]));
            }
            if (pLength > 4) {
                WriteNullableStringLiteral(@"FileName", @"", ((global::System.String)p[4]));
            }
            if (pLength > 5) {
                WriteNullableStringLiteralRaw(@"FileContent", @"", FromByteArrayBase64(((global::System.Byte[])p[5])));
            }
            if (pLength > 6) {
                WriteNullableStringLiteral(@"FileMD5", @"", ((global::System.String)p[6]));
            }
            WriteEndElement();
        }

        public void Write51_NewlotInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write52_ConfigUni(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"ConfigUni", @"http://webservice.koine.org", null, false);
            if (pLength > 0) {
                Write5_Identity(@"Identity", @"", ((global::UniCom.SiComunica.Identity)p[0]), true, false);
            }
            WriteEndElement();
        }

        public void Write53_ConfigUniInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write54_Tracking(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            WriteStartElement(@"Tracking", @"http://webservice.koine.org", null, false);
            if (pLength > 0) {
                Write5_Identity(@"Identity", @"", ((global::UniCom.SiComunica.Identity)p[0]), true, false);
            }
            if (pLength > 1) {
                WriteNullableStringLiteral(@"Navigation", @"", ((global::System.String)p[1]));
            }
            WriteEndElement();
        }

        public void Write55_TrackingInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        void Write5_Identity(string n, string ns, global::UniCom.SiComunica.Identity o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::UniCom.SiComunica.Identity)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Identity", @"http://beans.webservice.koine.org/xsd");
            WriteNullableStringLiteral(@"clientSystem", @"", ((global::System.String)o.@clientSystem));
            Write4_User(@"user", @"", ((global::UniCom.SiComunica.User)o.@user), true, false);
            WriteEndElement(o);
        }

        void Write4_User(string n, string ns, global::UniCom.SiComunica.User o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::UniCom.SiComunica.User)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"User", @"http://beans.webservice.koine.org/xsd");
            Write2_UserData(@"userData", @"", ((global::UniCom.SiComunica.UserData)o.@userData), true, false);
            Write3_UserKeys(@"userKeys", @"", ((global::UniCom.SiComunica.UserKeys)o.@userKeys), true, false);
            WriteEndElement(o);
        }

        void Write3_UserKeys(string n, string ns, global::UniCom.SiComunica.UserKeys o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::UniCom.SiComunica.UserKeys)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"UserKeys", @"http://beans.webservice.koine.org/xsd");
            WriteNullableStringLiteral(@"clientUserId", @"", ((global::System.String)o.@clientUserId));
            WriteNullableStringLiteral(@"role", @"", ((global::System.String)o.@role));
            WriteNullableStringLiteral(@"roleTimestamp", @"", ((global::System.String)o.@roleTimestamp));
            WriteNullableStringLiteral(@"userFilter", @"", ((global::System.String)o.@userFilter));
            WriteEndElement(o);
        }

        void Write2_UserData(string n, string ns, global::UniCom.SiComunica.UserData o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::UniCom.SiComunica.UserData)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"UserData", @"http://beans.webservice.koine.org/xsd");
            WriteNullableStringLiteral(@"address", @"", ((global::System.String)o.@address));
            WriteNullableStringLiteral(@"cell", @"", ((global::System.String)o.@cell));
            WriteNullableStringLiteral(@"city", @"", ((global::System.String)o.@city));
            WriteNullableStringLiteral(@"country", @"", ((global::System.String)o.@country));
            WriteNullableStringLiteral(@"email", @"", ((global::System.String)o.@email));
            WriteNullableStringLiteral(@"firstName", @"", ((global::System.String)o.@firstName));
            WriteNullableStringLiteral(@"lastName", @"", ((global::System.String)o.@lastName));
            WriteNullableStringLiteral(@"phone", @"", ((global::System.String)o.@phone));
            WriteNullableStringLiteral(@"provinceState", @"", ((global::System.String)o.@provinceState));
            WriteNullableStringLiteral(@"zip", @"", ((global::System.String)o.@zip));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
            AddWriteCallback(typeof(global::UniCom.Netfun.smsNUMBER), @"smsNUMBER", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", new System.Xml.Serialization.XmlSerializationWriteCallback(this.Write10_smsNUMBER));
            AddWriteCallback(typeof(global::UniCom.Netfun.subaccountINFO), @"subaccountINFO", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", new System.Xml.Serialization.XmlSerializationWriteCallback(this.Write12_subaccountINFO));
            AddWriteCallback(typeof(global::UniCom.Netfun.subaccountUpdateINFO), @"subaccountUpdateINFO", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", new System.Xml.Serialization.XmlSerializationWriteCallback(this.Write13_subaccountUpdateINFO));
            AddWriteCallback(typeof(global::UniCom.Netfun.smsOPTIONS), @"smsOPTIONS", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", new System.Xml.Serialization.XmlSerializationWriteCallback(this.Write14_smsOPTIONS));
            AddWriteCallback(typeof(global::UniCom.Netfun.smsDELIVERYFILTERS), @"smsDELIVERYFILTERS", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/", new System.Xml.Serialization.XmlSerializationWriteCallback(this.Write15_smsDELIVERYFILTERS));
        }
    }

    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        object Read10_smsNUMBER() {
            global::UniCom.Netfun.smsNUMBER o;
            o = new global::UniCom.Netfun.smsNUMBER();
            Fixup fixup = new Fixup(o, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read10_smsNUMBER), 3);
            AddFixup(fixup);
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) { Reader.Skip(); return o; }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id1_number && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[0]);
                        try {
                            o.@number = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@number);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id5_tokens && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            o.@tokens = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@tokens);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id6_id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[2]);
                        try {
                            o.@id = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@id);
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)o);
                    }
                }
                else {
                    UnknownNode((object)o);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            ReadEndElement();
            return o;
        }

        void fixup_Read10_smsNUMBER(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            global::UniCom.Netfun.smsNUMBER o = (global::UniCom.Netfun.smsNUMBER)fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                try {
                    o.@number = (global::System.String)GetTarget(ids[0]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[0]), (string)ids[0]);
                }
            }
            if (ids[1] != null) {
                try {
                    o.@tokens = (global::System.String)GetTarget(ids[1]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[1]), (string)ids[1]);
                }
            }
            if (ids[2] != null) {
                try {
                    o.@id = (global::System.String)GetTarget(ids[2]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[2]), (string)ids[2]);
                }
            }
        }

        object Read12_subaccountINFO() {
            global::UniCom.Netfun.subaccountINFO o;
            o = new global::UniCom.Netfun.subaccountINFO();
            Fixup fixup = new Fixup(o, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read12_subaccountINFO), 13);
            AddFixup(fixup);
            bool[] paramsRead = new bool[13];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) { Reader.Skip(); return o; }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id8_username && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[0]);
                        try {
                            o.@username = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@username);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id9_email && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            o.@email = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@email);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id10_password && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[2]);
                        try {
                            o.@password = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@password);
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id11_name && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[3]);
                        try {
                            o.@name = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@name);
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id12_lastname && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[4]);
                        try {
                            o.@lastname = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@lastname);
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id13_tel && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[5]);
                        try {
                            o.@tel = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@tel);
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id14_cel && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[6]);
                        try {
                            o.@cel = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@cel);
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id15_fax && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[7]);
                        try {
                            o.@fax = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@fax);
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id16_address && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[8]);
                        try {
                            o.@address = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@address);
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id17_city && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[9]);
                        try {
                            o.@city = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@city);
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id18_cap && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[10]);
                        try {
                            o.@cap = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@cap);
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id19_province && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[11]);
                        try {
                            o.@province = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@province);
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id20_notes && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[12]);
                        try {
                            o.@notes = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@notes);
                        paramsRead[12] = true;
                    }
                    else {
                        UnknownNode((object)o);
                    }
                }
                else {
                    UnknownNode((object)o);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        void fixup_Read12_subaccountINFO(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            global::UniCom.Netfun.subaccountINFO o = (global::UniCom.Netfun.subaccountINFO)fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                try {
                    o.@username = (global::System.String)GetTarget(ids[0]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[0]), (string)ids[0]);
                }
            }
            if (ids[1] != null) {
                try {
                    o.@email = (global::System.String)GetTarget(ids[1]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[1]), (string)ids[1]);
                }
            }
            if (ids[2] != null) {
                try {
                    o.@password = (global::System.String)GetTarget(ids[2]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[2]), (string)ids[2]);
                }
            }
            if (ids[3] != null) {
                try {
                    o.@name = (global::System.String)GetTarget(ids[3]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[3]), (string)ids[3]);
                }
            }
            if (ids[4] != null) {
                try {
                    o.@lastname = (global::System.String)GetTarget(ids[4]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[4]), (string)ids[4]);
                }
            }
            if (ids[5] != null) {
                try {
                    o.@tel = (global::System.String)GetTarget(ids[5]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[5]), (string)ids[5]);
                }
            }
            if (ids[6] != null) {
                try {
                    o.@cel = (global::System.String)GetTarget(ids[6]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[6]), (string)ids[6]);
                }
            }
            if (ids[7] != null) {
                try {
                    o.@fax = (global::System.String)GetTarget(ids[7]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[7]), (string)ids[7]);
                }
            }
            if (ids[8] != null) {
                try {
                    o.@address = (global::System.String)GetTarget(ids[8]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[8]), (string)ids[8]);
                }
            }
            if (ids[9] != null) {
                try {
                    o.@city = (global::System.String)GetTarget(ids[9]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[9]), (string)ids[9]);
                }
            }
            if (ids[10] != null) {
                try {
                    o.@cap = (global::System.String)GetTarget(ids[10]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[10]), (string)ids[10]);
                }
            }
            if (ids[11] != null) {
                try {
                    o.@province = (global::System.String)GetTarget(ids[11]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[11]), (string)ids[11]);
                }
            }
            if (ids[12] != null) {
                try {
                    o.@notes = (global::System.String)GetTarget(ids[12]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[12]), (string)ids[12]);
                }
            }
        }

        object Read13_subaccountUpdateINFO() {
            global::UniCom.Netfun.subaccountUpdateINFO o;
            o = new global::UniCom.Netfun.subaccountUpdateINFO();
            Fixup fixup = new Fixup(o, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read13_subaccountUpdateINFO), 14);
            AddFixup(fixup);
            bool[] paramsRead = new bool[14];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) { Reader.Skip(); return o; }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id8_username && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[0]);
                        try {
                            o.@username = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@username);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id9_email && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            o.@email = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@email);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id10_password && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[2]);
                        try {
                            o.@password = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@password);
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id11_name && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[3]);
                        try {
                            o.@name = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@name);
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id12_lastname && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[4]);
                        try {
                            o.@lastname = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@lastname);
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id13_tel && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[5]);
                        try {
                            o.@tel = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@tel);
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id14_cel && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[6]);
                        try {
                            o.@cel = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@cel);
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id15_fax && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[7]);
                        try {
                            o.@fax = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@fax);
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id16_address && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[8]);
                        try {
                            o.@address = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@address);
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id17_city && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[9]);
                        try {
                            o.@city = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@city);
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id18_cap && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[10]);
                        try {
                            o.@cap = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@cap);
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id19_province && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[11]);
                        try {
                            o.@province = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@province);
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id20_notes && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[12]);
                        try {
                            o.@notes = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@notes);
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id21_status && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        o.@statusSpecified = true;
                        o.@status = Read14_NullableOfBoolean(true);
                        paramsRead[13] = true;
                    }
                    else {
                        UnknownNode((object)o);
                    }
                }
                else {
                    UnknownNode((object)o);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        void fixup_Read13_subaccountUpdateINFO(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            global::UniCom.Netfun.subaccountUpdateINFO o = (global::UniCom.Netfun.subaccountUpdateINFO)fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                try {
                    o.@username = (global::System.String)GetTarget(ids[0]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[0]), (string)ids[0]);
                }
            }
            if (ids[1] != null) {
                try {
                    o.@email = (global::System.String)GetTarget(ids[1]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[1]), (string)ids[1]);
                }
            }
            if (ids[2] != null) {
                try {
                    o.@password = (global::System.String)GetTarget(ids[2]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[2]), (string)ids[2]);
                }
            }
            if (ids[3] != null) {
                try {
                    o.@name = (global::System.String)GetTarget(ids[3]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[3]), (string)ids[3]);
                }
            }
            if (ids[4] != null) {
                try {
                    o.@lastname = (global::System.String)GetTarget(ids[4]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[4]), (string)ids[4]);
                }
            }
            if (ids[5] != null) {
                try {
                    o.@tel = (global::System.String)GetTarget(ids[5]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[5]), (string)ids[5]);
                }
            }
            if (ids[6] != null) {
                try {
                    o.@cel = (global::System.String)GetTarget(ids[6]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[6]), (string)ids[6]);
                }
            }
            if (ids[7] != null) {
                try {
                    o.@fax = (global::System.String)GetTarget(ids[7]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[7]), (string)ids[7]);
                }
            }
            if (ids[8] != null) {
                try {
                    o.@address = (global::System.String)GetTarget(ids[8]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[8]), (string)ids[8]);
                }
            }
            if (ids[9] != null) {
                try {
                    o.@city = (global::System.String)GetTarget(ids[9]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[9]), (string)ids[9]);
                }
            }
            if (ids[10] != null) {
                try {
                    o.@cap = (global::System.String)GetTarget(ids[10]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[10]), (string)ids[10]);
                }
            }
            if (ids[11] != null) {
                try {
                    o.@province = (global::System.String)GetTarget(ids[11]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[11]), (string)ids[11]);
                }
            }
            if (ids[12] != null) {
                try {
                    o.@notes = (global::System.String)GetTarget(ids[12]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[12]), (string)ids[12]);
                }
            }
            if (ids[13] != null) {
                try {
                    o.@status = (global::System.Nullable<global::System.Boolean>)GetTarget(ids[13]);
                    o.@statusSpecified = true;
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.Nullable<global::System.Boolean>), GetTarget(ids[13]), (string)ids[13]);
                }
            }
        }

        object Read15_smsOPTIONS() {
            global::UniCom.Netfun.smsOPTIONS o;
            o = new global::UniCom.Netfun.smsOPTIONS();
            Fixup fixup = new Fixup(o, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read15_smsOPTIONS), 4);
            AddFixup(fixup);
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) { Reader.Skip(); return o; }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id22_gateway && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
                        try {
                            o.@gateway = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@gateway);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id23_date && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            o.@date = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@date);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id24_charset && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[2]);
                        try {
                            o.@charset = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@charset);
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id25_wappush && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[3]);
                        try {
                            o.@wappush = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@wappush);
                        paramsRead[3] = true;
                    }
                    else {
                        UnknownNode((object)o);
                    }
                }
                else {
                    UnknownNode((object)o);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            ReadEndElement();
            return o;
        }

        void fixup_Read15_smsOPTIONS(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            global::UniCom.Netfun.smsOPTIONS o = (global::UniCom.Netfun.smsOPTIONS)fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                try {
                    o.@gateway = (global::System.String)GetTarget(ids[0]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[0]), (string)ids[0]);
                }
            }
            if (ids[1] != null) {
                try {
                    o.@date = (global::System.String)GetTarget(ids[1]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[1]), (string)ids[1]);
                }
            }
            if (ids[2] != null) {
                try {
                    o.@charset = (global::System.String)GetTarget(ids[2]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[2]), (string)ids[2]);
                }
            }
            if (ids[3] != null) {
                try {
                    o.@wappush = (global::System.String)GetTarget(ids[3]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[3]), (string)ids[3]);
                }
            }
        }

        object Read16_smsDELIVERYFILTERS() {
            global::UniCom.Netfun.smsDELIVERYFILTERS o;
            o = new global::UniCom.Netfun.smsDELIVERYFILTERS();
            Fixup fixup = new Fixup(o, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read16_smsDELIVERYFILTERS), 3);
            AddFixup(fixup);
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) { Reader.Skip(); return o; }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id21_status && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
                        try {
                            o.@status = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@status);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id26_details && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            o.@details = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@details);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id27_receivers && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[2]);
                        try {
                            o.@receivers = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(o.@receivers);
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)o);
                    }
                }
                else {
                    UnknownNode((object)o);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            ReadEndElement();
            return o;
        }

        void fixup_Read16_smsDELIVERYFILTERS(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            global::UniCom.Netfun.smsDELIVERYFILTERS o = (global::UniCom.Netfun.smsDELIVERYFILTERS)fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                try {
                    o.@status = (global::System.String)GetTarget(ids[0]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[0]), (string)ids[0]);
                }
            }
            if (ids[1] != null) {
                try {
                    o.@details = (global::System.String)GetTarget(ids[1]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[1]), (string)ids[1]);
                }
            }
            if (ids[2] != null) {
                try {
                    o.@receivers = (global::System.String)GetTarget(ids[2]);
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.String), GetTarget(ids[2]), (string)ids[2]);
                }
            }
        }

        public object[] Read17_Item() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read17_Item), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id29_sms && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read17_Item(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read18_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations7 = 0;
            int readerCount7 = ReaderCount;
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
                CheckReaderCount(ref whileIterations7, ref readerCount7);
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

        public object[] Read19_Item() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations8, ref readerCount8);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read19_Item), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations9 = 0;
            int readerCount9 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id30_newCredit && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read19_Item(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read20_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations10 = 0;
            int readerCount10 = ReaderCount;
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
                CheckReaderCount(ref whileIterations10, ref readerCount10);
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

        public object[] Read21_addSubaccountResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read21_addSubaccountResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id6_id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read21_addSubaccountResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read22_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations13 = 0;
            int readerCount13 = ReaderCount;
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
                CheckReaderCount(ref whileIterations13, ref readerCount13);
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

        public object[] Read23_updateSubaccountResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations14 = 0;
            int readerCount14 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations14, ref readerCount14);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read23_updateSubaccountResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations15 = 0;
            int readerCount15 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id6_id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations15, ref readerCount15);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read23_updateSubaccountResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read24_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations16 = 0;
            int readerCount16 = ReaderCount;
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
                CheckReaderCount(ref whileIterations16, ref readerCount16);
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

        public object[] Read25_deleteSubaccountResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations17 = 0;
            int readerCount17 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations17, ref readerCount17);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read25_deleteSubaccountResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations18 = 0;
            int readerCount18 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id6_id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations18, ref readerCount18);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read25_deleteSubaccountResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read26_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations19 = 0;
            int readerCount19 = ReaderCount;
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
                CheckReaderCount(ref whileIterations19, ref readerCount19);
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

        public object[] Read27_createSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations20 = 0;
            int readerCount20 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations20, ref readerCount20);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read27_createSessionResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations21 = 0;
            int readerCount21 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id31_sessionKey && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations21, ref readerCount21);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read27_createSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read28_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations22 = 0;
            int readerCount22 = ReaderCount;
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
                CheckReaderCount(ref whileIterations22, ref readerCount22);
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

        public object[] Read29_aliveSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations23 = 0;
            int readerCount23 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations23, ref readerCount23);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read29_aliveSessionResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations24 = 0;
            int readerCount24 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id32_expiryTimestamp && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations24, ref readerCount24);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read29_aliveSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read30_aliveSessionResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations25 = 0;
            int readerCount25 = ReaderCount;
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
                CheckReaderCount(ref whileIterations25, ref readerCount25);
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

        public object[] Read31_isValidSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations26 = 0;
            int readerCount26 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations26, ref readerCount26);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read31_isValidSessionResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations27 = 0;
            int readerCount27 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id33_isValid && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                CheckReaderCount(ref whileIterations27, ref readerCount27);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read31_isValidSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read32_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations28 = 0;
            int readerCount28 = ReaderCount;
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
                CheckReaderCount(ref whileIterations28, ref readerCount28);
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

        public object[] Read33_deleteSessionResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations29 = 0;
            int readerCount29 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations29, ref readerCount29);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read33_deleteSessionResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations30 = 0;
            int readerCount30 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                CheckReaderCount(ref whileIterations30, ref readerCount30);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read33_deleteSessionResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read34_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations31 = 0;
            int readerCount31 = ReaderCount;
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
                CheckReaderCount(ref whileIterations31, ref readerCount31);
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

        public object[] Read35_deleteAllSessionUserResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations32 = 0;
            int readerCount32 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations32, ref readerCount32);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read35_deleteAllSessionUserResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations33 = 0;
            int readerCount33 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                CheckReaderCount(ref whileIterations33, ref readerCount33);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read35_deleteAllSessionUserResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read36_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations34 = 0;
            int readerCount34 = ReaderCount;
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
                CheckReaderCount(ref whileIterations34, ref readerCount34);
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

        public object[] Read37_getErrorDescrResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations35 = 0;
            int readerCount35 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations35, ref readerCount35);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read37_getErrorDescrResponse), 1);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations36 = 0;
            int readerCount36 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id34_errorDescr && (object) Reader.NamespaceURI == (object)id2_Item))) {
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
                CheckReaderCount(ref whileIterations36, ref readerCount36);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read37_getErrorDescrResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
        }

        public object[] Read38_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations37 = 0;
            int readerCount37 = ReaderCount;
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
                CheckReaderCount(ref whileIterations37, ref readerCount37);
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

        public object[] Read39_sendSmsSimpleResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations38 = 0;
            int readerCount38 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations38, ref readerCount38);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read39_sendSmsSimpleResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations39 = 0;
            int readerCount39 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id35_sendingID && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations39, ref readerCount39);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read39_sendSmsSimpleResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read40_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations40 = 0;
            int readerCount40 = ReaderCount;
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
                CheckReaderCount(ref whileIterations40, ref readerCount40);
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

        public object[] Read41_sendSmsAdvancedResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations41 = 0;
            int readerCount41 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations41, ref readerCount41);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read41_sendSmsAdvancedResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations42 = 0;
            int readerCount42 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id35_sendingID && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations42, ref readerCount42);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read41_sendSmsAdvancedResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read42_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations43 = 0;
            int readerCount43 = ReaderCount;
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
                CheckReaderCount(ref whileIterations43, ref readerCount43);
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

        public object[] Read43_getDeliveryResponse() {
            Reader.MoveToContent();
            object[] p = new object[3];
            Reader.MoveToContent();
            int whileIterations44 = 0;
            int readerCount44 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations44, ref readerCount44);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read43_getDeliveryResponse), 3);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[3];
            Reader.MoveToContent();
            int whileIterations45 = 0;
            int readerCount45 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id36_list && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id37_format && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id3_string, id4_Item, out fixup.Ids[2]);
                        try {
                            p[2] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[2]);
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations45, ref readerCount45);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read43_getDeliveryResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
            if (ids[2] != null) {
                p[2] = GetTarget(ids[2]);
            }
        }

        public object[] Read44_getDeliveryResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations46 = 0;
            int readerCount46 = ReaderCount;
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
                CheckReaderCount(ref whileIterations46, ref readerCount46);
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

        public object[] Read45_getCreditResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations47 = 0;
            int readerCount47 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations47, ref readerCount47);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read45_getCreditResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations48 = 0;
            int readerCount48 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id38_credit && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations48, ref readerCount48);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read45_getCreditResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read46_getCreditResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations49 = 0;
            int readerCount49 = ReaderCount;
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
                CheckReaderCount(ref whileIterations49, ref readerCount49);
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

        public object[] Read47_getCreditAsTotSmsResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations50 = 0;
            int readerCount50 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations50, ref readerCount50);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read47_getCreditAsTotSmsResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations51 = 0;
            int readerCount51 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id29_sms && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations51, ref readerCount51);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read47_getCreditAsTotSmsResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read48_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations52 = 0;
            int readerCount52 = ReaderCount;
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
                CheckReaderCount(ref whileIterations52, ref readerCount52);
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

        public object[] Read49_getCreditSubaccountResponse() {
            Reader.MoveToContent();
            object[] p = new object[2];
            Reader.MoveToContent();
            int whileIterations53 = 0;
            int readerCount53 = ReaderCount;
            while (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                string root = Reader.GetAttribute("root", "http://schemas.xmlsoap.org/soap/encoding/");
                if (root == null || System.Xml.XmlConvert.ToBoolean(root)) break;
                ReadReferencedElement();
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations53, ref readerCount53);
            }
            bool isEmptyWrapper = Reader.IsEmptyElement;
            Reader.ReadStartElement();
            Fixup fixup = new Fixup(p, new System.Xml.Serialization.XmlSerializationFixupCallback(this.fixup_Read49_getCreditSubaccountResponse), 2);
            AddFixup(fixup);
            IsReturnValue = true;
            bool[] paramsRead = new bool[2];
            Reader.MoveToContent();
            int whileIterations54 = 0;
            int readerCount54 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && (IsReturnValue || ((object) Reader.LocalName == (object)id28_error && (object) Reader.NamespaceURI == (object)id2_Item))) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[0]);
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
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id38_credit && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        object rre = ReadReferencingElement(id7_integer, id4_Item, out fixup.Ids[1]);
                        try {
                            p[1] = (global::System.String)rre;
                        }
                        catch (System.InvalidCastException) {
                            throw CreateInvalidCastException(typeof(global::System.String), rre, null);
                        }
                        Referenced(p[1]);
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)p);
                    }
                }
                else {
                    UnknownNode((object)p);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations54, ref readerCount54);
            }
            if (!isEmptyWrapper) ReadEndElement();
            ReadReferencedElements();
            return p;
        }

        void fixup_Read49_getCreditSubaccountResponse(object objFixup) {
            Fixup fixup = (Fixup)objFixup;
            object[] p = (object[])fixup.Source;
            string[] ids = fixup.Ids;
            if (ids[0] != null) {
                p[0] = GetTarget(ids[0]);
            }
            if (ids[1] != null) {
                p[1] = GetTarget(ids[1]);
            }
        }

        public object[] Read50_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            System.Collections.ArrayList hrefList = new System.Collections.ArrayList();
            System.Collections.ArrayList hrefListIsObject = new System.Collections.ArrayList();
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations55 = 0;
            int readerCount55 = ReaderCount;
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
                CheckReaderCount(ref whileIterations55, ref readerCount55);
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

        public object[] Read51_NewlotResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations56 = 0;
            int readerCount56 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id39_NewlotResponse, id40_httpwebservicekoineorg)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations57 = 0;
                    int readerCount57 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id41_return && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                p[0] = Read7_Newlot(true, true);
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @":return");
                            }
                        }
                        else {
                            UnknownNode((object)p, @":return");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations57, ref readerCount57);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://webservice.koine.org:NewlotResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations56, ref readerCount56);
            }
            return p;
        }

        public object[] Read52_NewlotResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations58 = 0;
            int readerCount58 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations58, ref readerCount58);
            }
            return p;
        }

        public object[] Read53_ConfigUniResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations59 = 0;
            int readerCount59 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id42_ConfigUniResponse, id40_httpwebservicekoineorg)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations60 = 0;
                    int readerCount60 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id41_return && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                p[0] = Read8_ConfigUni(true, true);
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @":return");
                            }
                        }
                        else {
                            UnknownNode((object)p, @":return");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations60, ref readerCount60);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://webservice.koine.org:ConfigUniResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations59, ref readerCount59);
            }
            return p;
        }

        public object[] Read54_ConfigUniResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations61 = 0;
            int readerCount61 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations61, ref readerCount61);
            }
            return p;
        }

        public object[] Read55_TrackingResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            Reader.MoveToContent();
            int whileIterations62 = 0;
            int readerCount62 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.IsStartElement(id43_TrackingResponse, id40_httpwebservicekoineorg)) {
                    bool[] paramsRead = new bool[1];
                    if (Reader.IsEmptyElement) { Reader.Skip(); Reader.MoveToContent(); continue; }
                    Reader.ReadStartElement();
                    Reader.MoveToContent();
                    int whileIterations63 = 0;
                    int readerCount63 = ReaderCount;
                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                            if (!paramsRead[0] && ((object) Reader.LocalName == (object)id41_return && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                p[0] = Read9_Tracking(true, true);
                                paramsRead[0] = true;
                            }
                            else {
                                UnknownNode((object)p, @":return");
                            }
                        }
                        else {
                            UnknownNode((object)p, @":return");
                        }
                        Reader.MoveToContent();
                        CheckReaderCount(ref whileIterations63, ref readerCount63);
                    }
                    ReadEndElement();
                }
                else {
                    UnknownNode(null, @"http://webservice.koine.org:TrackingResponse");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations62, ref readerCount62);
            }
            return p;
        }

        public object[] Read56_TrackingResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations64 = 0;
            int readerCount64 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations64, ref readerCount64);
            }
            return p;
        }

        global::UniCom.SiComunica.Tracking Read9_Tracking(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id44_Tracking && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id45_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::UniCom.SiComunica.Tracking o;
            o = new global::UniCom.SiComunica.Tracking();
            global::UniCom.SiComunica.Message[] a_0 = null;
            int ca_0 = 0;
            global::UniCom.SiComunica.Message[] a_3 = null;
            int ca_3 = 0;
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_0, ca_0, typeof(global::UniCom.SiComunica.Message), true);
                o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations65 = 0;
            int readerCount65 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id46_errors && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_0 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_0, ca_0, typeof(global::UniCom.SiComunica.Message));a_0[ca_0++] = Read6_Message(true, true);
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id21_status && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@status = null;
                        }
                        else {
                            o.@status = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id47_trackingLink && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@trackingLink = null;
                        }
                        else {
                            o.@trackingLink = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id48_warnings && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_3 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_3, ca_3, typeof(global::UniCom.SiComunica.Message));a_3[ca_3++] = Read6_Message(true, true);
                    }
                    else {
                        UnknownNode((object)o, @":errors, :status, :trackingLink, :warnings");
                    }
                }
                else {
                    UnknownNode((object)o, @":errors, :status, :trackingLink, :warnings");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations65, ref readerCount65);
            }
            o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_0, ca_0, typeof(global::UniCom.SiComunica.Message), true);
            o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
            ReadEndElement();
            return o;
        }

        global::UniCom.SiComunica.Message Read6_Message(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id49_Message && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id45_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::UniCom.SiComunica.Message o;
            o = new global::UniCom.SiComunica.Message();
            bool[] paramsRead = new bool[2];
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
            int whileIterations66 = 0;
            int readerCount66 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id50_code && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        o.@codeSpecified = true;
                        {
                            o.@code = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id51_message && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@message = null;
                        }
                        else {
                            o.@message = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":code, :message");
                    }
                }
                else {
                    UnknownNode((object)o, @":code, :message");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations66, ref readerCount66);
            }
            ReadEndElement();
            return o;
        }

        global::UniCom.SiComunica.ConfigUni Read8_ConfigUni(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id52_ConfigUni && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id45_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::UniCom.SiComunica.ConfigUni o;
            o = new global::UniCom.SiComunica.ConfigUni();
            global::UniCom.SiComunica.Message[] a_1 = null;
            int ca_1 = 0;
            global::UniCom.SiComunica.Message[] a_3 = null;
            int ca_3 = 0;
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_1, ca_1, typeof(global::UniCom.SiComunica.Message), true);
                o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations67 = 0;
            int readerCount67 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id53_configUniLink && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@configUniLink = null;
                        }
                        else {
                            o.@configUniLink = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id46_errors && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_1 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_1, ca_1, typeof(global::UniCom.SiComunica.Message));a_1[ca_1++] = Read6_Message(true, true);
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id21_status && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@status = null;
                        }
                        else {
                            o.@status = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id48_warnings && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_3 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_3, ca_3, typeof(global::UniCom.SiComunica.Message));a_3[ca_3++] = Read6_Message(true, true);
                    }
                    else {
                        UnknownNode((object)o, @":configUniLink, :errors, :status, :warnings");
                    }
                }
                else {
                    UnknownNode((object)o, @":configUniLink, :errors, :status, :warnings");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations67, ref readerCount67);
            }
            o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_1, ca_1, typeof(global::UniCom.SiComunica.Message), true);
            o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
            ReadEndElement();
            return o;
        }

        global::UniCom.SiComunica.Newlot Read7_Newlot(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id54_Newlot && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id45_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::UniCom.SiComunica.Newlot o;
            o = new global::UniCom.SiComunica.Newlot();
            global::UniCom.SiComunica.Message[] a_0 = null;
            int ca_0 = 0;
            global::UniCom.SiComunica.Message[] a_3 = null;
            int ca_3 = 0;
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_0, ca_0, typeof(global::UniCom.SiComunica.Message), true);
                o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations68 = 0;
            int readerCount68 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id46_errors && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_0 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_0, ca_0, typeof(global::UniCom.SiComunica.Message));a_0[ca_0++] = Read6_Message(true, true);
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id55_idcampagna && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@idcampagna = null;
                        }
                        else {
                            o.@idcampagna = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id21_status && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (ReadNull()) {
                            o.@status = null;
                        }
                        else {
                            o.@status = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id48_warnings && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        a_3 = (global::UniCom.SiComunica.Message[])EnsureArrayIndex(a_3, ca_3, typeof(global::UniCom.SiComunica.Message));a_3[ca_3++] = Read6_Message(true, true);
                    }
                    else {
                        UnknownNode((object)o, @":errors, :idcampagna, :status, :warnings");
                    }
                }
                else {
                    UnknownNode((object)o, @":errors, :idcampagna, :status, :warnings");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations68, ref readerCount68);
            }
            o.@errors = (global::UniCom.SiComunica.Message[])ShrinkArray(a_0, ca_0, typeof(global::UniCom.SiComunica.Message), true);
            o.@warnings = (global::UniCom.SiComunica.Message[])ShrinkArray(a_3, ca_3, typeof(global::UniCom.SiComunica.Message), true);
            ReadEndElement();
            return o;
        }

        global::System.Nullable<global::System.Boolean> Read14_NullableOfBoolean(bool checkType) {
            global::System.Nullable<global::System.Boolean> o = default(global::System.Nullable<global::System.Boolean>);
            if (ReadNull())
                return o;
            object rre = ReadReferencedElement(id56_boolean, id4_Item);
            if (rre != null) {
                try {
                    o = (global::System.Boolean)rre;
                }
                catch (System.InvalidCastException) {
                    throw CreateInvalidCastException(typeof(global::System.Boolean), rre, null);
                }
                Referenced(o);
            }
            return o;
        }

        protected override void InitCallbacks() {
            AddReadCallback(id57_smsNUMBER, id58_Item, typeof(global::UniCom.Netfun.smsNUMBER), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read10_smsNUMBER));
            AddReadCallback(id59_subaccountINFO, id58_Item, typeof(global::UniCom.Netfun.subaccountINFO), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read12_subaccountINFO));
            AddReadCallback(id60_subaccountUpdateINFO, id58_Item, typeof(global::UniCom.Netfun.subaccountUpdateINFO), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read13_subaccountUpdateINFO));
            AddReadCallback(id61_ArrayOfSmsNUMBER, id58_Item, typeof(global::UniCom.Netfun.smsNUMBER[]), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read57_Array));
            AddReadCallback(id62_smsOPTIONS, id58_Item, typeof(global::UniCom.Netfun.smsOPTIONS), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read15_smsOPTIONS));
            AddReadCallback(id63_smsDELIVERYFILTERS, id58_Item, typeof(global::UniCom.Netfun.smsDELIVERYFILTERS), new System.Xml.Serialization.XmlSerializationReadCallback(this.Read16_smsDELIVERYFILTERS));
        }

        object Read57_Array() {
            // dummy array method
            UnknownNode(null);
            return null;
        }

        string id58_Item;
        string id14_cel;
        string id50_code;
        string id55_idcampagna;
        string id18_cap;
        string id12_lastname;
        string id32_expiryTimestamp;
        string id60_subaccountUpdateINFO;
        string id63_smsDELIVERYFILTERS;
        string id31_sessionKey;
        string id62_smsOPTIONS;
        string id3_string;
        string id22_gateway;
        string id27_receivers;
        string id20_notes;
        string id9_email;
        string id17_city;
        string id44_Tracking;
        string id33_isValid;
        string id30_newCredit;
        string id41_return;
        string id4_Item;
        string id52_ConfigUni;
        string id48_warnings;
        string id46_errors;
        string id11_name;
        string id2_Item;
        string id42_ConfigUniResponse;
        string id59_subaccountINFO;
        string id37_format;
        string id29_sms;
        string id26_details;
        string id40_httpwebservicekoineorg;
        string id49_Message;
        string id23_date;
        string id36_list;
        string id54_Newlot;
        string id24_charset;
        string id21_status;
        string id15_fax;
        string id35_sendingID;
        string id10_password;
        string id47_trackingLink;
        string id57_smsNUMBER;
        string id25_wappush;
        string id1_number;
        string id38_credit;
        string id61_ArrayOfSmsNUMBER;
        string id16_address;
        string id5_tokens;
        string id7_integer;
        string id28_error;
        string id45_Item;
        string id13_tel;
        string id34_errorDescr;
        string id56_boolean;
        string id6_id;
        string id43_TrackingResponse;
        string id19_province;
        string id51_message;
        string id39_NewlotResponse;
        string id53_configUniLink;
        string id8_username;

        protected override void InitIDs() {
            id58_Item = Reader.NameTable.Add(@"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
            id14_cel = Reader.NameTable.Add(@"cel");
            id50_code = Reader.NameTable.Add(@"code");
            id55_idcampagna = Reader.NameTable.Add(@"idcampagna");
            id18_cap = Reader.NameTable.Add(@"cap");
            id12_lastname = Reader.NameTable.Add(@"lastname");
            id32_expiryTimestamp = Reader.NameTable.Add(@"expiryTimestamp");
            id60_subaccountUpdateINFO = Reader.NameTable.Add(@"subaccountUpdateINFO");
            id63_smsDELIVERYFILTERS = Reader.NameTable.Add(@"smsDELIVERYFILTERS");
            id31_sessionKey = Reader.NameTable.Add(@"sessionKey");
            id62_smsOPTIONS = Reader.NameTable.Add(@"smsOPTIONS");
            id3_string = Reader.NameTable.Add(@"string");
            id22_gateway = Reader.NameTable.Add(@"gateway");
            id27_receivers = Reader.NameTable.Add(@"receivers");
            id20_notes = Reader.NameTable.Add(@"notes");
            id9_email = Reader.NameTable.Add(@"email");
            id17_city = Reader.NameTable.Add(@"city");
            id44_Tracking = Reader.NameTable.Add(@"Tracking");
            id33_isValid = Reader.NameTable.Add(@"isValid");
            id30_newCredit = Reader.NameTable.Add(@"newCredit");
            id41_return = Reader.NameTable.Add(@"return");
            id4_Item = Reader.NameTable.Add(@"http://www.w3.org/2001/XMLSchema");
            id52_ConfigUni = Reader.NameTable.Add(@"ConfigUni");
            id48_warnings = Reader.NameTable.Add(@"warnings");
            id46_errors = Reader.NameTable.Add(@"errors");
            id11_name = Reader.NameTable.Add(@"name");
            id2_Item = Reader.NameTable.Add(@"");
            id42_ConfigUniResponse = Reader.NameTable.Add(@"ConfigUniResponse");
            id59_subaccountINFO = Reader.NameTable.Add(@"subaccountINFO");
            id37_format = Reader.NameTable.Add(@"format");
            id29_sms = Reader.NameTable.Add(@"sms");
            id26_details = Reader.NameTable.Add(@"details");
            id40_httpwebservicekoineorg = Reader.NameTable.Add(@"http://webservice.koine.org");
            id49_Message = Reader.NameTable.Add(@"Message");
            id23_date = Reader.NameTable.Add(@"date");
            id36_list = Reader.NameTable.Add(@"list");
            id54_Newlot = Reader.NameTable.Add(@"Newlot");
            id24_charset = Reader.NameTable.Add(@"charset");
            id21_status = Reader.NameTable.Add(@"status");
            id15_fax = Reader.NameTable.Add(@"fax");
            id35_sendingID = Reader.NameTable.Add(@"sendingID");
            id10_password = Reader.NameTable.Add(@"password");
            id47_trackingLink = Reader.NameTable.Add(@"trackingLink");
            id57_smsNUMBER = Reader.NameTable.Add(@"smsNUMBER");
            id25_wappush = Reader.NameTable.Add(@"wappush");
            id1_number = Reader.NameTable.Add(@"number");
            id38_credit = Reader.NameTable.Add(@"credit");
            id61_ArrayOfSmsNUMBER = Reader.NameTable.Add(@"ArrayOfSmsNUMBER");
            id16_address = Reader.NameTable.Add(@"address");
            id5_tokens = Reader.NameTable.Add(@"tokens");
            id7_integer = Reader.NameTable.Add(@"integer");
            id28_error = Reader.NameTable.Add(@"error");
            id45_Item = Reader.NameTable.Add(@"http://beans.webservice.koine.org/xsd");
            id13_tel = Reader.NameTable.Add(@"tel");
            id34_errorDescr = Reader.NameTable.Add(@"errorDescr");
            id56_boolean = Reader.NameTable.Add(@"boolean");
            id6_id = Reader.NameTable.Add(@"id");
            id43_TrackingResponse = Reader.NameTable.Add(@"TrackingResponse");
            id19_province = Reader.NameTable.Add(@"province");
            id51_message = Reader.NameTable.Add(@"message");
            id39_NewlotResponse = Reader.NameTable.Add(@"NewlotResponse");
            id53_configUniLink = Reader.NameTable.Add(@"configUniLink");
            id8_username = Reader.NameTable.Add(@"username");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    public sealed class ArrayOfObjectSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountAsTotSms", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write16_getCreditSubaccountAsTotSms((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer1 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountAsTotSmsResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read17_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer2 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountAsTotSmsInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write17_Item((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer3 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountAsTotSmsResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read18_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer4 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addTransactionSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write18_addTransactionSubaccount((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer5 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addTransactionSubaccountResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read19_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer6 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addTransactionSubaccountInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write19_Item((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer7 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addTransactionSubaccountResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read20_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer8 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write20_addSubaccount((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer9 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addSubaccountResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read21_addSubaccountResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer10 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addSubaccountInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write21_addSubaccountInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer11 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"addSubaccountResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read22_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer12 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"updateSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write22_updateSubaccount((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer13 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"updateSubaccountResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read23_updateSubaccountResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer14 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"updateSubaccountInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write23_updateSubaccountInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer15 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"updateSubaccountResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read24_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer16 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write24_deleteSubaccount((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer17 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSubaccountResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read25_deleteSubaccountResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer18 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSubaccountInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write25_deleteSubaccountInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer19 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSubaccountResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read26_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer20 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"createSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write26_createSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer21 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"createSessionResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read27_createSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer22 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"createSessionInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write27_createSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer23 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"createSessionResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read28_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer24 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"aliveSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write28_aliveSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer25 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"aliveSessionResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read29_aliveSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer26 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"aliveSessionInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write29_aliveSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer27 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"aliveSessionResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read30_aliveSessionResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer28 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"isValidSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write30_isValidSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer29 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"isValidSessionResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read31_isValidSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer30 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"isValidSessionInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write31_isValidSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer31 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"isValidSessionResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read32_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer32 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSession", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write32_deleteSession((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer33 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSessionResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read33_deleteSessionResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer34 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSessionInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write33_deleteSessionInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer35 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteSessionResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read34_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer36 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteAllSessionUser", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write34_deleteAllSessionUser((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer37 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteAllSessionUserResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read35_deleteAllSessionUserResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer38 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteAllSessionUserInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write35_deleteAllSessionUserInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer39 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"deleteAllSessionUserResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read36_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer40 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getErrorDescr", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write36_getErrorDescr((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer41 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getErrorDescrResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read37_getErrorDescrResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer42 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getErrorDescrInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write37_getErrorDescrInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer43 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getErrorDescrResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read38_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer44 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsSimple", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write38_sendSmsSimple((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer45 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsSimpleResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read39_sendSmsSimpleResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer46 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsSimpleInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write39_sendSmsSimpleInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer47 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsSimpleResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read40_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer48 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsAdvanced", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write40_sendSmsAdvanced((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer49 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsAdvancedResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read41_sendSmsAdvancedResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer50 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsAdvancedInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write41_sendSmsAdvancedInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer51 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"sendSmsAdvancedResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read42_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer52 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getDelivery", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write42_getDelivery((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer53 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getDeliveryResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read43_getDeliveryResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer54 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getDeliveryInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write43_getDeliveryInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer55 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getDeliveryResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read44_getDeliveryResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer56 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCredit", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write44_getCredit((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer57 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read45_getCreditResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer58 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write45_getCreditInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer59 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read46_getCreditResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer60 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditAsTotSms", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write46_getCreditAsTotSms((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer61 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditAsTotSmsResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read47_getCreditAsTotSmsResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer62 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditAsTotSmsInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write47_getCreditAsTotSmsInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer63 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditAsTotSmsResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read48_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer64 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccount", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write48_getCreditSubaccount((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer65 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountResponse", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read49_getCreditSubaccountResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer66 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountInHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write49_getCreditSubaccountInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer67 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"getCreditSubaccountResponseOutHeaders", @"http://v1.web-servizi.net/api/key/450df5a8661c451b8263ae7336b16035/unicosistema/soap/");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read50_Item();
        }
    }

    public sealed class ArrayOfObjectSerializer68 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Newlot", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write50_Newlot((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer69 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"NewlotResponse", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read51_NewlotResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer70 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"NewlotInHeaders", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write51_NewlotInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer71 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"NewlotResponseOutHeaders", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read52_NewlotResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer72 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ConfigUni", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write52_ConfigUni((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer73 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ConfigUniResponse", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read53_ConfigUniResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer74 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ConfigUniInHeaders", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write53_ConfigUniInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer75 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ConfigUniResponseOutHeaders", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read54_ConfigUniResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer76 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Tracking", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write54_Tracking((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer77 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"TrackingResponse", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read55_TrackingResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer78 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"TrackingInHeaders", @"http://webservice.koine.org");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write55_TrackingInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer79 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"TrackingResponseOutHeaders", @"http://webservice.koine.org");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read56_TrackingResponseOutHeaders();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response"] = @"Read17_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read18_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response"] = @"Read19_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read20_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):Response"] = @"Read21_addSubaccountResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):OutHeaders"] = @"Read22_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):Response"] = @"Read23_updateSubaccountResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):OutHeaders"] = @"Read24_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):Response"] = @"Read25_deleteSubaccountResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read26_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):Response"] = @"Read27_createSessionResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read28_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):Response"] = @"Read29_aliveSessionResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):OutHeaders"] = @"Read30_aliveSessionResponseOutHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String isValidSession(System.String):Response"] = @"Read31_isValidSessionResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String isValidSession(System.String):OutHeaders"] = @"Read32_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSession(System.String):Response"] = @"Read33_deleteSessionResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSession(System.String):OutHeaders"] = @"Read34_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):Response"] = @"Read35_deleteAllSessionUserResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):OutHeaders"] = @"Read36_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):Response"] = @"Read37_getErrorDescrResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):OutHeaders"] = @"Read38_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response"] = @"Read39_sendSmsSimpleResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read40_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):Response"] = @"Read41_sendSmsAdvancedResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):OutHeaders"] = @"Read42_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):Response"] = @"Read43_getDeliveryResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):OutHeaders"] = @"Read44_getDeliveryResponseOutHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):Response"] = @"Read45_getCreditResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):OutHeaders"] = @"Read46_getCreditResponseOutHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response"] = @"Read47_getCreditAsTotSmsResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read48_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):Response"] = @"Read49_getCreditSubaccountResponse";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):OutHeaders"] = @"Read50_Item";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):Response"] = @"Read51_NewlotResponse";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):OutHeaders"] = @"Read52_NewlotResponseOutHeaders";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):Response"] = @"Read53_ConfigUniResponse";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):OutHeaders"] = @"Read54_ConfigUniResponseOutHeaders";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):Response"] = @"Read55_TrackingResponse";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):OutHeaders"] = @"Read56_TrackingResponseOutHeaders";
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
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)"] = @"Write16_getCreditSubaccountAsTotSms";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write17_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)"] = @"Write18_addTransactionSubaccount";
                    _tmp[@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write19_Item";
                    _tmp[@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef)"] = @"Write20_addSubaccount";
                    _tmp[@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):InHeaders"] = @"Write21_addSubaccountInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef)"] = @"Write22_updateSubaccount";
                    _tmp[@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):InHeaders"] = @"Write23_updateSubaccountInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef)"] = @"Write24_deleteSubaccount";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write25_deleteSubaccountInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef)"] = @"Write26_createSession";
                    _tmp[@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write27_createSessionInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef)"] = @"Write28_aliveSession";
                    _tmp[@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):InHeaders"] = @"Write29_aliveSessionInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String isValidSession(System.String)"] = @"Write30_isValidSession";
                    _tmp[@"UniCom.Netfun.smsService:System.String isValidSession(System.String):InHeaders"] = @"Write31_isValidSessionInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSession(System.String)"] = @"Write32_deleteSession";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteSession(System.String):InHeaders"] = @"Write33_deleteSessionInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String)"] = @"Write34_deleteAllSessionUser";
                    _tmp[@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):InHeaders"] = @"Write35_deleteAllSessionUserInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String)"] = @"Write36_getErrorDescr";
                    _tmp[@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):InHeaders"] = @"Write37_getErrorDescrInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)"] = @"Write38_sendSmsSimple";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write39_sendSmsSimpleInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef)"] = @"Write40_sendSmsAdvanced";
                    _tmp[@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):InHeaders"] = @"Write41_sendSmsAdvancedInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef)"] = @"Write42_getDelivery";
                    _tmp[@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):InHeaders"] = @"Write43_getDeliveryInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef)"] = @"Write44_getCredit";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):InHeaders"] = @"Write45_getCreditInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)"] = @"Write46_getCreditAsTotSms";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write47_getCreditAsTotSmsInHeaders";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef)"] = @"Write48_getCreditSubaccount";
                    _tmp[@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):InHeaders"] = @"Write49_getCreditSubaccountInHeaders";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String)"] = @"Write50_Newlot";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):InHeaders"] = @"Write51_NewlotInHeaders";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity)"] = @"Write52_ConfigUni";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):InHeaders"] = @"Write53_ConfigUniInHeaders";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String)"] = @"Write54_Tracking";
                    _tmp[@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):InHeaders"] = @"Write55_TrackingInHeaders";
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
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer62());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):Response", new ArrayOfObjectSerializer13());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):Response", new ArrayOfObjectSerializer49());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):Response", new ArrayOfObjectSerializer41());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):InHeaders", new ArrayOfObjectSerializer54());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String isValidSession(System.String):InHeaders", new ArrayOfObjectSerializer30());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSession(System.String):InHeaders", new ArrayOfObjectSerializer34());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer65());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer20());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String)", new ArrayOfObjectSerializer36());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String)", new ArrayOfObjectSerializer40());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer26());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer22());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSession(System.String)", new ArrayOfObjectSerializer32());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef)", new ArrayOfObjectSerializer8());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer19());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):InHeaders", new ArrayOfObjectSerializer78());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):OutHeaders", new ArrayOfObjectSerializer43());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer63());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):OutHeaders", new ArrayOfObjectSerializer39());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer2());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer16());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):Response", new ArrayOfObjectSerializer69());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer61());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer3());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):InHeaders", new ArrayOfObjectSerializer14());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer56());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer23());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String)", new ArrayOfObjectSerializer76());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer58());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String isValidSession(System.String)", new ArrayOfObjectSerializer28());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSession(System.String):OutHeaders", new ArrayOfObjectSerializer35());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer6());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer47());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer46());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity)", new ArrayOfObjectSerializer72());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer5());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer67());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef)", new ArrayOfObjectSerializer48());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef)", new ArrayOfObjectSerializer52());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):Response", new ArrayOfObjectSerializer73());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):OutHeaders", new ArrayOfObjectSerializer75());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):InHeaders", new ArrayOfObjectSerializer38());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer15());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer44());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSession(System.String):Response", new ArrayOfObjectSerializer33());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String updateSubaccount(System.String, System.String, System.String, UniCom.Netfun.subaccountUpdateINFO, System.String ByRef)", new ArrayOfObjectSerializer12());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer27());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):OutHeaders", new ArrayOfObjectSerializer71());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String createSession(System.String, System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer21());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer4());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer66());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):Response", new ArrayOfObjectSerializer53());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer60());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer59());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsSimple(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer45());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteAllSessionUser(System.String, System.String):Response", new ArrayOfObjectSerializer37());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.ConfigUni ConfigUni(UniCom.SiComunica.Identity):InHeaders", new ArrayOfObjectSerializer74());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String):InHeaders", new ArrayOfObjectSerializer70());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):InHeaders", new ArrayOfObjectSerializer10());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String isValidSession(System.String):Response", new ArrayOfObjectSerializer29());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Newlot Newlot(UniCom.SiComunica.Identity, System.String, System.String, System.String, System.String, Byte[], System.String)", new ArrayOfObjectSerializer68());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer17());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCredit(System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer57());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):Response", new ArrayOfObjectSerializer77());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String deleteSubaccount(System.String, System.String, System.String, System.String ByRef):InHeaders", new ArrayOfObjectSerializer18());
                    _tmp.Add(@"UniCom.SiComunica.KoineWebService:UniCom.SiComunica.Tracking Tracking(UniCom.SiComunica.Identity, System.String):OutHeaders", new ArrayOfObjectSerializer79());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getDelivery(System.String, System.String, System.String, System.String, UniCom.Netfun.smsDELIVERYFILTERS, System.String ByRef, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer55());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):InHeaders", new ArrayOfObjectSerializer50());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String isValidSession(System.String):OutHeaders", new ArrayOfObjectSerializer31());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccountAsTotSms(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer1());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getErrorDescr(System.String):InHeaders", new ArrayOfObjectSerializer42());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addTransactionSubaccount(System.String, System.String, System.String, System.String, System.String, System.String, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer7());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):Response", new ArrayOfObjectSerializer9());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String sendSmsAdvanced(System.String, System.String, UniCom.Netfun.smsNUMBER[], System.String, System.String, UniCom.Netfun.smsOPTIONS, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer51());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer24());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String aliveSession(System.String, System.String, System.String ByRef):Response", new ArrayOfObjectSerializer25());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String addSubaccount(System.String, System.String, UniCom.Netfun.subaccountINFO, System.String ByRef):OutHeaders", new ArrayOfObjectSerializer11());
                    _tmp.Add(@"UniCom.Netfun.smsService:System.String getCreditSubaccount(System.String, System.String, System.String, System.String ByRef)", new ArrayOfObjectSerializer64());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::UniCom.Netfun.smsService)) return true;
            if (type == typeof(global::UniCom.SiComunica.KoineWebService)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            return null;
        }
    }
}
