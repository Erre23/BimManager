using BimManager.Sunat.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BimManager.Sunat.Entidad.Constantes;
using BimManager.Sunat.Entidad;
using BimManager.Sunat.Entidad.Models;
using BimManager.Sunat.Entidad.Estructuras;

namespace BimManager.Sunat
{
    public class FacturacionElectronica
    {
        #region[Variables estaticas]
        /// <summary>
        /// Resolución de Intendencia Nº 0620050000100 que es la resolución de la autorización otorgado por SUNAT a Emtrafesa para la emisión de comprobante electrónico desde su sistema
        /// </summary>
        private static string Resolucion_Intendencia { get { return "0620050000100"; } }

        private static string Certificado_Clave { get { return "CDE34RFVCVV"; } }

        private static string SOL_Usuario { get { return "ERICK123"; } }

        private static string SOL_Clave { get { return "Erick2016"; } }

        private static string SOL_Usuario_Test { get { return "MODDATOS"; } }

        private static string SOL_Clave_Test { get { return "moddatos"; } }


        private static string IP_LAN = "172.16.0.3";

        private static string IP_WAN = "200.37.118.201";

        private static string FTP_Usuario = "cedes";

        private static string FTP_Clave = "Sedes2017";

        private static string FTP_CarpetaBase_LAN = "ftp://" + IP_LAN + "/";

        private static string FTP_CarpetaBase_WAN = "ftp://" + IP_WAN + "/";
        #endregion


        #region [Métodos Comunes]
        public static bool RUCValido(string ruc)
        {
            // Verifica que tenga 11 caracteres
            if (ruc.Length != 11 || !long.TryParse(ruc, out _))
                return false;

            // Verifica el primer dígito
            int tipoContribuyente = int.Parse(ruc.Substring(0, 1));
            if (tipoContribuyente < 1 || tipoContribuyente > 2)
                return false;

            // Cálculo del dígito verificador
            int[] factores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 }; // Arreglo correcto
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += int.Parse(ruc[i].ToString()) * factores[i];
            }

            int mod = suma % 11;
            int digitoVerificador = (mod == 0) ? 0 : (11 - mod);

            // Ajuste para asegurarse de que el dígito verificador sea un solo dígito
            if (digitoVerificador == 10 || digitoVerificador == 11)
                digitoVerificador = 0;

