﻿using BimManager.Sunat.Entidad.Estructuras;
using Ionic.Zip;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BimManager.Sunat.Tools
{
    public class Serializador
    {
        /// <summary>
        /// Cadena Base64 del certificado Digital
        /// </summary>
        public string RutaCertificadoDigital_Base64String { get; set; }
        /// <summary>
        /// Si el certificado digital tiene Clave se coloca aquí
        /// </summary>
        public string PasswordCertificado { get; set; }
        /// <summary>
        /// Hash de la Firma del Documento
        /// </summary>
        public string DigestValue { get; set; }
        /// <summary>
        /// Tipo de Documento a generarse (Boleta, factura, notas de credito y debito = 1, resumenes y comunicacion de baja = 0)
        /// </summary>
        public int TipoDocumento { get; set; }

        /// <summary>
        /// Resumen de la Firma
        /// </summary>
        public string ValorFirma { get; set; }

        public Serializador()
        {
            TipoDocumento = 1; // Factura es Por Defecto.
        }


        /// <summary>
        /// Generar el XML en base a una Clase con el atributo Serializable
        /// </summary>
        /// <typeparam name="T">Clase a serializar</typeparam>
        /// <param name="request">Instancia de la Clase</param>
        /// <param name="nombreArchivo">Nombre del archivo resultante</param>
        /// <returns>Devuelve la ruta del Archivo generado</returns>
        public string GenerarXmlFisico<T>(T request, string rutaArchivo, string nombreArchivo)
        {
            var serializer = new XmlSerializer(typeof(T));
            //var filename = $"{Directory.GetCurrentDirectory()}\\{nombreArchivo}.xml";
            var filename = $"{rutaArchivo}\\{nombreArchivo}.xml";

            using (var writer = new StreamWriter(filename, false, Encoding.GetEncoding("ISO-8859-1")))
            {
                serializer.Serialize(writer, request);
            }

            return filename;
        }


        /// <summary>
        /// Genera el XML basado en una clase con el atributo Serializable y retorna el xml en Base64String
        /// </summary>
        /// <typeparam name="T">Clase a serializar</typeparam>
        /// <param name="objectToSerialize">Instancia de la Clase</param>
        /// <returns>Devuelve una cadena Base64 del archivo XML</returns>
        public string GenerarXml<T>(T objectToSerialize, bool Firmado)
        {
            var serializer = new XmlSerializer(typeof(T));
            string resultado;

            using (var memStr = new MemoryStream())
            {
                using (var stream = new StreamWriter(memStr, Encoding.GetEncoding("ISO-8859-1")))
                {
                    serializer.Serialize(stream, objectToSerialize);

                }

                //Validamos si al generar el XML se debe firmar o no
                if (Firmado) // Con firma.
                {
                    resultado = FirmarXml(Convert.ToBase64String(memStr.ToArray()));
                }
                else // Sin Firma.
                {
                    resultado = Convert.ToBase64String(memStr.ToArray());
                }
            }
            return resultado;
        }


        /// <summary>
        /// Genera el ZIP del XML basandose en la trama del XML y retorna el zip en Base64String
        /// </summary>
        /// <param name="tramaXml">Cadena Base64 con el contenido del XML</param>
        /// <param name="nombreArchivo">Nombre del archivo ZIP</param>
        /// <returns>Devuelve Cadena Base64 del archizo ZIP</returns>
        public string GenerarZip(string tramaXml, string nombreArchivo)
        {
            var memOrigen = new MemoryStream(Convert.FromBase64String(tramaXml));
            var memDestino = new MemoryStream();
            string resultado;

            using (var fileZip = new ZipFile($"{nombreArchivo}.zip"))
            {
                fileZip.AddEntry($"{nombreArchivo}.xml", memOrigen);
                fileZip.Save(memDestino);
                resultado = Convert.ToBase64String(memDestino.ToArray());
            }
            // Liberamos memoria RAM.
            memOrigen.Close();
            memDestino.Close();

            return resultado;
        }

        /// <summary>
        /// Descomprime el Zip de repuesta de la SUNAT
        /// </summary>
        /// <param name="Ruta_Nombre_Del_Archivo_Zip">Ruta de la ubicacion y nombre del archivo zip (Ejemplo D:\\Carpeta\\Archivo.zip </param>
        /// <param name="Ruta_Descompresion">Ruta donde se descomprimira el archivo zip (Ejemplo D:\\Carpeta )</param>
        /// <returns></returns>
        public void DescomprimirZip_Respuesta(string Ruta_Nombre_Del_Archivo_Zip, string Ruta_Descompresion)
        {
            ZipFile objZipFile = new ZipFile(Ruta_Nombre_Del_Archivo_Zip);
            objZipFile.ExtractAll(Ruta_Descompresion, ExtractExistingFileAction.DoNotOverwrite);
            objZipFile.Dispose();
        }

        public string FirmarXml(string tramaXml)
        {

            // Vamos a firmar el XML con la ruta del certificado que está como serializado.

            var certificate = new X509Certificate2();
            certificate.Import(Convert.FromBase64String(RutaCertificadoDigital_Base64String),
                PasswordCertificado, X509KeyStorageFlags.MachineKeySet);

            var xmlDoc = new XmlDocument();

            string resultado;

            using (var documento = new MemoryStream(Convert.FromBase64String(tramaXml)))
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(documento);
                int tipo;

                if (TipoDocumento == 1 || TipoDocumento == 2 || TipoDocumento == 3 || TipoDocumento == 4)
                    tipo = 2;
                else
                    tipo = 0;

                var nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", EspacioNombres.ext)
                    .Item(tipo);
                if (nodoExtension == null)
                    throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");
                nodoExtension.RemoveAll();

                // Creamos el objeto SignedXml.
                var signedXml = new SignedXml(xmlDoc) { SigningKey = (RSA)certificate.PrivateKey };
                signedXml.SigningKey = certificate.PrivateKey;
                var xmlSignature = signedXml.Signature;

                var env = new XmlDsigEnvelopedSignatureTransform();

                var reference = new Reference(string.Empty);
                reference.AddTransform(env);
                xmlSignature.SignedInfo.AddReference(reference);

                var keyInfo = new KeyInfo();
                var x509Data = new KeyInfoX509Data(certificate);

                x509Data.AddSubjectName(certificate.Subject);

                keyInfo.AddClause(x509Data);
                xmlSignature.KeyInfo = keyInfo;
                xmlSignature.Id = "signEMTRAFESAC";
                signedXml.ComputeSignature();

                // Recuperamos el valor Hash de la firma para este documento.
                if (reference.DigestValue != null)
                {
                    DigestValue = Convert.ToBase64String(reference.DigestValue);
                }
                ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);

                nodoExtension.AppendChild(signedXml.GetXml());

                var settings = new XmlWriterSettings() { Encoding = Encoding.GetEncoding("ISO-8859-1"), Indent = true };

                using (var memDoc = new MemoryStream())
                {

                    using (var writer = XmlWriter.Create(memDoc, settings))
                    {
                        xmlDoc.WriteTo(writer);
                    }

                    resultado = Convert.ToBase64String(memDoc.ToArray());

                }
            }

            return resultado;
        }
    }
}
