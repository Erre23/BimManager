using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BimManager.Entidad.Estructuras
{
    public class CDR
    {
        public CDR(string Cdr_Base64_String)
        {
            try
            {
                Observaciones_ = new List<string>();
                Leer(Convert.FromBase64String(Cdr_Base64_String));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        public CDR(byte[] Cdr_ArrayByte)
        {
            try
            {
                Observaciones_ = new List<string>();
                Leer(Cdr_ArrayByte);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        private XmlNodeList Leer_Etiqueta_Lista(XmlDocument xml, string Etiqueta)
        {
            try
            {
                return xml.GetElementsByTagName(Etiqueta);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        private XmlNode Leer_Etiqueta_Node(XmlDocument xml, string Etiqueta)
        {
            try
            {
                return Leer_Etiqueta_Node(xml, Etiqueta, 0);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        private XmlNode Leer_Etiqueta_Node(XmlDocument xml, string Etiqueta, int Indice)
        {
            try
            {
                return xml.GetElementsByTagName(Etiqueta).Item(Indice);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        private void Leer(byte[] Cdr_ArrayByte)
        {
            try
            {
                string xml_String = Encoding.GetEncoding("ISO-8859-1").GetString(Cdr_ArrayByte);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xml_String);


                //Version UBL
                XmlNode nodeVersion_UBL = xml.GetElementsByTagName("cbc:UBLVersionID").Item(0);
                Version_UBL_ = (nodeVersion_UBL != null ? nodeVersion_UBL.InnerText : "");


                //Version Estructura
                XmlNode nodeVersion_Estructura = xml.GetElementsByTagName("cbc:CustomizationID").Item(0);
                Version_Estructura_ = (nodeVersion_Estructura != null ? nodeVersion_Estructura.InnerText : "");


                //Identificador de la CDR
                XmlNode nodeID = xml.GetElementsByTagName("cbc:ID").Item(0);
                Id_ = (nodeID != null ? nodeID.InnerText : "");


                //Recepcion Fecha Hora
                XmlNode nodeIssueDate = xml.GetElementsByTagName("cbc:IssueDate").Item(0);
                XmlNode nodeIssueTime = xml.GetElementsByTagName("cbc:IssueTime").Item(0);
                try
                {
                    Recepcion_FechaHora_ = (nodeIssueDate != null && nodeIssueTime != null ? Convert.ToDateTime(nodeIssueDate.InnerText + " " + nodeIssueTime.InnerText) : new DateTime());
                }
                catch { }


                //Generacion Fecha Hora
                XmlNode nodeRespondeDate = xml.GetElementsByTagName("cbc:ResponseDate").Item(0);
                XmlNode nodeRespondeTime = xml.GetElementsByTagName("cbc:ResponseTime").Item(0);
                try
                {
                    Generacion_FechaHora_ = (nodeRespondeDate != null && nodeRespondeTime != null ? Convert.ToDateTime(nodeRespondeDate.InnerText + " " + nodeRespondeTime.InnerText) : new DateTime());
                }
                catch { }


                //Observaciones
                XmlNodeList nodeListNotes = xml.GetElementsByTagName("cbc:Note");
                if (nodeListNotes != null)
                {
                    foreach (XmlElement xmlNote in nodeListNotes)
                    {
                        Observaciones_.Add(xmlNote.InnerText);
                    }
                }


                //Firma Datos (ID, Documento, Nombre)
                XmlNode nodeSignature = xml.GetElementsByTagName("cac:Signature").Item(0);
                if (nodeSignature != null)
                {
                    foreach (XmlNode nodeSignature_Hijo in nodeSignature.ChildNodes)
                    {
                        //Firma ID
                        if (nodeSignature_Hijo.Name == "cbc:ID")
                        {
                            Firma_Id_ = nodeSignature_Hijo.InnerText;
                        }
                        else if (nodeSignature_Hijo.Name == "cac:SignatoryParty")
                        {
                            foreach (XmlNode nodeSignatoryParty_Hijo in nodeSignature_Hijo.ChildNodes)
                            {
                                if (nodeSignatoryParty_Hijo.Name == "cac:PartyIdentification")
                                {
                                    foreach (XmlNode nodePartyIdentification_Hijo in nodeSignatoryParty_Hijo.ChildNodes)
                                    {
                                        if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                        {
                                            //Firma Documento
                                            Firma_Documento_ = nodePartyIdentification_Hijo.InnerText;
                                        }
                                    }
                                }

                                else if (nodeSignatoryParty_Hijo.Name == "cac:PartyName")
                                {
                                    foreach (XmlNode nodePartyName_Hijo in nodeSignatoryParty_Hijo.ChildNodes)
                                    {
                                        if (nodePartyName_Hijo.Name == "cbc:Name")
                                        {
                                            //Firma Nombre
                                            Firma_Nombre_ = nodePartyName_Hijo.InnerText;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                //Emisor Ruc
                XmlNode nodeSenderParty = xml.GetElementsByTagName("cac:SenderParty").Item(0);
                if (nodeSenderParty != null)
                {
                    foreach (XmlNode nodeSenderParty_Hijo in nodeSenderParty.ChildNodes)
                    {
                        if (nodeSenderParty_Hijo.Name == "cac:PartyIdentification")
                        {
                            foreach (XmlNode nodePartyIdentification_Hijo in nodeSenderParty_Hijo.ChildNodes)
                            {
                                if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                {
                                    Emisor_Ruc_ = nodePartyIdentification_Hijo.InnerText;
                                }
                            }
                        }
                    }
                }


                //Receptor Ruc
                XmlNode nodeReceiverParty = xml.GetElementsByTagName("cac:ReceiverParty").Item(0);
                if (nodeReceiverParty != null)
                {
                    foreach (XmlNode nodeReceiverParty_Hijo in nodeReceiverParty.ChildNodes)
                    {
                        if (nodeReceiverParty_Hijo.Name == "cac:PartyIdentification")
                        {
                            foreach (XmlNode nodePartyIdentification_Hijo in nodeReceiverParty_Hijo.ChildNodes)
                            {
                                if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                {
                                    Receptor_Ruc_ = nodePartyIdentification_Hijo.InnerText;
                                }
                            }
                        }
                    }
                }


                //Datos de respuesta
                XmlNode nodeDocumentResponse = xml.GetElementsByTagName("cac:DocumentResponse").Item(0);
                if (nodeDocumentResponse != null)
                {
                    foreach (XmlNode nodeDocumentResponse_Hijo in nodeDocumentResponse.ChildNodes)
                    {
                        if (nodeDocumentResponse_Hijo.Name == "cac:Response")
                        {
                            foreach (XmlNode nodeResponse_Hijo in nodeDocumentResponse_Hijo.ChildNodes)
                            {
                                if (nodeResponse_Hijo.Name == "cbc:ReferenceID")
                                {
                                    //Identificador Documento Enviado
                                    Identificador_Documento_Enviado_ = nodeResponse_Hijo.InnerText;
                                }
                                else if (nodeResponse_Hijo.Name == "cbc:ResponseCode")
                                {
                                    //Respuesta Codigo
                                    Respuesta_Codigo_ = nodeResponse_Hijo.InnerText;
                                }
                                else if (nodeResponse_Hijo.Name == "cbc:Description")
                                {
                                    //Respuesta Descripción
                                    Respuesta_Descripcion_ = nodeResponse_Hijo.InnerText;
                                }
                            }
                        }
                        else if (nodeDocumentResponse_Hijo.Name == "cac:DocumentReference")
                        {
                            foreach (XmlNode nodeDocumentReference_Hijo in nodeDocumentResponse_Hijo.ChildNodes)
                            {
                                if (nodeDocumentReference_Hijo.Name == "cbc:ID")
                                {
                                    //Identificador Documento Procesado
                                    Identificador_Documento_Procesado_ = nodeDocumentReference_Hijo.InnerText;
                                }
                            }
                        }
                        else if (nodeDocumentResponse_Hijo.Name == "cac:RecipientParty")
                        {
                            foreach (XmlNode nodeRecipientParty_Hijo in nodeDocumentResponse_Hijo.ChildNodes)
                            {
                                if (nodeRecipientParty_Hijo.Name == "cac:PartyIdentification")
                                {
                                    foreach (XmlNode nodePartyIdentification_Hijo in nodeRecipientParty_Hijo.ChildNodes)
                                    {
                                        if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                        {
                                            //Identificacion del receptor del documento electrónico procesado
                                            Identificacion_Receptor_Documento_Procesado_ = nodePartyIdentification_Hijo.InnerText;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        private string Firma_Id_;
        /// <summary>
        /// Identificador de la firma digital
        /// </summary>
        private string Firma_Id { get { return Firma_Id_; } }


        private string Firma_Documento_;
        /// <summary>
        /// Numero de documento de la entidad o persona que firma
        /// </summary>
        public string Firma_Documento { get { return Firma_Documento_; } }


        private string Firma_Nombre_;
        /// <summary>
        /// Nombre o razón social de la persona o entidad que firma
        /// </summary>
        public string Firma_Nombre { get { return Firma_Nombre_; } }


        private string Id_;
        /// <summary>
        /// Identificador del CDR
        /// </summary>
        public string Id { get { return Id_; } }



        private DateTime Recepcion_FechaHora_;
        /// <summary>
        /// Fecha y hora de recepcion del documento enviado
        /// </summary>
        public DateTime Recepcion_FechaHora { get { return Recepcion_FechaHora_; } }


        private DateTime Generacion_FechaHora_;
        /// <summary>
        /// Fecha y hora de generacion de la CDR
        /// </summary>
        public DateTime Generacion_FechaHora { get { return Generacion_FechaHora_; } }



        private List<string> Observaciones_;
        /// <summary>
        /// Lista de observaciones del documento relacionado
        /// </summary>
        public List<string> Observaciones { get { return Observaciones_; } }


        private string Emisor_Ruc_;
        /// <summary>
        /// Ruc del emisor de la CDR
        /// </summary>
        public string Emisor_Ruc { get { return Emisor_Ruc_; } }


        private string Receptor_Ruc_;
        /// <summary>
        /// Ruc del receptor de la CDR
        /// </summary>
        public string Receptor_Ruc { get { return Receptor_Ruc_; } }


        private string Identificador_Documento_Enviado_;
        /// <summary>
        /// Identificador del documento electronico enviado (Solo serie y correlativo)
        /// </summary>
        public string Identificador_Documento_Enviado { get { return Identificador_Documento_Enviado_; } }


        private string Respuesta_Codigo_;
        /// <summary>
        /// Código de respuesta del envío
        /// </summary>
        public string Respuesta_Codigo { get { return Respuesta_Codigo_; } }


        public enum _Estado
        {
            noDefinido,
            Aceptada,
            AceptadaConObservaciones,
            Rechazada
        }

        /// <summary>
        /// Retornar un string Indicando si el comprobante esta Aceptado, Aceptado con observaciones o rechazado
        /// </summary>
        public _Estado Estado
        {
            get
            {
                _Estado Estado_ = _Estado.noDefinido;
                if (Respuesta_Codigo_ != null && Respuesta_Codigo_.Trim() != "")
                {
                    if (Convert.ToInt32(Respuesta_Codigo_) >= 2000 && Convert.ToInt32(Respuesta_Codigo_) <= 3999) Estado_ = _Estado.Rechazada;
                    else if (Convert.ToInt32(Respuesta_Codigo_) >= 4000) Estado_ = _Estado.AceptadaConObservaciones;
                    else if (Convert.ToInt32(Respuesta_Codigo_) == 0) Estado_ = _Estado.Aceptada;
                }
                return Estado_;
            }
        }

        /// <summary>
        /// Retorna la descripción del estado (ACEPTADA, ACEPTADA CON OBSRVACIONES, RECHAZADA, NO DEFINIDO) segun el valor de la propiedad Sunat_Cdr_Estado
        /// </summary>
        public string Estado_Descripcion
        {
            get
            {
                string _Estado_Descripcion = "NO DEFINIDO";

                switch (Estado)
                {
                    case _Estado.Aceptada:
                        _Estado_Descripcion = "ACEPTADA";
                        break;

                    case _Estado.AceptadaConObservaciones:
                        _Estado_Descripcion = "ACEPTADA CON OBSERVACIONES";
                        break;

                    case _Estado.Rechazada:
                        _Estado_Descripcion = "RECHAZADA";
                        break;
                }

                return _Estado_Descripcion;
            }
        }


        private string Respuesta_Descripcion_;
        /// <summary>
        /// Descripción de la respuesta del envío
        /// </summary>
        public string Respuesta_Descripcion { get { return Respuesta_Descripcion_; } }


        private string Identificador_Documento_Procesado_;
        /// <summary>
        /// Identificador del documento electrónico procesado
        /// </summary>
        public string Identificador_Documento_Procesado { get { return Identificador_Documento_Procesado_; } }


        private string Identificacion_Receptor_Documento_Procesado_;
        /// <summary>
        /// Identificación del receptor del documento electrónico procesado
        /// </summary>
        public string Identificacion_Receptor_Documento_Procesado { get { return Identificacion_Receptor_Documento_Procesado_; } }


        private string Version_UBL_;
        /// <summary>
        /// Versión del UBL
        /// </summary>
        public string Version_UBL { get { return Version_UBL_; } }


        private string Version_Estructura_;
        /// <summary>
        /// Versión de la estructura del documento
        /// </summary>
        public string Version_Estructura { get { return Version_Estructura_; } }
    }
}