            // Compara el dígito verificador con el último dígito del RUC
            return digitoVerificador == int.Parse(ruc[10].ToString());
        }
        #endregion [Métodos Comunes]

        #region[propiedades staticas]
        private static string Email_Notificacion { get { return "webmaster@emtrafesa.com"; } }
        #endregion


        #region[Sunat Windows Service]
        private WS_Sunat_Envio_Beta.billServiceClient WS_Sunat_Envio()
        {
            try
            {
                return new WS_Sunat_Envio_Beta.billServiceClient();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        //private WS_Sunat_Envio_Produccion.billServiceClient WS_Sunat_Envio()
        //{
        //    try
        //    {
        //        //
        //        System.Net.ServicePointManager.UseNagleAlgorithm = true;
        //        System.Net.ServicePointManager.Expect100Continue = false;
        //        System.Net.ServicePointManager.CheckCertificateRevocationList = true;

        //        //Instaciamos un objeto del servicio
        //        WS_Sunat_Envio_Produccion.billServiceClient objSunat_WS = new WS_Sunat_Envio_Produccion.billServiceClient();

        //        //Le indicamos las credenciales de usuario y clave SOL
        //        objSunat_WS.ClientCredentials.CreateSecurityTokenManager();
        //        objSunat_WS.ClientCredentials.UserName.UserName = EmtrafesaDatos.RUC + SOL_Usuario;
        //        objSunat_WS.ClientCredentials.UserName.Password = SOL_Clave;

        //        return objSunat_WS;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw new Exception(Ex.Message, Ex.InnerException);
        //    }
        //}


        private WS_Sunat_Consulta_CDR.billServiceClient WS_Sunat_Consulta_CDR()
        {
            try
            {
                //
                System.Net.ServicePointManager.UseNagleAlgorithm = true;
                System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.CheckCertificateRevocationList = true;

                //Instaciamos un objeto del servicio
                WS_Sunat_Consulta_CDR.billServiceClient objSunat_WS = new WS_Sunat_Consulta_CDR.billServiceClient();

                //Le indicamos las credenciales de usuario y clave SOL
                objSunat_WS.ClientCredentials.CreateSecurityTokenManager();
                objSunat_WS.ClientCredentials.UserName.UserName = EmpresaDatos.RUC + SOL_Usuario;
                objSunat_WS.ClientCredentials.UserName.Password = SOL_Clave;

                return objSunat_WS;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        private WS_Sunat_Consulta_Validez.billValidServiceClient WS_Sunat_Consulta_Validez()
        {
            try
            {
                //
                System.Net.ServicePointManager.UseNagleAlgorithm = true;
                System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.CheckCertificateRevocationList = true;

                //Instaciamos un objeto del servicio
                WS_Sunat_Consulta_Validez.billValidServiceClient objSunat_WS = new WS_Sunat_Consulta_Validez.billValidServiceClient();

                //Le indicamos las credenciales de usuario y clave SOL
                objSunat_WS.ClientCredentials.CreateSecurityTokenManager();
                objSunat_WS.ClientCredentials.UserName.UserName = EmpresaDatos.RUC + SOL_Usuario;
                objSunat_WS.ClientCredentials.UserName.Password = SOL_Clave;

                return objSunat_WS;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }
        #endregion


        #region[Facturacion Electronica]


        /// <summary>
        /// Retorna un objeto instanciado de la clase Ges.FacturaElectronica.Serializador que es la que nos permitira 
        /// </summary>
        /// <param name="TipoDocumento"></param>
        /// <returns></returns>
        private Serializador Crear_Serializador(bool tieneDatosAdicionales)
        {
            try
            {
                var objSerializador = new Serializador();
                objSerializador.TipoDocumento = (tieneDatosAdicionales ? 1 : 0);
                objSerializador.RutaCertificadoDigital_Base64String = Convert.ToBase64String(Properties.Resources.Certificado);
                objSerializador.PasswordCertificado = Certificado_Clave;

                return objSerializador;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        public CDR Enviar_Factura_NotaCreditoDeFactura(string comprobanteXML, string nombreArchivo_SinExtension)
        {
            try
            {
                //Generamos el arhivo zip desde una archivo xml en Formato Base64String
                var objSerializador = Crear_Serializador(true);
                string ZipFolder = objSerializador.GenerarZip(comprobanteXML, nombreArchivo_SinExtension);


                //Variables para el envio y respuesta
                byte[] zip_envio = Convert.FromBase64String(ZipFolder); //Convertimos el archivo ZIP a un Array Byte
                byte[] zip_respuesta = null;


                //Instanciamos el servicio web
                var objSunat_WS_Envio = WS_Sunat_Envio();


                try
                {
                    //Abrimos la conexion al servicio web
                    objSunat_WS_Envio.Open();


                    //Enviamos a SUNAT, y capturamos el ZIP de respuesta en formato Array Byte
                    zip_respuesta = objSunat_WS_Envio.sendBill(nombreArchivo_SinExtension + ".zip", zip_envio);


                    //Cerramos la conexion al servicio web
                    objSunat_WS_Envio.Close();
                }
                catch (FaultException Ex)
                {
                    if (objSunat_WS_Envio != null && objSunat_WS_Envio.State != System.ServiceModel.CommunicationState.Closed && objSunat_WS_Envio.State != System.ServiceModel.CommunicationState.Closing)
                    {
                        objSunat_WS_Envio.Close();
                    }
                    throw new Exception(Ex.Message + (Ex.Code.Name != "" ? "\n\r-Código de error: " + Ex.Code.Name : ""), Ex.InnerException);
                }

                //Gestionamos el guardado, descompresion, lectura, subida al ftp y 
                string rutaArchivo = Path.GetTempPath();
                string nombreArchivo_ZipRespuesta = "R-" + nombreArchivo_SinExtension + ".zip";
                string nombreArchivo_XmlRespuesta = "R-" + nombreArchivo_SinExtension + ".xml";
                string ruta_NombreArchivo_ZipRespuesta = rutaArchivo + nombreArchivo_ZipRespuesta;
                string ruta_NombreArchivo_XmlRespuesta = rutaArchivo + nombreArchivo_XmlRespuesta;


                //Try para capturar algun error al momento de eliminar los archivos temporales
               
                //Validamos que el zip de respuesta no este vacío
                if (zip_respuesta != null && nombreArchivo_ZipRespuesta.Length > 0)
                {
                    //Guardamos el archivo zip de respuesta en la carpeta temporal
                    File.WriteAllBytes(ruta_NombreArchivo_ZipRespuesta, zip_respuesta);


                    //Descomprimimos el archivo zip de respuesta en la misma carpeta temporal
                    objSerializador.DescomprimirZip_Respuesta(ruta_NombreArchivo_ZipRespuesta, rutaArchivo);


                    //Cargamos el archivo xml de al CDR de respuesta
                    var cdrArrayByte = System.IO.File.ReadAllBytes(ruta_NombreArchivo_XmlRespuesta);


                    //Convertimos el cdr a base64String y se lo pasamos a la DocumentoElectronicoXml 
                    var cdr = new CDR(cdrArrayByte);

                    //Eliminamos primero el xml y luego el zip de esta forma no nos da error indicando que el zip no se puede eliminar porque esta siendo usado por otro proceso
                    try
                    {
                        System.IO.File.Delete(ruta_NombreArchivo_XmlRespuesta);
                        System.IO.File.Delete(ruta_NombreArchivo_ZipRespuesta);
                    }
                    catch(Exception)
                    {
                    }

                    return cdr;
                }

                return null;
            }
            catch (Exception Ex)
            {
                throw new Exception("Facturación Electrónica - " + Ex.Message, Ex.InnerException);
            }
        }


        //public CDR Consulta_CDR(string tipoDocumentoSunat_Codigo, string serie, int correlativo, ref string mensajeRespuesta)
        //{
        //    try
        //    {
        //        var objSunat_WS_Consulta_CDR = WS_Sunat_Consulta_CDR();

        //        byte[] Cdr_En_Zip = null;
        //        mensajeRespuesta = "";

        //        try
        //        {
        //            //Abrimos la conexion al servicio web
        //            objSunat_WS_Consulta_CDR.Open();


        //            //Enviamos a SUNAT, y capturamos el ZIP de respuesta en formato Array Byte
        //            var Respuesta = objSunat_WS_Consulta_CDR.getStatusCdr(EmpresaDatos.RUC, tipoDocumentoSunat_Codigo, serie, correlativo);


        //            mensajeRespuesta = "Datos de la Cdr del Comprobante " + objSunat_ComprobanteElectronico.TipoDocumentoSunat_Nombre + " " + objSunat_ComprobanteElectronico.Serie_Correlativo;
        //            mensajeRespuesta += "\n\r-Codigo de Respuesta: " + Respuesta.statusCode.ToString();
        //            mensajeRespuesta += "\n\r-Mensaje de Respuesta: " + Respuesta.statusMessage;

        //            Cdr_En_Zip = Respuesta.content;

        //            //Cerramos la conexion al servicio web
        //            objSunat_WS_Consulta_CDR.Close();
        //        }
        //        catch (FaultException Ex)
        //        {
        //            if (objSunat_WS_Consulta_CDR != null && objSunat_WS_Consulta_CDR.State != System.ServiceModel.CommunicationState.Closed && objSunat_WS_Consulta_CDR.State != System.ServiceModel.CommunicationState.Closing)
        //            {
        //                objSunat_WS_Consulta_CDR.Close();
        //            }
        //            throw new Exception(Ex.Message + (Ex.Code.Name != "" ? "\n\r-Código de error: " + Ex.Code.Name : ""), Ex.InnerException);
        //        }

        //        bool Existe_Cdr = false;
        //        if (Cdr_En_Zip != null && Cdr_En_Zip.Length > 0)
        //        {
        //            //Gestionamos el guardado, descompresion, lectura, subida al ftp y 
        //            string RutaArchivo = Path.GetTempPath();
        //            string NombreArchivo_ZipRespuesta = "R-" + objSunat_ComprobanteElectronico.NombreDocumento_Formato_Sunat + ".zip";
        //            string NombreArchivo_XmlRespuesta = "R-" + objSunat_ComprobanteElectronico.NombreDocumento_Formato_Sunat + ".xml";
        //            string Ruta_NombreArchivo_ZipRespuesta = RutaArchivo + NombreArchivo_ZipRespuesta;
        //            string Ruta_NombreArchivo_XmlRespuesta = RutaArchivo + NombreArchivo_XmlRespuesta;


        //            byte[] Cdr_Xml = null;

        //            //Try para capturar algun error al momento de eliminar los archivos temporales
        //            try
        //            {
        //                //Guaramos el archivo zip de respuesta en la carpeta temporal
        //                File.WriteAllBytes(Ruta_NombreArchivo_ZipRespuesta, Cdr_En_Zip);


        //                //Descomprimimos el archivo zip de respuesta en la misma carpeta temporal
        //                new Serializador().DescomprimirZip_Respuesta(Ruta_NombreArchivo_ZipRespuesta, RutaArchivo);


        //                //Cargamos el archivo xml de al CDR de respuesta
        //                Cdr_Xml = System.IO.File.ReadAllBytes(Ruta_NombreArchivo_XmlRespuesta);


        //                //Indicamos que el comprobante ha sido enviado
        //                objSunat_ComprobanteElectronico.Enviado = true;

        //                //Convertimos el cdr a base64String y se lo pasamos a objSunat_ComunicacionDeBaja
        //                objSunat_ComprobanteElectronico.CdrXml = Convert.ToBase64String(Cdr_Xml);


        //                //Actualizamos el codigo de la cdr en la clase Sunat_ComunicacionDeBaja
        //                objSunat_ComprobanteElectronico.Cdr_Codigo = Convert.ToInt16(objSunat_ComprobanteElectronico.Cdr.Respuesta_Codigo);

        //                //Indicamos que existe una CDR
        //                Existe_Cdr = true;

        //                //Eliminamos primero el xml y luego el zip de esta forma no nos da error indicando que el zip no se puede eliminar porque esta siendo usado por otro proceso
        //                System.IO.File.Delete(Ruta_NombreArchivo_XmlRespuesta);
        //                System.IO.File.Delete(Ruta_NombreArchivo_ZipRespuesta);

        //            }
        //            catch (Exception Ex)
        //            {
        //                throw new Exception(Ex.Message, Ex.InnerException);
        //            }
        //        }

        //        return objSunat_ComprobanteElectronico;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw new Exception("Facturación Electrónica - " + Ex.Message, Ex.InnerException);
        //    }
        //}

        //public string FacturacionElectronica_Consulta_Validez(Ee.Contabilidad.Sunat_ComprobanteElectronico objSunat_ComprobanteElectronico)
        //{
        //    var objSunat_WS_Consulta_Validez = WS_Sunat_Consulta_Validez();

        //    string MensajeRespuesta = "";

        //    try
        //    {
        //        //Abrimos la conexion al servicio web
        //        objSunat_WS_Consulta_Validez.Open();


        //        //Enviamos a SUNAT, y capturamos el ZIP de respuesta en formato Array Byte
        //        var Respuesta =
        //            objSunat_WS_Consulta_Validez.validaCDPcriterios
        //            (
        //                EmtrafesaDatos.RUC,
        //                objSunat_ComprobanteElectronico.TipoDocumentoSunat_Codigo,
        //                objSunat_ComprobanteElectronico.Serie,
        //                objSunat_ComprobanteElectronico.Correlativo.ToString(),
        //                //(objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad != null ? objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad.IdTipoDocumentoIdentidad : ""),
        //                (objSunat_ComprobanteElectronico.Serie.Substring(0, 1) == "F" && objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad != null ? objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad.IdTipoDocumentoIdentidad : "-"),
        //                //(objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad != null ? objSunat_ComprobanteElectronico.DocumentoIdentidadNumero : ""),
        //                (objSunat_ComprobanteElectronico.Serie.Substring(0, 1) == "F" && objSunat_ComprobanteElectronico.IdTipoDocumentoIdentidad != null ? objSunat_ComprobanteElectronico.DocumentoIdentidadNumero : ""),
        //                objSunat_ComprobanteElectronico.Fecha.ToShortDateString(),
        //                Convert.ToDouble(objSunat_ComprobanteElectronico.Total),
        //                ""
        //            );

        //        //Capturamos los datos de consulta
        //        MensajeRespuesta = "Datos de la consulta de validez del Comprobante " + objSunat_ComprobanteElectronico.TipoDocumentoSunat_Nombre + " " + objSunat_ComprobanteElectronico.Serie_Correlativo;
        //        MensajeRespuesta += "\n\r-Codigo de Respuesta: " + Respuesta.statusCode.ToString();
        //        MensajeRespuesta += "\n\r-Mensaje de Respuesta: " + Respuesta.statusMessage;

        //        //Cerramos la conexion al servicio web
        //        objSunat_WS_Consulta_Validez.Close();

        //        //Retornamos la Respuesta
        //        return MensajeRespuesta;
        //    }
        //    catch (FaultException Ex)
        //    {
        //        if (objSunat_WS_Consulta_Validez != null && objSunat_WS_Consulta_Validez.State != System.ServiceModel.CommunicationState.Closed && objSunat_WS_Consulta_Validez.State != System.ServiceModel.CommunicationState.Closing)
        //        {
        //            objSunat_WS_Consulta_Validez.Close();
        //        }
        //        throw new Exception("CEDES - " + Ex.Message + (Ex.Code.Name != "" ? "\n\r-Código de error: " + Ex.Code.Name : ""), Ex.InnerException);
        //    }
        //}


        public DocumentoElectronico Generar_BoletaFactura(DocumentoElectronico objDocumentoElectronico)
        {            
            try
            {
                //Validamos que sea una boleta o factura
                if (objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.Boleta && objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.Factura)
                {
                    throw new Exception("El documento electrónico que desea generar no es boleta ni factura");
                }

                //Validamos que se haya ingresado un correlativo
                if (objDocumentoElectronico.Correlativo < 0)
                {
                    throw new Exception("El correlativo del comprobante no puede ser cero");
                }

                //Validamos que el tipo de monesa sea SOLES ya que la empresa solo emite comprobante en SOLES
                if (objDocumentoElectronico.Moneda != Catalogo_02_TipoMoneda.Soles)
                {
                    throw new Exception("EMTRAFESA no emite comprobantes con tipo de moneda distinta a SOLES");
                }

                //Cuando es factura
                if (objDocumentoElectronico.TipoDocumento == Catalogo_01_TipoDocumento.Factura)
                {
                    //Validamos que la serie del comprobante corresponda al tipo de documento
                    if (objDocumentoElectronico.Serie.Substring(0, 1) != "F")
                    {
                        throw new Exception("La serie ingresada no corresponde a factura, toda serie de factura debe empezar con la letra F");
                    }

                    //Validamos que el cliente sea un juridico ya que el comprobante es una factura
                    if (objDocumentoElectronico.Receptor.TipoDocumento != Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("No puede emitir una factura a un cliente con tipo de documento diferente a ruc");
                    }

                    //Validamos que que se haya ingresado el número de ruc
                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 11)
                    {
                        throw new Exception("El nº ruc del cliente no tiene 11 dígitos");
                    }

                    //Validamos que el número ruc tenga un formato válido
                    if (RUCValido(objDocumentoElectronico.Receptor.NroDocumento) == false)
                    {
                        throw new Exception("El nº de ruc del cliente no tiene un formato válido para SUNAT");
                    }

                    //Validamos que se haya ingresado la Razón Social
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar la razón social del cliente a quien se emite el comprobante");
                    }
                }
                //Cuando es boleta
                else if (objDocumentoElectronico.TipoDocumento == Catalogo_01_TipoDocumento.Boleta)
                {
                    //Validamos que la serie del comprobante corresponda al tipo de documento
                    if (objDocumentoElectronico.Serie.Substring(0, 1) != "B")
                    {
                        throw new Exception("La serie ingresada no corresponde a boleta, toda serie de boleta debe empezar con la letra B");
                    }

                    //Validamos que el cliente no sea un juridico ya que el comprobante es una boleta
                    if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("El tipo de documento del cliente a quien se emite el comprobante tiene tipo de documento ruc, no se puede emitir una boleta a un cliente jurídico");
                    }

                    //Validamos si el comprobante tiene un monto mayor a 700 soles para verificar los datos del cliente a quien se le emite el comprobante
                    if (objDocumentoElectronico.TotalVenta >= 700)
                    {
                        //Validamos que se haya ingresado el tipo de documento
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El codigo " + objDocumentoElectronico.Receptor.TipoDocumento + " no pertenece a ningún tipo de documento del catálogo 6");
                        }
                        else //Cuando es valido
                        {
                            //Cuando es Dni
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                            {
                                //Validamos que tenga 8 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                {
                                    throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de DNI debe tener 8 Dígitos");
                                }
                            }
                            //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                            {
                                //Validamos que tenga mínimo 5 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                {
                                    throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de nro de documento debe tener al menos 5 Dígitos");
                                }
                            }
                            //Cuando es NoDomiciliadoSinRuc
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El tipo de documento no puede ser no domiciliado sin ruc");
                            }
                        }
                    }
                    //Validamos si el comprobante ha llenado un dato ya el tipo de documento o nro de documento para validar que ambos esten llenados
                    else if ((objDocumentoElectronico.Receptor.TipoDocumento != null && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "" && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "-") ||
                            (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != ""))
                    {
                        //Cuando no se ingresó el tipo de documento válido
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            //Validamos que se haya ingresado un nº de documento
                            if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                            {
                                throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero no ha específicado un tipo de documento válido del catalogo 6");
                            }
                        }
                        else //Cuando se ingresó un tipo de documento válido
                        {
                            //Verificamos si el tipo de documento es no domiciliado sin ruc
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                //Validamos que no se haya ingresado nro de documento
                                if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                                {
                                    throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero ha especificado como tipo de documento No Domiciliado Sin Ruc");
                                }
                            }
                            else //Cuando es diferente a no domiciliado sin ruc
                            {
                                //Cuando es Dni
                                if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                                {
                                    //Validamos que tenga 8 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                    {
                                        throw new Exception("El nº de DNI del cliente debe tener 8 Dígitos");
                                    }
                                }
                                //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                                else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                                {
                                    //Validamos que tenga mínimo 5 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                    {
                                        throw new Exception("El nº de nro de documento del cliente debe tener al menos 5 Dígitos");
                                    }
                                }
                            }
                        }
                    }

                    //Validamos que se haya ingresado los apellidos y nombres
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar los apellidos y nombres del cliente a quien se emite el comprobante");
                    }
                }

                //Variable para guardar los datos a adicionales propios de SUNAT
                List<DatoAdicional> objArrDatoAdicional = new List<DatoAdicional>();

                //Recorremos los datos adicionales para validar que no haya algun dato no perteneciente al catalogo de sunat para ponerlo como dato adicional interno
                foreach (DatoAdicional objDatoAdicional in objDocumentoElectronico.DatoAdicionales)
                {
                    //Validamos si el Codigo del dato adicional esta dentro del catalogo
                    if (Catalogo_15_DatoAdicional.Validar_Codigo(objDatoAdicional.Codigo))
                    {
                        //Si es asi lo agregamos al lista de datos adicionales segun SUNAT
                        objArrDatoAdicional.Add
                        (
                            new DatoAdicional
                            {
                                Codigo = objDatoAdicional.Codigo,
                                Valor = objDatoAdicional.Valor
                            }
                        );
                    }
                    else //Sino lo agregamos a la lista de datos adicionales internos
                    {
                        //Validamos que la lista de datos adicional interno este inicializada sino la inicializamos
                        if (objDocumentoElectronico.DatoAdicionales_Internos == null) objDocumentoElectronico.DatoAdicionales_Internos = new List<DatoAdicional>();

                        //Agregamos el datos adicional internos
                        objDocumentoElectronico.DatoAdicionales_Internos.Add
                        (
                            new DatoAdicional
                            {
                                Codigo = objDatoAdicional.Codigo,
                                Valor = objDatoAdicional.Valor
                            }
                        );
                    }
                }


                //Actualizamos los datos adicional según Sunat
                objDocumentoElectronico.DatoAdicionales = objArrDatoAdicional;

                //Validamos que el comprobante tenga detalles
                if (objDocumentoElectronico.Items == null || objDocumentoElectronico.Items.Count == 0)
                {
                    throw new Exception("El comprobante no tiene detalles");
                }


                //Validamos el detalle de los comprobantes
                string Errores = "";
                foreach (DocumentoElectronicoDetalle Item in objDocumentoElectronico.Items)
                {
                    //Titulo
                    string Titulo = "\n\n\r***ITEM Nº " + Item.Id + "***";
                    //Validamos que el item no este repetido
                    if (objDocumentoElectronico.Items.FindAll(I => I.Id == Item.Id).Count() > 1)
                    {
                        Errores += "\n\r-El nº de item se repite 2 o más veces";
                    }

                    //Validamos que el detalle tenga cantidad mayor
                    if (Item.Cantidad <= 0)
                    {
                        Errores += "\n\r-La cantidad ingresada es menor o igual a cero (0)";
                    }

                    //Validamos que el detalle tenga descripcion diferente a vacío
                    if (Item.Descripcion == null || Item.Descripcion.Trim() == "")
                    {
                        Errores += "\n\r-No ingresó la descripción";
                    }

                    //Validamos el tipo de operacion
                    if (Item.TipoPrecio != Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV
                        && Item.TipoPrecio != Catalogo_16_TipoPrecioVentaUnitario.ValorReferencialUnitario_OperacionesNoOnerosas)
                    {
                        Errores += "\n\r-No se específico el tipo de precio (precio unitario incluye igv o valor referencial unitario operación no onerosa - Catálogo 16)";
                    }
                }

                //Validamos si hay errores en los detalles
                if (Errores != "")
                {
                    throw new Exception("Existen los siguientes errores: " + Errores);
                }

                //Validamos que el comprobante tenga alguno de los totales mayores a cero 0
                if (objDocumentoElectronico.Gravadas == 0
                    && objDocumentoElectronico.Exoneradas == 0
                    && objDocumentoElectronico.Inafectas == 0
                    && objDocumentoElectronico.Gratuitas == 0)
                {
                    throw new Exception("El comprobante tiene valor cero (0) en todos los totales (gravadas, exoneradas, inafectas y gratuitas), debe indicar un valor mayor a cero (0) en al menos uno de los totales");
                }

                //Validamos que si existe un monto gravado superior a cero (0) debe existir un monto de igv mayor a cero (0)
                if (objDocumentoElectronico.Gravadas > 0 && objDocumentoElectronico.TotalIgv <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto gravado pero no tiene monto de igv");
                }
                //Validamos que si existe un monto de igv superior a cero (0) debe existir un monto gravado mayor a cero (0)
                else if (objDocumentoElectronico.TotalIgv > 0 && objDocumentoElectronico.Gravadas <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto de igv pero no tiene monto gravado");
                }

                //Validamos que el monto total del comprobante sea igual a la siguiente operacion (gravados + inafectos + exonerados - Descuento Global + TotalIgv + TotalIsc + TotalOtrosTributos)
                decimal TotalComprobante = objDocumentoElectronico.Gravadas +
                                            objDocumentoElectronico.Inafectas +
                                            objDocumentoElectronico.Exoneradas -
                                            objDocumentoElectronico.DescuentoGlobal +
                                            objDocumentoElectronico.TotalIgv +
                                            objDocumentoElectronico.TotalIsc +
                                            objDocumentoElectronico.TotalOtrosTributos;
                if (objDocumentoElectronico.TotalVenta != TotalComprobante)
                {
                    throw new Exception("El total de venta del comprobante no coincide con la siguiente operación (gravada + exonerada + inafecta - Descuento global + TotalIgv + TotalIsc + Total Otros Tributos) ");
                }

                //Generamos el Serializador que es la clase que nos permite genera el xml, comprimirlo el xml y descomprimir el cdr
                var objSerializador = Crear_Serializador(true);


                //Creamos un objeto de tipo invoice (que es la que contiene toda la estructura xml) 
                //usando la clase Ges.FacturaElectronica.Generador y usando el objeto Documento Electronico
                Invoice objEstructura_Factura = Generador.GenerarInvoice(objDocumentoElectronico);


                //Generamos el xml en string firmado debidamente
                objDocumentoElectronico.ComprobanteXml_Base64String = objSerializador.GenerarXml(objEstructura_Factura, true);
                objDocumentoElectronico.DigestValue = objSerializador.DigestValue;
                objDocumentoElectronico.Generado = true;

                //Retornamos el mismo Facturacion.Models.DocumentoElectronico con los datos del xml
                return objDocumentoElectronico;
            }
            catch (Exception Ex)
            {
                throw new Exception("Facturación Electrónica - " + Ex.Message, Ex.InnerException);
            }
        }

        private void Validar_Datos_Boleta_Factura(DocumentoElectronico objDocumentoElectronico, bool Excluir_Validar_Existe)
        {
            try
            {
                //Validamos que sea una boleta o factura
                if (objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.Boleta && objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.Factura)
                {
                    throw new Exception("El documento electrónico que desea generar no es boleta ni factura");
                }

                //Validamos que se haya ingresado un correlativo
                if (objDocumentoElectronico.Correlativo < 0)
                {
                    throw new Exception("El correlativo del comprobante no puede ser cero");
                }

                //Validamos que el tipo de monesa sea SOLES ya que la empresa solo emite comprobante en SOLES
                if (objDocumentoElectronico.Moneda != Catalogo_02_TipoMoneda.Soles)
                {
                    throw new Exception("EMTRAFESA no emite comprobantes con tipo de moneda distinta a SOLES");
                }

                //Cuando es factura
                if (objDocumentoElectronico.TipoDocumento == Catalogo_01_TipoDocumento.Factura)
                {
                    //Validamos que la serie del comprobante corresponda al tipo de documento
                    if (objDocumentoElectronico.Serie.Substring(0, 1) != "F")
                    {
                        throw new Exception("La serie ingresada no corresponde a factura, toda serie de factura debe empezar con la letra F");
                    }

                    //Validamos que el cliente sea un juridico ya que el comprobante es una factura
                    if (objDocumentoElectronico.Receptor.TipoDocumento != Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("No puede emitir una factura a un cliente con tipo de documento diferente a ruc");
                    }

                    //Validamos que que se haya ingresado el número de ruc
                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 11)
                    {
                        throw new Exception("El nº ruc del cliente no tiene 11 dígitos");
                    }

                    //Validamos que el número ruc tenga un formato válido
                    if (RUCValido(objDocumentoElectronico.Receptor.NroDocumento) == false)
                    {
                        throw new Exception("El nº de ruc del cliente no tiene un formato válido para SUNAT");
                    }

                    //Validamos que se haya ingresado la Razón Social
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar la razón social del cliente a quien se emite el comprobante");
                    }
                }
                //Cuando es boleta
                else if (objDocumentoElectronico.TipoDocumento == Catalogo_01_TipoDocumento.Boleta)
                {
                    //Validamos que la serie del comprobante corresponda al tipo de documento
                    if (objDocumentoElectronico.Serie.Substring(0, 1) != "B")
                    {
                        throw new Exception("La serie ingresada no corresponde a boleta, toda serie de boleta debe empezar con la letra B");
                    }

                    //Validamos que el cliente no sea un juridico ya que el comprobante es una boleta
                    if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("El tipo de documento del cliente a quien se emite el comprobante tiene tipo de documento ruc, no se puede emitir una boleta a un cliente jurídico");
                    }

                    //Validamos si el comprobante tiene un monto mayor a 700 soles para verificar los datos del cliente a quien se le emite el comprobante
                    if (objDocumentoElectronico.TotalVenta >= 700)
                    {
                        //Validamos que se haya ingresado el tipo de documento
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El codigo " + objDocumentoElectronico.Receptor.TipoDocumento + " no pertenece a ningún tipo de documento del catálogo 6");
                        }
                        else //Cuando es valido
                        {
                            //Cuando es Dni
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                            {
                                //Validamos que tenga 8 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                {
                                    throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de DNI debe tener 8 Dígitos");
                                }
                            }
                            //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                            {
                                //Validamos que tenga mínimo 5 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                {
                                    throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de nro de documento debe tener al menos 5 Dígitos");
                                }
                            }
                            //Cuando es NoDomiciliadoSinRuc
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                throw new Exception("Toda boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El tipo de documento no puede ser no domiciliado sin ruc");
                            }
                        }
                    }
                    //Validamos si el comprobante ha llenado un dato ya el tipo de documento o nro de documento para validar que ambos esten llenados
                    else if ((objDocumentoElectronico.Receptor.TipoDocumento != null && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "" && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "-") ||
                            (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != ""))
                    {
                        //Cuando no se ingresó el tipo de documento válido
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            //Validamos que se haya ingresado un nº de documento
                            if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                            {
                                throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero no ha específicado un tipo de documento válido del catalogo 6");
                            }
                        }
                        else //Cuando se ingresó un tipo de documento válido
                        {
                            //Verificamos si el tipo de documento es no domiciliado sin ruc
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                //Validamos que no se haya ingresado nro de documento
                                if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                                {
                                    throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero ha especificado como tipo de documento No Domiciliado Sin Ruc");
                                }
                            }
                            else //Cuando es diferente a no domiciliado sin ruc
                            {
                                //Cuando es Dni
                                if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                                {
                                    //Validamos que tenga 8 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                    {
                                        throw new Exception("El nº de DNI del cliente debe tener 8 Dígitos");
                                    }
                                }
                                //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                                else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                                {
                                    //Validamos que tenga mínimo 5 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                    {
                                        throw new Exception("El nº de nro de documento del cliente debe tener al menos 5 Dígitos");
                                    }
                                }
                            }
                        }
                    }

                    //Validamos que se haya ingresado los apellidos y nombres
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar los apellidos y nombres del cliente a quien se emite el comprobante");
                    }
                }

                //Validamos que el comprobante tenga detalles
                if (objDocumentoElectronico.Items == null || objDocumentoElectronico.Items.Count == 0)
                {
                    throw new Exception("El comprobante no tiene detalles");
                }


                //Validamos el detalle de los comprobantes
                string Errores = "";
                foreach (DocumentoElectronicoDetalle Item in objDocumentoElectronico.Items)
                {
                    //Titulo
                    string Titulo = "\n\n\r***ITEM Nº " + Item.Id + "***";
                    //Validamos que el item no este repetido
                    if (objDocumentoElectronico.Items.FindAll(I => I.Id == Item.Id).Count() > 1)
                    {
                        Errores += "\n\r-El nº de item se repite 2 o más veces";
                    }

                    //Validamos que el detalle tenga cantidad mayor
                    if (Item.Cantidad <= 0)
                    {
                        Errores += "\n\r-La cantidad ingresada es menor o igual a cero (0)";
                    }

                    //Validamos que el detalle tenga descripcion diferente a vacío
                    if (Item.Descripcion == null || Item.Descripcion.Trim() == "")
                    {
                        Errores += "\n\r-No ingresó la descripción";
                    }

                    //Validamos el tipo de operacion
                    if (Item.TipoPrecio != Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV
                        && Item.TipoPrecio != Catalogo_16_TipoPrecioVentaUnitario.ValorReferencialUnitario_OperacionesNoOnerosas)
                    {
                        Errores += "\n\r-No se específico el tipo de precio (precio unitario incluye igv o valor referencial unitario operación no onerosa - Catálogo 16)";
                    }
                }

                //Validamos si hay errores en los detalles
                if (Errores != "")
                {
                    throw new Exception("Existen los siguientes errores: " + Errores);
                }

                //Validamos que el comprobante tenga alguno de los totales mayores a cero 0
                if (objDocumentoElectronico.Gravadas == 0
                    && objDocumentoElectronico.Exoneradas == 0
                    && objDocumentoElectronico.Inafectas == 0
                    && objDocumentoElectronico.Gratuitas == 0)
                {
                    throw new Exception("El comprobante tiene valor cero (0) en todos los totales (gravadas, exoneradas, inafectas y gratuitas), debe indicar un valor mayor a cero (0) en al menos uno de los totales");
                }

                //Validamos que si existe un monto gravado superior a cero (0) debe existir un monto de igv mayor a cero (0)
                if (objDocumentoElectronico.Gravadas > 0 && objDocumentoElectronico.TotalIgv <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto gravado pero no tiene monto de igv");
                }
                //Validamos que si existe un monto de igv superior a cero (0) debe existir un monto gravado mayor a cero (0)
                else if (objDocumentoElectronico.TotalIgv > 0 && objDocumentoElectronico.Gravadas <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto de igv pero no tiene monto gravado");
                }

                //Validamos que el monto total del comprobante sea igual a la siguiente operacion (gravados + inafectos + exonerados - Descuento Global + TotalIgv + TotalIsc + TotalOtrosTributos)
                decimal TotalComprobante = objDocumentoElectronico.Gravadas +
                                            objDocumentoElectronico.Inafectas +
                                            objDocumentoElectronico.Exoneradas -
                                            objDocumentoElectronico.DescuentoGlobal +
                                            objDocumentoElectronico.TotalIgv +
                                            objDocumentoElectronico.TotalIsc +
                                            objDocumentoElectronico.TotalOtrosTributos;
                if (objDocumentoElectronico.TotalVenta != TotalComprobante)
                {
                    throw new Exception("El total de venta del comprobante no coincide con la siguiente operación (gravada + exonerada + inafecta - Descuento global + TotalIgv + TotalIsc + Total Otros Tributos) ");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        public DocumentoElectronico Generar_NotaCredito(DocumentoElectronico objDocumentoElectronico)
        {
            try
            {
                //Validamos que el tipo de documento sea nota de credito
                if (objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.NotaCredito)
                {
                    throw new Exception("El documento enviado no es una nota de crédito, verifique el tipo de documento");
                }

                //Validamos el correlativo
                if (objDocumentoElectronico.Correlativo <= 0)
                {
                    throw new Exception("El correlativo de la nota de crédito no puede ser cero (0).");
                }

                //Validamos que el tipo de moneda del comprobante sea SOLES
                if (objDocumentoElectronico.Moneda != Catalogo_02_TipoMoneda.Soles)
                {
                    throw new Exception("EMTRAFESA no emite comprobantes con tipo de moneda distinto a SOLES.");
                }

                //Validamos que existan comprobantes afectados
                if (objDocumentoElectronico.Relacionados == null || objDocumentoElectronico.Relacionados.Count == 0)
                {
                    throw new Exception("La nota de crédito no tiene datos del comprobante afectado");
                }

                //Validamos que el comprobante afecte solo a un comprobante
                if (objDocumentoElectronico.Relacionados.Count > 1)
                {
                    throw new Exception("La nota de crédito no puede afectar a más de un comprobante");
                }

                //Validamos que la nota de credito tenga la serie correcta para el tipo de documento que afecta.
                if (objDocumentoElectronico.Serie.Substring(0, 1) == "B") //Cuando es serie de boleta
                {
                    //Validamos que el cliente no sea un juridico ya que el comprobante es una boleta
                    if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("El tipo de documento del cliente a quien se emite la nota de crédito tiene tipo de documento ruc, no se puede emitir una nota de crédito que afecte a una boleta a un cliente jurídico");
                    }

                    //Validamos si el comprobante tiene un monto mayor a 700 soles para verificar los datos del cliente a quien se le emite el comprobante
                    if (objDocumentoElectronico.TotalVenta >= 700)
                    {
                        //Validamos que se haya ingresado el tipo de documento
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            throw new Exception("Toda comprobante con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El codigo " + objDocumentoElectronico.Receptor.TipoDocumento + " no pertenece a ningún tipo de documento del catálogo 6");
                        }
                        else //Cuando es valido
                        {
                            //Cuando es Dni
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                            {
                                //Validamos que tenga 8 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                {
                                    throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de DNI debe tener 8 Dígitos");
                                }
                            }
                            //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                            {
                                //Validamos que tenga mínimo 5 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                {
                                    throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de nro de documento debe tener al menos 5 Dígitos");
                                }
                            }
                            //Cuando es NoDomiciliadoSinRuc
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El tipo de documento no puede ser no domiciliado sin ruc");
                            }
                        }
                    }
                    //Validamos si el comprobante ha llenado un dato ya el tipo de documento o nro de documento para validar que ambos esten llenados
                    else if ((objDocumentoElectronico.Receptor.TipoDocumento != null && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "" && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "-") ||
                            (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != ""))
                    {
                        //Cuando no se ingresó el tipo de documento válido
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            //Validamos que se haya ingresado un nº de documento
                            if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                            {
                                throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero no ha específicado un tipo de documento válido del catalogo 6");
                            }
                        }
                        else //Cuando se ingresó un tipo de documento válido
                        {
                            //Verificamos si el tipo de documento es no domiciliado sin ruc
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                //Validamos que no se haya ingresado nro de documento
                                if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                                {
                                    throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero ha especificado como tipo de documento No Domiciliado Sin Ruc");
                                }
                            }
                            else //Cuando es diferente a no domiciliado sin ruc
                            {
                                //Cuando es Dni
                                if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                                {
                                    //Validamos que tenga 8 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                    {
                                        throw new Exception("El nº de DNI del cliente debe tener 8 Dígitos");
                                    }
                                }
                                //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                                else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                                {
                                    //Validamos que tenga mínimo 5 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                    {
                                        throw new Exception("El nº de nro de documento del cliente debe tener al menos 5 Dígitos");
                                    }
                                }
                            }
                        }
                    }

                    //Validamos que se haya ingresado los apellidos y nombres
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar los apellidos y nombres del cliente a quien se emite la nota de crédito.");
                    }

                    //Validamos que el comprobante afectado sea boleta
                    if (objDocumentoElectronico.Relacionados[0].TipoDocumento != Catalogo_01_TipoDocumento.Boleta)
                    {
                        throw new Exception("La nota de crédito que pretende generar tiene serie de boleta, pero el comprobante afectado por la nota de crédito no es boleta");
                    }

                    //Validamos que el comprobante afectado tenga serie electronica y si es electronica que sea serie de boleta
                    char caracterInicial = Convert.ToChar(objDocumentoElectronico.Relacionados[0].NroDocumento.Substring(0, 1)); //Extraemos el caracter inicial de la serie.
                    if (char.IsNumber(caracterInicial) == false)
                    {
                        if (caracterInicial != 'B')
                        {
                            throw new Exception("La nota de crédito que pretende generar tiene serie de boleta, pero el comprobante afectado tiene una serie electrónica que no pertenece a boleta toda serie electrónica de boleta debe empezar con la letra B");
                        }
                    }
                }
                else if (objDocumentoElectronico.Serie.Substring(0, 1) == "F") //Cuando es serie de factura
                {
                    //Validamos que el cliente sea un juridico ya que la nota de crédito tiene serie de factura
                    if (objDocumentoElectronico.Receptor.TipoDocumento != Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("No puede emitir una nota de crédito que afecte a factura a un cliente con tipo de documento diferente a ruc");
                    }

                    //Validamos que que se haya ingresado el número de ruc
                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 11)
                    {
                        throw new Exception("El nº ruc del cliente no tiene 11 dígitos");
                    }

                    //Validamos que el número ruc tenga un formato válido
                    if (RUCValido(objDocumentoElectronico.Receptor.NroDocumento) == false)
                    {
                        throw new Exception("El nº de ruc del cliente no tiene un formato válido para SUNAT");
                    }

                    //Validamos que se haya ingresado la Razón Social
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar la razón social del cliente a quien se emite el comprobante");
                    }

                    //Validamos que el comprobante afectado sea boleta
                    if (objDocumentoElectronico.Relacionados[0].TipoDocumento != Catalogo_01_TipoDocumento.Factura)
                    {
                        throw new Exception("La nota de crédito que pretende generar tiene serie de factura, pero el comprobante afectado por la nota de crédito no es factura");
                    }

                    //Validamos que el comprobante afectado tenga serie electronica y si es electronica que sea serie de boleta
                    char caracterInicial = Convert.ToChar(objDocumentoElectronico.Relacionados[0].NroDocumento.Substring(0, 1)); //Extraemos el caracter inicial de la serie.
                    if (char.IsNumber(caracterInicial) == false)
                    {
                        if (caracterInicial != 'F')
                        {
                            throw new Exception("La nota de crédito que pretende generar tiene serie de factura, pero el comprobante afectado tiene una serie electrónica que no pertenece a factura toda serie electrónica de factura debe empezar con la letra F");
                        }
                    }
                }
                else //Cuando no es ni boleta ni factura
                {
                    throw new Exception("La nota de crédito que pretende generar no tiene serie electrónica, cuando la nota de crédito afecte a una boleta debe usar una serie que empiece con B, cuando la nota de crédito afecte a una factura debe usar una serie que empiece con F");
                }

                //Validamos que el comprobante tenga alguno de los totales mayores a cero 0
                if (objDocumentoElectronico.Gravadas == 0
                    && objDocumentoElectronico.Exoneradas == 0
                    && objDocumentoElectronico.Inafectas == 0
                    && objDocumentoElectronico.Gratuitas == 0)
                {
                    throw new Exception("El comprobante tiene valor cero (0) en todos los totales (gravadas, exoneradas, inafectas y gratuitas), debe indicar un valor mayor a cero (0) en al menos uno de los totales");
                }

                //Validamos que si existe un monto gravado superior a cero (0) debe existir un monto de igv mayor a cero (0)
                if (objDocumentoElectronico.Gravadas > 0 && objDocumentoElectronico.TotalIgv <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto gravado pero no tiene monto de igv");
                }
                //Validamos que si existe un monto de igv superior a cero (0) debe existir un monto gravado mayor a cero (0)
                else if (objDocumentoElectronico.TotalIgv > 0 && objDocumentoElectronico.Gravadas <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto de igv pero no tiene monto gravado");
                }

                //Validamos que el monto total del comprobante sea igual a la siguiente operacion (gravados + inafectos + exonerados - Descuento Global + TotalIgv + TotalIsc + TotalOtrosTributos)
                decimal TotalComprobante = objDocumentoElectronico.Gravadas +
                                            objDocumentoElectronico.Inafectas +
                                            objDocumentoElectronico.Exoneradas -
                                            objDocumentoElectronico.DescuentoGlobal +
                                            objDocumentoElectronico.TotalIgv +
                                            objDocumentoElectronico.TotalIsc +
                                            objDocumentoElectronico.TotalOtrosTributos;
                if (objDocumentoElectronico.TotalVenta != TotalComprobante)
                {
                    throw new Exception("El total de venta del comprobante no coincide con la siguiente operación (gravada + exonerada + inafecta - Descuento global + TotalIgv + TotalIsc + Total Otros Tributos)");
                }



                //Variable para guardar los datos a adicionales propios de SUNAT
                List<DatoAdicional> objArrDatoAdicional = new List<DatoAdicional>();

                //Recorremos los datos adicionales para validar que no haya algun dato no perteneciente al catalogo de sunat para ponerlo como dato adicional interno
                foreach (DatoAdicional objDatoAdicional in objDocumentoElectronico.DatoAdicionales)
                {
                    //Validamos si el Codigo del dato adicional esta dentro del catalogo 15, sino lo agregamos en la lista de datos adicionales internos
                    if (Catalogo_15_DatoAdicional.Validar_Codigo(objDatoAdicional.Codigo))
                    {
                        objArrDatoAdicional.Add
                        (
                            new DatoAdicional
                            {
                                Codigo = objDatoAdicional.Codigo,
                                Valor = objDatoAdicional.Valor
                            }
                        );
                    }
                    else //Lo agregamos a la lista de datos adicionales internos
                    {
                        //Validamos que la lista de datos adicional interno este inicializada sino la inicializamos
                        if (objDocumentoElectronico.DatoAdicionales_Internos == null) objDocumentoElectronico.DatoAdicionales_Internos = new List<DatoAdicional>();

                        //Agregamos el datos adicional internos
                        objDocumentoElectronico.DatoAdicionales_Internos.Add
                        (
                            new DatoAdicional
                            {
                                Codigo = objDatoAdicional.Codigo,
                                Valor = objDatoAdicional.Valor
                            }
                        );
                    }
                }


                //Actualizamos los datos adicional según Sunat
                objDocumentoElectronico.DatoAdicionales = objArrDatoAdicional;

                //Generamos el Serializador que es la clase que nos permite genera el xml, comprimirlo el xml y descomprimir el cdr
                var objSerializador = Crear_Serializador(true);


                //Creamos un objeto de tipo invoice (que es la que contiene toda la estructura xml) 
                //usando la clase Ges.FacturaElectronica.Generador y usando el objeto Documento Electronico
                var objEstructura_NotaCredito = Generador.GenerarCreditNote(objDocumentoElectronico);


                //Generamos el xml en string firmado debidamente
                objDocumentoElectronico.ComprobanteXml_Base64String = objSerializador.GenerarXml(objEstructura_NotaCredito, true);
                objDocumentoElectronico.DigestValue = objSerializador.DigestValue;
                objDocumentoElectronico.Generado = true;

                //Retornamos el mismo Facturacion.Models.DocumentoElectronico con los datos del xml
                return objDocumentoElectronico;
            }
            catch (Exception Ex)
            {
                throw new Exception("Facturación Electrónica - " + Ex.Message, Ex.InnerException);
            }
        }


        private void FacturacionElectronica_Validar_Datos_NotaCredito(DocumentoElectronico objDocumentoElectronico, bool Excluir_Validar_Existe)
        {
            try
            {
                //Validamos que el tipo de documento sea nota de credito
                if (objDocumentoElectronico.TipoDocumento != Catalogo_01_TipoDocumento.NotaCredito)
                {
                    throw new Exception("El documento enviado no es una nota de crédito, verifique el tipo de documento");
                }

                //Validamos el correlativo
                if (objDocumentoElectronico.Correlativo <= 0)
                {
                    throw new Exception("El correlativo de la nota de crédito no puede ser cero (0).");
                }

                //Validamos que el tipo de moneda del comprobante sea SOLES
                if (objDocumentoElectronico.Moneda != Catalogo_02_TipoMoneda.Soles)
                {
                    throw new Exception("EMTRAFESA no emite comprobantes con tipo de moneda distinto a SOLES.");
                }

                //Validamos que existan comprobantes afectados
                if (objDocumentoElectronico.Relacionados == null || objDocumentoElectronico.Relacionados.Count == 0)
                {
                    throw new Exception("La nota de crédito no tiene datos del comprobante afectado");
                }

                //Validamos que el comprobante afecte solo a un comprobante
                if (objDocumentoElectronico.Relacionados.Count > 1)
                {
                    throw new Exception("La nota de crédito no puede afectar a más de un comprobante");
                }

                //Validamos que la nota de credito tenga la serie correcta para el tipo de documento que afecta.
                if (objDocumentoElectronico.Serie.Substring(0, 1) == "B") //Cuando es serie de boleta
                {
                    //Validamos que el cliente no sea un juridico ya que el comprobante es una boleta
                    if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("El tipo de documento del cliente a quien se emite la nota de crédito tiene tipo de documento ruc, no se puede emitir una nota de crédito que afecte a una boleta a un cliente jurídico");
                    }

                    //Validamos si el comprobante tiene un monto mayor a 700 soles para verificar los datos del cliente a quien se le emite el comprobante
                    if (objDocumentoElectronico.TotalVenta >= 700)
                    {
                        //Validamos que se haya ingresado el tipo de documento
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            throw new Exception("Toda comprobante con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El codigo " + objDocumentoElectronico.Receptor.TipoDocumento + " no pertenece a ningún tipo de documento del catálogo 6");
                        }
                        else //Cuando es valido
                        {
                            //Cuando es Dni
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                            {
                                //Validamos que tenga 8 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                {
                                    throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de DNI debe tener 8 Dígitos");
                                }
                            }
                            //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                            {
                                //Validamos que tenga mínimo 5 dígitos
                                if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                {
                                    throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El nº de nro de documento debe tener al menos 5 Dígitos");
                                }
                            }
                            //Cuando es NoDomiciliadoSinRuc
                            else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                throw new Exception("Toda nota de crédito que afecte a boleta con monto total igual o superior a 700 soles debe identificar al cliente con tipo y número de documento " +
                                                "\n\r-El tipo de documento no puede ser no domiciliado sin ruc");
                            }
                        }
                    }
                    //Validamos si el comprobante ha llenado un dato ya el tipo de documento o nro de documento para validar que ambos esten llenados
                    else if ((objDocumentoElectronico.Receptor.TipoDocumento != null && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "" && objDocumentoElectronico.Receptor.TipoDocumento.Trim() != "-") ||
                            (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != ""))
                    {
                        //Cuando no se ingresó el tipo de documento válido
                        if (Catalogo_06_TipoDocumentoIdentidad.EsValido(objDocumentoElectronico.Receptor.TipoDocumento) == false)
                        {
                            //Validamos que se haya ingresado un nº de documento
                            if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                            {
                                throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero no ha específicado un tipo de documento válido del catalogo 6");
                            }
                        }
                        else //Cuando se ingresó un tipo de documento válido
                        {
                            //Verificamos si el tipo de documento es no domiciliado sin ruc
                            if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.NoDomiciliadoSinRuc)
                            {
                                //Validamos que no se haya ingresado nro de documento
                                if (objDocumentoElectronico.Receptor.NroDocumento != null && objDocumentoElectronico.Receptor.NroDocumento.Trim() != "")
                                {
                                    throw new Exception("Ha ingresado el siguiente nº de documento " + objDocumentoElectronico.Receptor.NroDocumento + " del cliente pero ha especificado como tipo de documento No Domiciliado Sin Ruc");
                                }
                            }
                            else //Cuando es diferente a no domiciliado sin ruc
                            {
                                //Cuando es Dni
                                if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Dni)
                                {
                                    //Validamos que tenga 8 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 8)
                                    {
                                        throw new Exception("El nº de DNI del cliente debe tener 8 Dígitos");
                                    }
                                }
                                //Cuando es Carnet Extranjeria, Pasaporte, CedDiplomaticaDeIdentidad
                                else if (objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.Pasaporte
                                    || objDocumentoElectronico.Receptor.TipoDocumento == Catalogo_06_TipoDocumentoIdentidad.CedDiplomaticaDeIdentidad)
                                {
                                    //Validamos que tenga mínimo 5 dígitos
                                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length < 5)
                                    {
                                        throw new Exception("El nº de nro de documento del cliente debe tener al menos 5 Dígitos");
                                    }
                                }
                            }
                        }
                    }

                    //Validamos que se haya ingresado los apellidos y nombres
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar los apellidos y nombres del cliente a quien se emite la nota de crédito.");
                    }

                    //Validamos que el comprobante afectado sea boleta
                    if (objDocumentoElectronico.Relacionados[0].TipoDocumento != Catalogo_01_TipoDocumento.Boleta)
                    {
                        throw new Exception("La nota de crédito que pretende generar tiene serie de boleta, pero el comprobante afectado por la nota de crédito no es boleta");
                    }

                    //Validamos que el comprobante afectado tenga serie electronica y si es electronica que sea serie de boleta
                    char caracterInicial = Convert.ToChar(objDocumentoElectronico.Relacionados[0].NroDocumento.Substring(0, 1)); //Extraemos el caracter inicial de la serie.
                    if (char.IsNumber(caracterInicial) == false)
                    {
                        if (caracterInicial != 'B')
                        {
                            throw new Exception("La nota de crédito que pretende generar tiene serie de boleta, pero el comprobante afectado tiene una serie electrónica que no pertenece a boleta toda serie electrónica de boleta debe empezar con la letra B");
                        }
                    }
                }
                else if (objDocumentoElectronico.Serie.Substring(0, 1) == "F") //Cuando es serie de factura
                {
                    //Validamos que el cliente sea un juridico ya que la nota de crédito tiene serie de factura
                    if (objDocumentoElectronico.Receptor.TipoDocumento != Catalogo_06_TipoDocumentoIdentidad.Ruc)
                    {
                        throw new Exception("No puede emitir una nota de crédito que afecte a factura a un cliente con tipo de documento diferente a ruc");
                    }

                    //Validamos que que se haya ingresado el número de ruc
                    if (objDocumentoElectronico.Receptor.NroDocumento == null || objDocumentoElectronico.Receptor.NroDocumento.Trim().Length != 11)
                    {
                        throw new Exception("El nº ruc del cliente no tiene 11 dígitos");
                    }

                    //Validamos que el número ruc tenga un formato válido
                    if (RUCValido(objDocumentoElectronico.Receptor.NroDocumento) == false)
                    {
                        throw new Exception("El nº de ruc del cliente no tiene un formato válido para SUNAT");
                    }

                    //Validamos que se haya ingresado la Razón Social
                    if (objDocumentoElectronico.Receptor.NombreLegal == null || objDocumentoElectronico.Receptor.NombreLegal.Trim() == "")
                    {
                        throw new Exception("Olvidó ingresar la razón social del cliente a quien se emite el comprobante");
                    }

                    //Validamos que el comprobante afectado sea boleta
                    if (objDocumentoElectronico.Relacionados[0].TipoDocumento != Catalogo_01_TipoDocumento.Factura)
                    {
                        throw new Exception("La nota de crédito que pretende generar tiene serie de factura, pero el comprobante afectado por la nota de crédito no es factura");
                    }

                    //Validamos que el comprobante afectado tenga serie electronica y si es electronica que sea serie de boleta
                    char caracterInicial = Convert.ToChar(objDocumentoElectronico.Relacionados[0].NroDocumento.Substring(0, 1)); //Extraemos el caracter inicial de la serie.
                    if (char.IsNumber(caracterInicial) == false)
                    {
                        if (caracterInicial != 'F')
                        {
                            throw new Exception("La nota de crédito que pretende generar tiene serie de factura, pero el comprobante afectado tiene una serie electrónica que no pertenece a factura toda serie electrónica de factura debe empezar con la letra F");
                        }
                    }
                }
                else //Cuando no es ni boleta ni factura
                {
                    throw new Exception("La nota de crédito que pretende generar no tiene serie electrónica, cuando la nota de crédito afecte a una boleta debe usar una serie que empiece con B, cuando la nota de crédito afecte a una factura debe usar una serie que empiece con F");
                }

                //Validamos que el comprobante tenga alguno de los totales mayores a cero 0
                if (objDocumentoElectronico.Gravadas == 0
                    && objDocumentoElectronico.Exoneradas == 0
                    && objDocumentoElectronico.Inafectas == 0
                    && objDocumentoElectronico.Gratuitas == 0)
                {
                    throw new Exception("El comprobante tiene valor cero (0) en todos los totales (gravadas, exoneradas, inafectas y gratuitas), debe indicar un valor mayor a cero (0) en al menos uno de los totales");
                }

                //Validamos que si existe un monto gravado superior a cero (0) debe existir un monto de igv mayor a cero (0)
                if (objDocumentoElectronico.Gravadas > 0 && objDocumentoElectronico.TotalIgv <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto gravado pero no tiene monto de igv");
                }
                //Validamos que si existe un monto de igv superior a cero (0) debe existir un monto gravado mayor a cero (0)
                else if (objDocumentoElectronico.TotalIgv > 0 && objDocumentoElectronico.Gravadas <= 0)
                {
                    throw new Exception("El comprobante tiene ingresado un monto de igv pero no tiene monto gravado");
                }

                //Validamos que el monto total del comprobante sea igual a la siguiente operacion (gravados + inafectos + exonerados - Descuento Global + TotalIgv + TotalIsc + TotalOtrosTributos)
                decimal TotalComprobante = objDocumentoElectronico.Gravadas +
                                            objDocumentoElectronico.Inafectas +
                                            objDocumentoElectronico.Exoneradas -
                                            objDocumentoElectronico.DescuentoGlobal +
                                            objDocumentoElectronico.TotalIgv +
                                            objDocumentoElectronico.TotalIsc +
                                            objDocumentoElectronico.TotalOtrosTributos;
                if (objDocumentoElectronico.TotalVenta != TotalComprobante)
                {
                    throw new Exception("El total de venta del comprobante no coincide con la siguiente operación (gravada + exonerada + inafecta - Descuento global + TotalIgv + TotalIsc + Total Otros Tributos)");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        #endregion [Facturacion Electronica]

    }
}