using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using System.Web.Hosting;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;
using System.Drawing.Imaging;
using Gma.QrCodeNet.Encoding.Windows.Render;
using BimManager.Sunat.Entidad.Constantes;

namespace BimManager.Sunat.Entidad.RepresentacionImpresa
{
    [Serializable]
    public class ComprobanteElectronico
    {
        #region[Variables y procedimientos para impresión directa]
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szDocumentoNombre, string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = szDocumentoNombre;
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szFileName, szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szDocumentoNombre, string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szDocumentoNombre, szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }


        private string Buscar_Impresora(string NombreImpresora)
        {
            try
            {
                bool Existe = false; //Variable de bandera para indicar si la impresora de codigo de barras existe

                //Variable para guardar el nombre completo de la impresora encontrada (puede de que sea un nombre de un a impresora en red);
                string NombreImpresoraEncontrada = "";

                //Recorremos todas las impresoras instaladas para ubicar la de nombre CB que es la de codigo de barras.
                for (Int16 x = 0; x < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; x++)
                {
                    if (System.Drawing.Printing.PrinterSettings.InstalledPrinters[x].ToString().IndexOf(NombreImpresora) > -1)
                    {
                        NombreImpresoraEncontrada = System.Drawing.Printing.PrinterSettings.InstalledPrinters[x].ToString(); //Capturamos el nombre completo de la impresora (puede que sea un impresora en red)
                        Existe = true; //Indicamos que se encontro la impresora
                        break; //Salimos del bucle
                    }
                }

                //Si la bandera tiene el valor de false indica que la impresora de codigo de barras no se encontro
                if (Existe == false)
                {
                    throw new Exception("No existe un impresora instalada con nombre \"" + NombreImpresora + "\""); //Generamos una excepcion
                }

                //Si llegamos a este punto es porque si se encontró la impresora por lo que retornamos el nombre de la impresora encontrada
                return NombreImpresoraEncontrada;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        private string Logo_To_Hexadecimal(Bitmap Logo)
        {
            string stringLogo = "";
            if (Logo == null) return null;

            BitmapData data = GetBitmapData(Logo);
            System.Collections.BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(stream);

            bw.Write((char)0x1B);
            bw.Write('3');
            bw.Write((byte)24);

            while (offset < data.Height)
            {
                bw.Write((char)0x1B);
                bw.Write('*');         // bit-image mode
                bw.Write((byte)33);    // 24-dot double-density
                bw.Write(width[0]);  // width low byte
                bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }

                        bw.Write(slice);
                    }
                }
                offset += 24;
                bw.Write((char)0x0A);
            }

            bw.Flush();
            byte[] bytes = stream.ToArray();
            return stringLogo + System.Text.Encoding.Default.GetString(bytes);
        }

        private BitmapData GetBitmapData(Bitmap Logo)
        {
            //using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            using (var bitmap = Logo)
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new System.Collections.BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        private class BitmapData
        {
            public System.Collections.BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }

        private string CodigoBarras_Formato_PDF417(int columnas, int filas, int Nivel_Correccion, int ModuloAncho, int ModuloAltura, string CodigoBarras)
        {
            try
            {
                string CodigoBarras_Formato_PDF417_ = ""; //AlinearCentro;

                //Número de columnas en el área de datos (fn = 65)
                //ASCII                         GS       (        k        pL       pH       cn       fn       n (0 ≤ n ≤ 30)
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x30" + "\x41" + Dec_To_Hex(columnas);


                //Numero de filas en el área de datos (fn = 66)
                //ASCII                         GS       (        k        pL       pH       cn       fn       n (n = 0, 3 ≤ n ≤ 90)
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x30" + "\x42" + Dec_To_Hex(filas);


                //Ancho de los módulos (fn = 67)
                //ASCII                         GS       (        k        pL       pH       cn       fn       n (2 ≤ n ≤ 8)
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x30" + "\x43" + Dec_To_Hex(ModuloAncho);


                //Alto de los módulos (fn = 68)
                //ASCII                         GS       (        k        pL       pH       cn       fn       n (2 ≤ n ≤ 8)
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x30" + "\x44" + Dec_To_Hex(ModuloAltura);


                //Nivel de corrección (fn = 69)
                //ASCII                         GS       (        k        pL       pH       cn       fn       m(m=48,49) n(48≤n≤56 (when m=48 is specified), 1≤n≤40(when m = 49 is specified))
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x04" + "\x00" + "\x30" + "\x45" + "\x31" + Dec_To_Hex(Nivel_Correccion);


                //Datos del código de barras (fn = 80)
                //ASCCI                         GS       (        k        pL      pH                                                          cn       fn       m        "d1.......dk"
                //CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + CodigoBarras_Calcular_Valores_pL_pH(CodigoBarras) + "\x31" + "\x50" + "\x30" + CodigoBarras;// Función 080, almacena los datos en el área de almacenamiento del símbolo(GS(k pL pH \ x30 \ x50 \ x30 datos) 
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + CodigoBarras_Calcular_Valores_pL_pH(CodigoBarras) + "\x30" + "\x50" + "\x30" + CodigoBarras;// Función 080, almacena los datos en el área de almacenamiento del símbolo(GS(k pL pH \ x30 \ x50 \ x30 datos) 


                //Codificar e imprimir código de barras (fn = 81)
                //ASCII                         GS       (        k        pL       pH       cn       fn       m
                CodigoBarras_Formato_PDF417_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x30" + "\x51" + "\x30";


                return CodigoBarras_Formato_PDF417_;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        private string CodigoBarras_Formato_QR(int Modelo, int ModuloSize, int Nivel_Correccion, string CodigoBarras)
        {
            try
            {
                string CodigoBarras_Formato_QR_ = ""; //AlinearCentro;

                //Modelo código QR (fn = 65)
                //ASCII                     GS       (        k        pL       pH       cn       fn       n1(49, 50)           n2=0
                CodigoBarras_Formato_QR_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x31" + "\x41" + Dec_To_Hex(Modelo) + "\x00";


                //Tamaño de los módulos (fn = 67)
                //ASCII                     GS       (        k        pL       pH       cn       fn       n (1 ≤ n ≤ 16) dots
                CodigoBarras_Formato_QR_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x31" + "\x43" + Dec_To_Hex(ModuloSize);


                //Nivel de corrección (fn = 69)
                //ASCII                     GS       (        k        pL       pH       cn       fn       n(48 ≤ n ≤ 51) (48=Level L-7, 49=Level M-15, 50 Level Q-25, 51 Level H-30)
                CodigoBarras_Formato_QR_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x31" + "\x45" + Dec_To_Hex(Nivel_Correccion);


                //Datos del código de barras (fn = 80)
                //ASCCI                     GS       (        k        pL      pH                                          cn       fn       m        "d1.......dk"
                CodigoBarras_Formato_QR_ += "\x1D" + "\x28" + "\x6B" + CodigoBarras_Calcular_Valores_pL_pH(CodigoBarras) + "\x31" + "\x50" + "\x30" + CodigoBarras;// Función 080, almacena los datos en el área de almacenamiento del símbolo(GS(k pL pH \ x30 \ x50 \ x30 datos) 


                //Codificar e imprimir código de barras (fn = 81)
                //ASCII                     GS       (        k        pL       pH       cn       fn       m
                CodigoBarras_Formato_QR_ += "\x1D" + "\x28" + "\x6B" + "\x03" + "\x00" + "\x31" + "\x51" + "\x30";


                return CodigoBarras_Formato_QR_;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        private static string CodigoBarras_Calcular_Valores_pL_pH(string CodigoBarras)
        {
            //Obtenemos la longitud de caracteres del código de barras y le sumamos 3 (que son tres espacios reservados al momento de la impresión)
            decimal Length = 3 + CodigoBarras.Length;

            //Obtenemos el valor de pH, primero comprobamos que la longitud del código de barras sea mayor a 255
            decimal Heigth = 0;
            if (Length > 255)
            {
                //Cuando es mayor a 255 dividimos la longitud del código de barras entre 256
                Heigth = Length / 256;
            }
            //Al final el valor obtenido lo redondeamos hacia abajo usando la funcion Floor y lo convertimos a Entero para poder utilizar la Función Dec_To_Hex que nos retornará el valor hexadecimal del número entero enviado
            string pH = Dec_To_Hex(Convert.ToInt32(Math.Floor(Heigth)));


            //Obtenemos el valor de pL, primero comprobamos que la longitud del código de barras sea mayor a 255
            decimal Width = 0;
            if (Length > 255)
            {
                //Cuando es mayor a 255 obtenemos el residuo de la división entre la longitud del código de barras entre 256
                Width = Length % 256;
            }
            //Cuando es menos a o igual 255 simplemente asignamos el valor
            else Width = Length;

            //Al final el valor obtenido lo redondeamos hacia arriba usando la funcion Ceiling y lo convertimos a Entero para poder utilizar la Función Dec_To_Hex que nos retornará el valor hexadecimal del número entero enviado
            string pL = Dec_To_Hex(Convert.ToInt32(Math.Ceiling(Width)));

            return pL + pH;
        }


        private const string ESC = "\x1B";
        private const string GS = "\x1D";
        private const string IniciarImpresora = ESC + "@";
        private const string AlinearIzquierda = ESC + "\x61\x30";
        private const string AlinearCentro = ESC + "\x61\x31";
        private const string AlinearDerecha = ESC + "\x61\x32";
        private const string FormatoNegritaActivar = ESC + "E" + "\x01";
        private const string FormatoNegritaDesactivar = ESC + "E" + "\0";
        private const string FormatoDobleSimpleActivar = GS + "!" + "\x01";
        private const string FormatoDobleActivar = GS + "!" + "\x11";  // 2x sized text (double-high + double-wide)
        private const string FormatoDobleDesactivar = GS + "!" + "\0";


        /// <summary>
        /// Establece la tabla de caracteres a usarse en la impresión
        /// </summary>
        /// <param name="CodePage">Se recomienda usar el valor 6 que hace referencia a CodePage 860(Portuguese) y es la única que soporta los caracteres del español</param>
        /// <returns></returns>
        private string TablaDeCaracteres(int CodePage)
        {
            //ASCII ESC   t   n
            return ESC + t + Dec_To_Hex(CodePage);
        }


        //Selecciona un modo para cortar papel y ejecuta el corte de papel. 
        //ASCII                             GS       V        m(m=1,49)  n (m=66, 0≤n≤255) Solo cuando el valor de m = 66
        private const string CorteDePapel = "\x1D" + "\x56" + "\x42" + "\x00";
        //private const string CorteDePapel = ESC + "\x69";

        private const string Tab = "\x09";
        private const string D = "\x44";
        private const string I = "\x49";
        private const string S = "\x53";
        private const string P = "\x50";
        private const string t = "\x74";
        private const string x = "\x78";


        /// <summary>
        /// Retorna el comando ESC 3 n
        /// </summary>
        /// <param name="n">0≤n≤255</param>
        /// <returns></returns>
        private string Interlineado(int n)
        {
            //ASCII ESC     3        n
            return "\x1B" + "\x33" + Dec_To_Hex(n);
        }


        private string InsertarCaracteresAntesDeUnCaracter(string Texto, string CaracterIndice, string CaracterInsertar, int Longitud)
        {
            while(Texto.IndexOf(CaracterIndice) < Longitud)
            {
                Texto = Texto.Insert(Texto.IndexOf(CaracterIndice), CaracterInsertar);
            }

            return Texto;
        }



        /// <summary>
        /// Retorna una linea llena de un caracter y ancho especifico
        /// </summary>
        /// <param name="Caracter">Caracter de relleno</param>
        /// <param name="LongitudDeCaracteres">Cantidad de caracteres que tendra la linea</param>
        /// <returns></returns>
        private static string LineaLLenaDeUnCaracter(string Caracter, int LongitudDeCaracteres)
        {
            string LineaLLenaDeUnCaracter_ = "";

            for (int Caracteres = 1; Caracteres <= LongitudDeCaracteres; Caracteres++)
            {
                LineaLLenaDeUnCaracter_ += Caracter;
            }

            return LineaLLenaDeUnCaracter_;
        }


        /// <summary>
        /// Rellena a la izquierda del texto con un caracter hasta llegar a la longitud indicada
        /// </summary>
        /// <param name="Texto">Texto que se será rellenado</param>
        /// <param name="CaracterDeRelleno">Caracter con que se rellenará el texto</param>
        /// <param name="Longitud">Longitud final del texto rellenado</param>
        /// <returns></returns>
        private static string RellenarCaracterIzquierda(string Texto, string CaracterDeRelleno, int Longitud)
        {
            if (Texto == null) Texto = "";
            if (CaracterDeRelleno == null) CaracterDeRelleno = " ";

            return Texto.Trim().PadLeft(Longitud, Convert.ToChar(CaracterDeRelleno));
        }

        /// <summary>
        /// Rellena a la derecha del texto con un caracter hasta llegar a la longitud indicada
        /// </summary>
        /// <param name="Texto">Texto que se será rellenado</param>
        /// <param name="CaracterDeRelleno">Caracter con que se rellenará el texto</param>
        /// <param name="Longitud">Longitud final del texto rellenado</param>
        /// <returns></returns>
        private static string RellenarCaracterDerecha(string Texto, string CaracterDeRelleno, int Longitud)
        {
            if (Texto == null) Texto = "";
            if (CaracterDeRelleno == null) CaracterDeRelleno = " ";

            return Texto.PadRight(Longitud, Convert.ToChar(CaracterDeRelleno));
        }

        /// <summary>
        /// Parte un texto alineandolo desde la segunda linea en la posición que le indiquemos y considerando la longitud
        /// </summary>
        /// <param name="Texto"></param>
        /// <param name="PosicionDeAlineacion"></param>
        /// <param name="Longitud"></param>
        /// <returns></returns>
        private static string PartirTextoConAlineacionDesdeSegundaLinea(string Texto, int PosicionDeAlineacion, int Longitud)
        {
            //Verificamos que los parametro tengan valor es correctos sino asignamos valores por defecto
            if (Texto == null) Texto = "";
            if (PosicionDeAlineacion <= 0) PosicionDeAlineacion = 1;
            if (Longitud <= 0) Longitud = 1;
            string TextoPartido = "";


            //bool NuevaLinea = true; //Variable para indicar que hay que agregar una nueva linea
            string Linea = ""; //Variable donde se guardará el texto de una linea de forma temporal
            foreach (char Caracter in Texto.Trim()) //Recorremos todos los caracter del texto
            {
                //Agregamos el caracter actual a la linea
                Linea += Caracter.ToString();

                //Si la longitud de la linea es mayor o igual a la longitud total (incluida la alineación) la agregamos al texto final partido
                if ((RellenarCaracterIzquierda("", " ", PosicionDeAlineacion - 1) + Linea.TrimStart()).Length >= Longitud)
                {
                    TextoPartido += SaltoDeLinea(true) + RellenarCaracterIzquierda("", " ", PosicionDeAlineacion - 1) + Linea.TrimStart();
                    //NuevaLinea = true;
                    Linea = "";
                }
            }

            //Agregamos el texto sobrante
            TextoPartido += (TextoPartido != "" && Linea.Trim() != "" ? SaltoDeLinea(true) : "") + RellenarCaracterIzquierda("", " ", PosicionDeAlineacion - 1) + Linea.TrimStart();

            //Retornamos el texto partido y alineado
            return TextoPartido.Trim();
        }

        private static string PartirTextoConAlineacionDesdeSegundaLinea_PorUnCaracter(string Texto, string CaracterSplit, int PosicionDeAlineacion, int Longitud)
        {
            //Verificamos que los parametro tengan valor es correctos sino asignamos valores por defecto
            if (Texto == null) Texto = "";
            if (PosicionDeAlineacion <= 0) PosicionDeAlineacion = 1;
            if (Longitud <= 0) Longitud = 1;
            string TextoPartido = "";


            foreach (string Cadena in Texto.Split(Convert.ToChar(CaracterSplit)))
            {
                TextoPartido += (TextoPartido != "" ? SaltoDeLinea(true) : "") + RellenarCaracterIzquierda(" ", " ", PosicionDeAlineacion - 1) + Cadena;
            }

            //Retornamos el texto partido y alineado
            return TextoPartido.Trim();
        }

        private static string PartirTextoConAlineacionDesdeSegundaLinea_PorUnCaracter_En_FormatoDobleYNegrita(string Texto, string CaracterSplit, int PosicionDeAlineacion, int Longitud)
        {
            //Verificamos que los parametro tengan valor es correctos sino asignamos valores por defecto
            if (Texto == null) Texto = "";
            if (PosicionDeAlineacion <= 0) PosicionDeAlineacion = 1;
            if (Longitud <= 0) Longitud = 1;
            string TextoPartido = "";


            foreach (string Cadena in Texto.Split(Convert.ToChar(CaracterSplit)))
            {
                TextoPartido += (TextoPartido != "" ? SaltoDeLinea(true) : "") + RellenarCaracterIzquierda(" ", " ", PosicionDeAlineacion - 1) + Cadena;
            }

            //Retornamos el texto partido y alineado
            return FormatoNegritaActivar + FormatoDobleActivar + TextoPartido.Trim() + FormatoDobleDesactivar + FormatoNegritaDesactivar;
        }


        private static string PartirDatosClientePorTipoDocumenoIdentidad(string Cliente)
        {
            string DatosPartido = "";

            if (Cliente == null) Cliente = string.Empty;
            Cliente = Cliente.ToUpper().Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");

            
            if (Cliente.Contains("DNI"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("DNI"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("DNI"), Cliente.Length - Cliente.IndexOf("DNI"));
            }
            else if (Cliente.Contains("RUC"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("RUC"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("RUC"), Cliente.Length - Cliente.IndexOf("RUC"));
            }
            else if (Cliente.Contains("PAS"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("PAS"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("PAS"), Cliente.Length - Cliente.IndexOf("PAS"));
            }
            else if (Cliente.Contains("PASAPORTE"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("PASAPORTE"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("PASAPORTE"), Cliente.Length - Cliente.IndexOf("PASAPORTE"));
            }
            else if (Cliente.Contains("CARNET EXTRANJERIA"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("CARNET EXTRANJERIA"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("CARNET EXTRANJERIA"), Cliente.Length - Cliente.IndexOf("CARNET EXTRANJERIA"));
            }
            else if (Cliente.Contains("CARNET DE ENTRANJERIA"))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("CARNET DE ENTRANJERIA"));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("CARNET DE ENTRANJERIA"), Cliente.Length - Cliente.IndexOf("CARNET DE ENTRANJERIA"));
            }
            else if (Cliente.Contains("C.E."))
            {
                DatosPartido = Cliente.Substring(0, Cliente.IndexOf("C.E."));
                DatosPartido += SaltoDeLinea(true) + Cliente.Substring(Cliente.IndexOf("C.E."), Cliente.Length - Cliente.IndexOf("C.E."));
            }
            else { DatosPartido = Cliente; }

            return DatosPartido;
        }


        private string RemoverTexto(string TextoBase, string TextoARemover)
        {
            while(TextoBase.Contains(TextoARemover))
            {
                TextoBase = TextoBase.Remove(TextoBase.IndexOf(TextoARemover), TextoARemover.Length);
            }

            return TextoBase;
        }


        /// <summary>
        /// Retorna una cadena con el comando para 1 solo salto de linea
        /// </summary>
        /// <returns></returns>
        private static string SaltoDeLinea()
        {
            return SaltoDeLinea(1, false);
        }

        /// <summary>
        /// Retorna una cadena con los comando para el número de saltos de linea indicados
        /// </summary>
        /// <param name="Lineas">Cantidad de Saltos de Línea</param>
        /// <returns></returns>
        private static string SaltoDeLinea(int Lineas)
        {
            return SaltoDeLinea(Lineas, false);
        }

        /// <summary>
        /// Retorna una cadena con un comando para 1 solo salto de linea e indicandole si incluye el comando para el retorno de carro
        /// </summary>
        /// <param name="RetornoDeCarro">True o false para indicar si incluye el retorno de carro</param>
        /// <returns></returns>
        private static string SaltoDeLinea(bool RetornoDeCarro)
        {
            return SaltoDeLinea(1, RetornoDeCarro);
        }

        /// <summary>
        /// Retorna una cadena con los comando para el número de saltos de linea indicados y a la vez indicandole si incluye el comando para el retorno de carro
        /// </summary>
        /// <param name="Lineas">Cantidad de Saltos de Línea</param>
        /// <param name="RetornoDeCarro">True o false para indicar si incluye el retorno de carro</param>
        /// <returns></returns>
        private static string SaltoDeLinea(int Lineas, bool RetornoDeCarro)
        {
            string SaltoDeLinea_ = "";

            //Cuando el valor de las líneas es cero (0) siempre le asignamos por lo menos el 1 línea
            if (Lineas == 0) Lineas = 1;
            for (int Linea = 1; Linea <= Lineas; Linea++)
            {
                //private const string SaltoDeLinea = "\x0A";
                SaltoDeLinea_ += "\x0A";
            }

            if (RetornoDeCarro)
            {
                //private const string RetornoDeCarro = "\x0C";
                SaltoDeLinea_ += "\x0C";
            }

            return SaltoDeLinea_;
        }

        private static string Dec_To_Hex(int Number)
        {
            string Hex = "";
            switch (Number)
            {
                case 0:
                    Hex = "\x00";
                    break;

                case 1:
                    Hex = "\x01";
                    break;

                case 2:
                    Hex = "\x02";
                    break;

                case 3:
                    Hex = "\x03";
                    break;

                case 4:
                    Hex = "\x04";
                    break;

                case 5:
                    Hex = "\x05";
                    break;

                case 6:
                    Hex = "\x06";
                    break;

                case 7:
                    Hex = "\x07";
                    break;

                case 8:
                    Hex = "\x08";
                    break;

                case 9:
                    Hex = "\x09";
                    break;

                case 10:
                    Hex = "\x0a";
                    break;

                case 11:
                    Hex = "\x0b";
                    break;

                case 12:
                    Hex = "\x0c";
                    break;

                case 13:
                    Hex = "\x0d";
                    break;

                case 14:
                    Hex = "\x0e";
                    break;

                case 15:
                    Hex = "\x0f";
                    break;

                case 16:
                    Hex = "\x10";
                    break;

                case 17:
                    Hex = "\x11";
                    break;

                case 18:
                    Hex = "\x12";
                    break;

                case 19:
                    Hex = "\x13";
                    break;

                case 20:
                    Hex = "\x14";
                    break;

                case 21:
                    Hex = "\x15";
                    break;

                case 22:
                    Hex = "\x16";
                    break;

                case 23:
                    Hex = "\x17";
                    break;

                case 24:
                    Hex = "\x18";
                    break;

                case 25:
                    Hex = "\x19";
                    break;

                case 26:
                    Hex = "\x1A";
                    break;

                case 27:
                    Hex = "\x1B";
                    break;

                case 28:
                    Hex = "\x1C";
                    break;

                case 29:
                    Hex = "\x1D";
                    break;

                case 30:
                    Hex = "\x1E";
                    break;

                case 31:
                    Hex = "\x1F";
                    break;

                case 32:
                    Hex = "\x20";
                    break;

                case 33:
                    Hex = "\x21";
                    break;

                case 34:
                    Hex = "\x22";
                    break;

                case 35:
                    Hex = "\x23";
                    break;

                case 36:
                    Hex = "\x24";
                    break;

                case 37:
                    Hex = "\x25";
                    break;

                case 38:
                    Hex = "\x26";
                    break;

                case 39:
                    Hex = "\x27";
                    break;

                case 40:
                    Hex = "\x28";
                    break;

                case 41:
                    Hex = "\x29";
                    break;

                case 42:
                    Hex = "\x2A";
                    break;

                case 43:
                    Hex = "\x2B";
                    break;

                case 44:
                    Hex = "\x2C";
                    break;

                case 45:
                    Hex = "\x2D";
                    break;

                case 46:
                    Hex = "\x2E";
                    break;

                case 47:
                    Hex = "\x2F";
                    break;

                case 48:
                    Hex = "\x30";
                    break;

                case 49:
                    Hex = "\x31";
                    break;

                case 50:
                    Hex = "\x32";
                    break;

                case 51:
                    Hex = "\x33";
                    break;

                case 52:
                    Hex = "\x34";
                    break;

                case 53:
                    Hex = "\x35";
                    break;

                case 54:
                    Hex = "\x36";
                    break;

                case 55:
                    Hex = "\x37";
                    break;

                case 56:
                    Hex = "\x38";
                    break;

                case 57:
                    Hex = "\x39";
                    break;

                case 58:
                    Hex = "\x3A";
                    break;

                case 59:
                    Hex = "\x3B";
                    break;

                case 60:
                    Hex = "\x3C";
                    break;

                case 61:
                    Hex = "\x3D";
                    break;

                case 62:
                    Hex = "\x3E";
                    break;

                case 63:
                    Hex = "\x3F";
                    break;

                case 64:
                    Hex = "\x40";
                    break;

                case 65:
                    Hex = "\x41";
                    break;

                case 66:
                    Hex = "\x42";
                    break;

                case 67:
                    Hex = "\x43";
                    break;

                case 68:
                    Hex = "\x44";
                    break;

                case 69:
                    Hex = "\x45";
                    break;

                case 70:
                    Hex = "\x46";
                    break;

                case 71:
                    Hex = "\x47";
                    break;

                case 72:
                    Hex = "\x48";
                    break;

                case 73:
                    Hex = "\x49";
                    break;

                case 74:
                    Hex = "\x4A";
                    break;

                case 75:
                    Hex = "\x4B";
                    break;

                case 76:
                    Hex = "\x4C";
                    break;

                case 77:
                    Hex = "\x4D";
                    break;

                case 78:
                    Hex = "\x4E";
                    break;

                case 79:
                    Hex = "\x4F";
                    break;

                case 80:
                    Hex = "\x50";
                    break;

                case 81:
                    Hex = "\x51";
                    break;

                case 82:
                    Hex = "\x52";
                    break;

                case 83:
                    Hex = "\x53";
                    break;

                case 84:
                    Hex = "\x54";
                    break;

                case 85:
                    Hex = "\x55";
                    break;

                case 86:
                    Hex = "\x56";
                    break;

                case 87:
                    Hex = "\x57";
                    break;

                case 88:
                    Hex = "\x58";
                    break;

                case 89:
                    Hex = "\x59";
                    break;

                case 90:
                    Hex = "\x5A";
                    break;

                case 91:
                    Hex = "\x5B";
                    break;

                case 92:
                    Hex = "\x5C";
                    break;

                case 93:
                    Hex = "\x5D";
                    break;

                case 94:
                    Hex = "\x5E";
                    break;

                case 95:
                    Hex = "\x5F";
                    break;

                case 96:
                    Hex = "\x60";
                    break;

                case 97:
                    Hex = "\x61";
                    break;

                case 98:
                    Hex = "\x62";
                    break;

                case 99:
                    Hex = "\x63";
                    break;

                case 100:
                    Hex = "\x64";
                    break;

                case 101:
                    Hex = "\x65";
                    break;

                case 102:
                    Hex = "\x66";
                    break;

                case 103:
                    Hex = "\x67";
                    break;

                case 104:
                    Hex = "\x68";
                    break;

                case 105:
                    Hex = "\x69";
                    break;

                case 106:
                    Hex = "\x6A";
                    break;

                case 107:
                    Hex = "\x6B";
                    break;

                case 108:
                    Hex = "\x6C";
                    break;

                case 109:
                    Hex = "\x6D";
                    break;

                case 110:
                    Hex = "\x6E";
                    break;

                case 111:
                    Hex = "\x6F";
                    break;

                case 112:
                    Hex = "\x70";
                    break;

                case 113:
                    Hex = "\x71";
                    break;

                case 114:
                    Hex = "\x72";
                    break;

                case 115:
                    Hex = "\x73";
                    break;

                case 116:
                    Hex = "\x74";
                    break;

                case 117:
                    Hex = "\x75";
                    break;

                case 118:
                    Hex = "\x76";
                    break;

                case 119:
                    Hex = "\x77";
                    break;

                case 120:
                    Hex = "\x78";
                    break;

                case 121:
                    Hex = "\x79";
                    break;

                case 122:
                    Hex = "\x7A";
                    break;

                case 123:
                    Hex = "\x7B";
                    break;

                case 124:
                    Hex = "\x7C";
                    break;

                case 125:
                    Hex = "\x7D";
                    break;

                case 126:
                    Hex = "\x7E";
                    break;

                case 127:
                    Hex = "\x7F";
                    break;

                case 128:
                    Hex = "\x80";
                    break;

                case 129:
                    Hex = "\x81";
                    break;

                case 130:
                    Hex = "\x82";
                    break;

                case 131:
                    Hex = "\x83";
                    break;

                case 132:
                    Hex = "\x84";
                    break;

                case 133:
                    Hex = "\x85";
                    break;

                case 134:
                    Hex = "\x86";
                    break;

                case 135:
                    Hex = "\x87";
                    break;

                case 136:
                    Hex = "\x88";
                    break;

                case 137:
                    Hex = "\x89";
                    break;

                case 138:
                    Hex = "\x8A";
                    break;

                case 139:
                    Hex = "\x8B";
                    break;

                case 140:
                    Hex = "\x8C";
                    break;

                case 141:
                    Hex = "\x8D";
                    break;

                case 142:
                    Hex = "\x8E";
                    break;

                case 143:
                    Hex = "\x8F";
                    break;

                case 144:
                    Hex = "\x90";
                    break;

                case 145:
                    Hex = "\x91";
                    break;

                case 146:
                    Hex = "\x92";
                    break;

                case 147:
                    Hex = "\x93";
                    break;

                case 148:
                    Hex = "\x94";
                    break;

                case 149:
                    Hex = "\x95";
                    break;

                case 150:
                    Hex = "\x96";
                    break;

                case 151:
                    Hex = "\x97";
                    break;

                case 152:
                    Hex = "\x98";
                    break;

                case 153:
                    Hex = "\x99";
                    break;

                case 154:
                    Hex = "\x9A";
                    break;

                case 155:
                    Hex = "\x9B";
                    break;

                case 156:
                    Hex = "\x9C";
                    break;

                case 157:
                    Hex = "\x9D";
                    break;

                case 158:
                    Hex = "\x9E";
                    break;

                case 159:
                    Hex = "\x9F";
                    break;

                case 160:
                    Hex = "\xA0";
                    break;

                case 161:
                    Hex = "\xA1";
                    break;

                case 162:
                    Hex = "\xA2";
                    break;

                case 163:
                    Hex = "\xA3";
                    break;

                case 164:
                    Hex = "\xA4";
                    break;

                case 165:
                    Hex = "\xA5";
                    break;

                case 166:
                    Hex = "\xA6";
                    break;

                case 167:
                    Hex = "\xA7";
                    break;

                case 168:
                    Hex = "\xA8";
                    break;

                case 169:
                    Hex = "\xA9";
                    break;

                case 170:
                    Hex = "\xAA";
                    break;

                case 171:
                    Hex = "\xAB";
                    break;

                case 172:
                    Hex = "\xAC";
                    break;

                case 173:
                    Hex = "\xAD";
                    break;

                case 174:
                    Hex = "\xAE";
                    break;

                case 175:
                    Hex = "\xAF";
                    break;

                case 176:
                    Hex = "\xB0";
                    break;

                case 177:
                    Hex = "\xB1";
                    break;

                case 178:
                    Hex = "\xB2";
                    break;

                case 179:
                    Hex = "\xB3";
                    break;

                case 180:
                    Hex = "\xB4";
                    break;

                case 181:
                    Hex = "\xB5";
                    break;

                case 182:
                    Hex = "\xB6";
                    break;

                case 183:
                    Hex = "\xB7";
                    break;

                case 184:
                    Hex = "\xB8";
                    break;

                case 185:
                    Hex = "\xB9";
                    break;

                case 186:
                    Hex = "\xBA";
                    break;

                case 187:
                    Hex = "\xBB";
                    break;

                case 188:
                    Hex = "\xBC";
                    break;

                case 189:
                    Hex = "\xBD";
                    break;

                case 190:
                    Hex = "\xBE";
                    break;

                case 191:
                    Hex = "\xBF";
                    break;

                case 192:
                    Hex = "\xC0";
                    break;

                case 193:
                    Hex = "\xC1";
                    break;

                case 194:
                    Hex = "\xC2";
                    break;

                case 195:
                    Hex = "\xC3";
                    break;

                case 196:
                    Hex = "\xC4";
                    break;

                case 197:
                    Hex = "\xC5";
                    break;

                case 198:
                    Hex = "\xC6";
                    break;

                case 199:
                    Hex = "\xC7";
                    break;

                case 200:
                    Hex = "\xC8";
                    break;

                case 201:
                    Hex = "\xC9";
                    break;

                case 202:
                    Hex = "\xCA";
                    break;

                case 203:
                    Hex = "\xCB";
                    break;

                case 204:
                    Hex = "\xCC";
                    break;

                case 205:
                    Hex = "\xCD";
                    break;

                case 206:
                    Hex = "\xCE";
                    break;

                case 207:
                    Hex = "\xCF";
                    break;

                case 208:
                    Hex = "\xD0";
                    break;

                case 209:
                    Hex = "\xD1";
                    break;

                case 210:
                    Hex = "\xD2";
                    break;

                case 211:
                    Hex = "\xD3";
                    break;

                case 212:
                    Hex = "\xD4";
                    break;

                case 213:
                    Hex = "\xD5";
                    break;

                case 214:
                    Hex = "\xD6";
                    break;

                case 215:
                    Hex = "\xD7";
                    break;

                case 216:
                    Hex = "\xD8";
                    break;

                case 217:
                    Hex = "\xD9";
                    break;

                case 218:
                    Hex = "\xDA";
                    break;

                case 219:
                    Hex = "\xDB";
                    break;

                case 220:
                    Hex = "\xDC";
                    break;

                case 221:
                    Hex = "\xDD";
                    break;

                case 222:
                    Hex = "\xDE";
                    break;

                case 223:
                    Hex = "\xDF";
                    break;

                case 224:
                    Hex = "\xE0";
                    break;

                case 225:
                    Hex = "\xE1";
                    break;

                case 226:
                    Hex = "\xE2";
                    break;

                case 227:
                    Hex = "\xE3";
                    break;

                case 228:
                    Hex = "\xE4";
                    break;

                case 229:
                    Hex = "\xE5";
                    break;

                case 230:
                    Hex = "\xE6";
                    break;

                case 231:
                    Hex = "\xE7";
                    break;

                case 232:
                    Hex = "\xE8";
                    break;

                case 233:
                    Hex = "\xE9";
                    break;

                case 234:
                    Hex = "\xEA";
                    break;

                case 235:
                    Hex = "\xEB";
                    break;

                case 236:
                    Hex = "\xEC";
                    break;

                case 237:
                    Hex = "\xED";
                    break;

                case 238:
                    Hex = "\xEE";
                    break;

                case 239:
                    Hex = "\xEF";
                    break;

                case 240:
                    Hex = "\xF0";
                    break;

                case 241:
                    Hex = "\xF1";
                    break;

                case 242:
                    Hex = "\xF2";
                    break;

                case 243:
                    Hex = "\xF3";
                    break;

                case 244:
                    Hex = "\xF4";
                    break;

                case 245:
                    Hex = "\xF5";
                    break;

                case 246:
                    Hex = "\xF6";
                    break;

                case 247:
                    Hex = "\xF7";
                    break;

                case 248:
                    Hex = "\xF8";
                    break;

                case 249:
                    Hex = "\xF9";
                    break;

                case 250:
                    Hex = "\xFA";
                    break;

                case 251:
                    Hex = "\xFB";
                    break;

                case 252:
                    Hex = "\xFC";
                    break;

                case 253:
                    Hex = "\xFD";
                    break;

                case 254:
                    Hex = "\xFE";
                    break;

                case 255:
                    Hex = "\xFF";
                    break;
            }

            return Hex;
        }
        #endregion

        public ComprobanteElectronico()
        {
            DocumentosModifica = new List<ComprobanteElectronico_DocumentoModifica>();
            Detalles = new List<ComprobanteElectronico_Detalle>();
            ConsignadosAdicionales = new List<string>();
        }

        public ComprobanteElectronico(string ComprobanteElectronico_Base64_String)
        {
            try
            {
                DocumentosModifica = new List<ComprobanteElectronico_DocumentoModifica>();
                Detalles = new List<ComprobanteElectronico_Detalle>();
                ConsignadosAdicionales = new List<string>();
                Leer(Convert.FromBase64String(ComprobanteElectronico_Base64_String));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        public ComprobanteElectronico(byte[] ComprobanteElectronico_ArrayByte)
        {
            try
            {
                DocumentosModifica = new List<ComprobanteElectronico_DocumentoModifica>();
                Detalles = new List<ComprobanteElectronico_Detalle>();
                ConsignadosAdicionales = new List<string>();
                Leer(ComprobanteElectronico_ArrayByte);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        public byte[] ComprobanteElectronico_en_ArrayByte { get; set; }

        private void Leer(byte[] ComprobanteElectronico_ArrayByte_)
        {
            try
            {
                ComprobanteElectronico_en_ArrayByte = ComprobanteElectronico_ArrayByte_;


                string xml_String = Encoding.GetEncoding("ISO-8859-1").GetString(ComprobanteElectronico_ArrayByte_);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xml_String);

                //Version UBL
                XmlNode nodeUBLVersionID = xml.GetElementsByTagName("cbc:UBLVersionID").Item(0);
                VersionUBL = (nodeUBLVersionID != null ? nodeUBLVersionID.InnerText : "");

                #region[Boleta / Factura]
                //Verificamos si es una factura/boleta
                if (xml.GetElementsByTagName("Invoice").Item(0) != null)
                {
                    //TipoDocumento
                    XmlNode nodeInvoiceTypeCode = xml.GetElementsByTagName("cbc:InvoiceTypeCode").Item(0);
                    TipoDocumento = (nodeInvoiceTypeCode != null ? nodeInvoiceTypeCode.InnerText : "");


                    //SerieNumero
                    XmlNode nodeInvoice = xml.GetElementsByTagName("Invoice").Item(0);
                    if (nodeInvoice != null)
                    {
                        foreach (XmlNode nodeInvoice_Hijo in nodeInvoice.ChildNodes)
                        {
                            if (nodeInvoice_Hijo.Name == "cbc:ID")
                            {
                                SerieNumero = nodeInvoice_Hijo.InnerText;
                                break;
                            }
                        }
                    }
                    //XmlNode nodeID = xml.GetElementsByTagName("cbc:ID").Item(0);
                    //SerieNumero = (nodeID != null ? nodeID.InnerText : "");


                    //Fecha Emision
                    XmlNode nodeIssueDate = xml.GetElementsByTagName("cbc:IssueDate").Item(0);
                    FechaEmision = (nodeIssueDate != null ? Convert.ToDateTime(nodeIssueDate.InnerText) : new DateTime());

                    //Hora Emisón
                    if (VersionUBL == "2.1")
                    {
                        XmlNode nodeIssueTime = xml.GetElementsByTagName("cbc:IssueTime").Item(0);
                        HoraEmision = (nodeIssueTime != null ? Convert.ToDateTime(nodeIssueTime.InnerText).ToString("hh:mm tt").Replace(".", "").ToUpper() : "");
                    }


                    //TipoMoneda
                    XmlNode nodeDocumentCurrencyCode = xml.GetElementsByTagName("cbc:DocumentCurrencyCode").Item(0);
                    TipoMoneda = (nodeDocumentCurrencyCode != null ? nodeDocumentCurrencyCode.InnerText : "");


                    //Datos del Titular del comprobante
                    XmlNode nodeAccountingCustomerParty = xml.GetElementsByTagName("cac:AccountingCustomerParty").Item(0);
                    if (nodeAccountingCustomerParty != null)
                    {
                        foreach (XmlNode nodeAccountingCustomerParty_Hijo in nodeAccountingCustomerParty.ChildNodes)
                        {
                            /*Version 2.0*/
                            if (nodeAccountingCustomerParty_Hijo.Name == "cbc:AdditionalAccountID")
                            {
                                Titular_DocumentoTipo = nodeAccountingCustomerParty_Hijo.InnerText;
                            }
                            else if (nodeAccountingCustomerParty_Hijo.Name == "cbc:CustomerAssignedAccountID")
                            {
                                Titular_DocumentoNumero = nodeAccountingCustomerParty_Hijo.InnerText;
                            }
                            /*Version 2.0 y 2.1*/
                            else if (nodeAccountingCustomerParty_Hijo.Name == "cac:Party")
                            {
                                foreach (XmlNode nodeParty_Hijo in nodeAccountingCustomerParty_Hijo.ChildNodes)
                                {
                                    /*Version 2.1*/
                                    if (nodeParty_Hijo.Name == "cac:PartyIdentification")
                                    {
                                        foreach (XmlNode nodePartyIdentification_Hijo in nodeParty_Hijo.ChildNodes)
                                        {
                                            if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                            {
                                                Titular_DocumentoTipo = nodePartyIdentification_Hijo.Attributes.GetNamedItem("schemeID").InnerText;
                                                Titular_DocumentoNumero = nodePartyIdentification_Hijo.InnerText;
                                            }
                                        }
                                    }
                                    /*Version 2.0 y 2.1*/
                                    else if (nodeParty_Hijo.Name == "cac:PartyLegalEntity")
                                    {
                                        foreach (XmlNode nodePartyLegalEntity_Hijo in nodeParty_Hijo.ChildNodes)
                                        {
                                            if (nodePartyLegalEntity_Hijo.Name == "cbc:RegistrationName")
                                            {
                                                Titular_NombreLegal = nodePartyLegalEntity_Hijo.InnerText.Replace('"', ' ');
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    //DigestValue
                    XmlNode nodeDigestValue = xml.GetElementsByTagName("DigestValue").Item(0);
                    DigestValue = (nodeDigestValue != null ? nodeDigestValue.InnerText : "");


                    //SignatureValue
                    XmlNode nodeSignatureValue = xml.GetElementsByTagName("SignatureValue").Item(0);
                    SignatureValue = (nodeSignatureValue != null ? nodeSignatureValue.InnerText : "");


                    string Codigo = ""; //Variable para identificar los totales y los datos adicionales


                    /*Totales Version 2.0*/
                    foreach (XmlNode nodeAdditionalMonetaryTotal in xml.GetElementsByTagName("sac:AdditionalMonetaryTotal"))
                    {
                        foreach (XmlNode nodeAdditionalInformation_Hijo in nodeAdditionalMonetaryTotal.ChildNodes)
                        {
                            if (nodeAdditionalInformation_Hijo.Name == "cbc:ID")
                            {
                                Codigo = nodeAdditionalInformation_Hijo.InnerText;
                            }
                            else if (nodeAdditionalInformation_Hijo.Name == "cbc:PayableAmount")
                            {
                                switch (Codigo)
                                {
                                    case "1001": //Gravadas
                                        Gravadas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1002": //Inafecta
                                        Inafectas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1003": //Exonerada
                                        Exoneradas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1004": //Gratuitas
                                        Gratuitas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;
                                }
                            }
                        }
                    }


                    /*Impuestos Version 2.0*/
                    XmlNode nodeTaxTotal = xml.GetElementsByTagName("cac:TaxTotal").Item(0);
                    if (nodeTaxTotal != null)
                    {
                        foreach (XmlNode nodeTaxTotal_Hijo in nodeTaxTotal.ChildNodes)
                        {   //Forma1
                            if (nodeTaxTotal_Hijo.Name == "cbc:TaxAmount")
                            {
                                Igv = Convert.ToDecimal(nodeTaxTotal_Hijo.InnerText);
                            }

                            //Forma 2
                            if (nodeTaxTotal_Hijo.Name == "cac:TaxSubtotal")
                            {
                                decimal Impuesto = 0; //Variable para guardar de forma temporal el importe del impuesto

                                foreach (XmlNode nodeTaxSubtotal_Hijo in nodeTaxTotal_Hijo.ChildNodes)
                                {
                                    if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxAmount") //Capturamos el importe del impuesto
                                    {
                                        Impuesto = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cac:TaxCategory")
                                    {
                                        foreach (XmlNode nodeTaxCategory_Hijo in nodeTaxSubtotal_Hijo.ChildNodes)
                                        {
                                            if (nodeTaxCategory_Hijo.Name == "cac:TaxScheme")
                                            {
                                                foreach (XmlNode nodeTaxScheme_Hijo in nodeTaxCategory_Hijo.ChildNodes)
                                                {
                                                    if (nodeTaxScheme_Hijo.Name == "cbc:Name") //Verificamos el nombre del tipo de impuesto
                                                    {
                                                        if (nodeTaxScheme_Hijo.InnerText == "IGV") //Cuando es IGV
                                                        {
                                                            Igv = Impuesto;         //Asignamos
                                                            Impuesto = 0;           //Limpiamos para el proximo impuesto
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    /*Totales Version 2.1*/
                    if (VersionUBL == "2.1")
                    {
                        nodeTaxTotal = xml.GetElementsByTagName("cac:TaxTotal").Item(0);

                        foreach (XmlNode nodeTaxTotal_Hijo in nodeTaxTotal.ChildNodes)
                        {
                            if (nodeTaxTotal_Hijo.Name == "cac:TaxSubtotal")
                            {
                                decimal Impuesto = 0m;
                                decimal ImporteBase = 0m;
                                foreach(XmlNode nodeTaxSubtotal_Hijo in nodeTaxTotal_Hijo.ChildNodes)
                                {
                                    if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxableAmount")
                                    {
                                        ImporteBase = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxAmount")
                                    {
                                        Impuesto = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cac:TaxCategory")
                                    {
                                        foreach(XmlNode nodeTaxScheme in nodeTaxSubtotal_Hijo.ChildNodes)
                                        {
                                            if (nodeTaxScheme.Name == "cac:TaxScheme")
                                            {
                                                foreach(XmlNode nodeTaxScheme_Hijo in nodeTaxScheme.ChildNodes)
                                                {
                                                    if (nodeTaxScheme_Hijo.Name == "cbc:ID")
                                                    {
                                                        switch(nodeTaxScheme_Hijo.InnerText)
                                                        {
                                                            case "1000": //Gravada e IGV
                                                                Gravadas = ImporteBase;
                                                                Igv = Impuesto;
                                                                break;

                                                            case "1015": //IVAP
                                                                break;

                                                            case "2000": //ISC
                                                                break;

                                                            case "9995": //Exportación
                                                                break;

                                                            case "9996": //Gratuita
                                                                Gratuitas = ImporteBase;
                                                                break;

                                                            case "9997": //Exonerada
                                                                Exoneradas = ImporteBase;
                                                                break;

                                                            case "9998": //Inafecta
                                                                Inafectas = ImporteBase;
                                                                break;

                                                            case "9999": //Otros Conceptos
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }





                    //Importe Total
                    XmlNode nodeLegalMonetaryTotal = xml.GetElementsByTagName("cac:LegalMonetaryTotal").Item(0);
                    if (nodeLegalMonetaryTotal != null)
                    {
                        foreach (XmlNode nodeLegalMonetaryTotal_Hijo in nodeLegalMonetaryTotal.ChildNodes)
                        {
                            if (nodeLegalMonetaryTotal_Hijo.Name == "cbc:PayableAmount")
                            {
                                ImporteTotal = Convert.ToDecimal(nodeLegalMonetaryTotal_Hijo.InnerText);
                            }
                        }
                    }



                    //Datos Adicionales segun SUNAT Versión 2.0
                    foreach (XmlNode nodeAdditionalProperty in xml.GetElementsByTagName("sac:AdditionalProperty"))
                    {
                        // Recorremos cada dato adicional
                        foreach (XmlNode nodeAdditionalProperty_Hijo in nodeAdditionalProperty.ChildNodes)
                        {
                            //Obtenemos el Codigo del datos adicional
                            if (nodeAdditionalProperty_Hijo.Name == "cbc:ID")
                            {
                                Codigo = nodeAdditionalProperty_Hijo.InnerText;
                            }
                            //Asignamos el valor según el código del dato adicional
                            else if (nodeAdditionalProperty_Hijo.Name == "cbc:Value")
                            {
                                switch (Codigo.ToUpper())
                                {
                                    case "1000": //Son (Monto en el Letras)
                                        Son = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "1002": //Transferencia de un bien gratuito y/o servicio prestado grstuitamente
                                        TransferenciaGratuitaLeyenda = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "FORMATO": //Para indicar los datos que se usaran al momento de realizar la representacion impresa en Pdf
                                        Formato = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "PASAJERO": 
                                        Pasajero = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "BOLETO":
                                        Boleto = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "NROASIENTO":
                                        NroAsiento = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "NROBULTOS":
                                        NroBultos = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "TIPOUNIDAD":
                                        TipoUnidad = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "FECHAHORAVIAJE":
                                        FechaHoraViaje = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "HORA EMISION":
                                        HoraEmision = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "CAJERO":
                                        Cajero = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "EQUIPAJE DETALLE":
                                        EquipajeDetalle = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CLAVE": //Clave
                                        Clave = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "MENSAJERO": //Mensajero
                                        Mensajero = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "REMITENTE": //Remitente
                                        Remitente = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONSIGNADO": //Consignado
                                        Consignado = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONSIGNADO ADICIONAL": //Consignado Adicional
                                        ConsignadosAdicionales.Add(nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' '));
                                        break;

                                    case "ORIGEN": //Origen
                                        Origen = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "DESTINO": //Destino
                                        Destino = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "FORMA ENTREGA": //Forma Entrega
                                        FormaEntrega = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "CODIGO CLIENTE": //Código Cliente
                                        CodigoCliente = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "SERVICIO": //Servicio
                                        Servicio = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "ORDEN SERVICIO": //Orden de Servicio
                                        OrdenServicio = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "ANEXO": //Anexo
                                        Anexo = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "DOCUMENTOS ANEXOS": //DocumentoAnexos
                                        DocumentosAnexos = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONDICIONPAGO": //Condición Pago
                                    case "CONDICION PAGO": //Condición Pago
                                        CondicionPago = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "OBSERVACION": //Observacion
                                        Observacion = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "BULTOS": //Bultos
                                        Bultos = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "SEGUN GUIA": //Segun Guia
                                        SegunGuia = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "DIRECCION RECOJO": //Direccion Recojo
                                        DireccionRecojo = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "DIRECCION ENTREGA": //Direccion Entrega
                                        DireccionEntrega = nodeAdditionalProperty_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;
                                }
                            }
                        }
                    }

                    /*Datos Adicionales Según SUNAT Versión 2.1*/
                    foreach(XmlNode nodeNote in xml.GetElementsByTagName("cbc:Note"))
                    {
                        switch(nodeNote.Attributes["languageLocaleID"].InnerText)
                        {
                            case "1000": //Monto en letras
                                Son = nodeNote.InnerText;
                                break;

                            case "1002": //Transferencia Gratuita
                                TransferenciaGratuitaLeyenda = nodeNote.InnerText;
                                break;
                        }
                    }

                    //Datos Adicionales Internos
                    foreach (XmlNode nodeDatoAdicional in xml.GetElementsByTagName("DatoAdicional"))
                    {
                        // Recorremos cada dato adicional
                        foreach (XmlNode nodeDatoAdicional_Hijo in nodeDatoAdicional.ChildNodes)
                        {
                            //Obtenemos el Codigo del datos adicional
                            if (nodeDatoAdicional_Hijo.Name == "Codigo")
                            {
                                Codigo = nodeDatoAdicional_Hijo.InnerText;
                            }
                            //Asignamos el valor según el código del dato adicional
                            else if (nodeDatoAdicional_Hijo.Name == "Valor")
                            {
                                switch (Codigo.ToUpper())
                                {

                                    case "PUNTO EMISION":
                                        PuntoEmision = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "FORMATO": //Para indicar los datos que se usaran al momento de realizar la representacion impresa en Pdf
                                        Formato = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "FORMATO CODIGO BARRAS": //Para indicar el tipo de código de barras con el que se imprimirá
                                        Formato_CodigoBarras = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "PASAJERO":
                                        Pasajero = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ').ToUpper();
                                        break;

                                    case "PASAJERONOMBREAPELLIDO":
                                    case "PASAJERO NOMBRE APELLIDO":
                                        PasajeroNombreApellido = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ').ToUpper();
                                        break;

                                    case "PASAJERODOCUMENTO":
                                    case "PASAJERO DOCUMENTO":
                                        PasajeroDocumento = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ').ToUpper();
                                        break;

                                    case "VIAJERUTA":
                                    case "VIAJE RUTA":
                                        ViajeRuta = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "VIAJEFECHAHORA":
                                    case "VIAJE FECHA HORA":
                                        ViajeFechaHora = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "VIAJEASIENTO":
                                    case "VIAJE ASIENTO":
                                        ViajeAsiento = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "DESPLAZAMIENTOTIPO":
                                    case "DESPLASAMIENTOTIPO":
                                    case "DESPLAZAMIENTO TIPO":
                                    case "DESPLASAMIENTO TIPO":
                                        DesplazamientoTipo = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "LUGARDEEMBARQUE":
                                    case "EMBARQUELUGAR":
                                    case "EMBARQUE LUGAR":
                                        EmbarqueLugar = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "LUGARDEDESEMBARQUE":
                                    case "DESEMBARQUELUGAR":
                                    case "DESEMBARQUE LUGAR":
                                        DesembarqueLugar = nodeDatoAdicional_Hijo.InnerText.ToUpper();
                                        break;

                                    case "POLIZATEXTO":
                                    case "POLIZA TEXTO":
                                        PolizaTexto = nodeDatoAdicional_Hijo.InnerText.Replace(Environment.NewLine, " ").Replace('"', ' ').ToUpper();
                                        break;

                                    case "BOLETO":
                                        Boleto = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "NROASIENTO":
                                        NroAsiento = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "NROBULTOS":
                                        NroBultos = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "TIPOUNIDAD":
                                        TipoUnidad = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "FECHAHORAVIAJE":
                                        FechaHoraViaje = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "HORA EMISION":
                                        HoraEmision = nodeDatoAdicional_Hijo.InnerText.Replace(".", "").ToUpper();
                                        break;

                                    case "CAJERO":
                                        Cajero = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "EQUIPAJE DETALLE":
                                        EquipajeDetalle = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CLAVE": //Clave
                                        Clave = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "MENSAJERO": //Mensajero
                                        Mensajero = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "REMITENTE": //Remitente
                                        Remitente = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONSIGNADO": //Consignado
                                        Consignado = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONSIGNADO ADICIONAL": //Consignado Adicional
                                        ConsignadosAdicionales.Add(nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' '));
                                        break;

                                    case "ORIGEN": //Origen
                                        Origen = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "DESTINO": //Destino
                                        Destino = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "FORMA ENTREGA": //Forma Entrega
                                        FormaEntrega = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "CODIGO CLIENTE": //Código Cliente
                                        CodigoCliente = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "SERVICIO": //Servicio
                                        Servicio = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "ORDEN SERVICIO": //Orden de Servicio
                                        OrdenServicio = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "ANEXO": //Anexo
                                        Anexo = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "DOCUMENTOS ANEXOS": //DocumentoAnexos
                                        DocumentosAnexos = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "CONDICIONPAGO": //Condición Pago
                                    case "CONDICION PAGO": //Condición Pago
                                        CondicionPago = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "OBSERVACION": //Observacion
                                        Observacion = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "BULTOS": //Bultos
                                        Bultos = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "SEGUN GUIA": //Segun Guia
                                        SegunGuia = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "DIRECCION RECOJO": //Direccion Recojo
                                        DireccionRecojo = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;

                                    case "DIRECCION ENTREGA": //Direccion Entrega
                                        DireccionEntrega = nodeDatoAdicional_Hijo.InnerText.Replace("/", " ").Replace(Environment.NewLine, " ").Replace('"', ' ');
                                        break;
                                }
                            }
                        }
                    }


                    //Detalle
                    foreach (XmlNode nodeInvoiceLine in xml.GetElementsByTagName("cac:InvoiceLine"))
                    {
                        int Item_ = 0;
                        string Codigo_ = "";
                        string Descripcion_ = "";
                        decimal Cantidad_ = 0;
                        string UnidadDeMedida_ = "";
                        decimal PrecioUnitario_SinIgv_ = 0;
                        decimal PrecioReferencia_IncluyeIgv_ = 0;
                        decimal SubTotal_SinIgv_ = 0;
                        decimal Impuestos_ = 0;
                        decimal Total_ = 0;

                        foreach (XmlNode nodeInvoiceLine_Hijo in nodeInvoiceLine.ChildNodes)
                        {
                            if (nodeInvoiceLine_Hijo.Name == "cbc:ID")
                            {
                                Item_ = Convert.ToInt32(nodeInvoiceLine_Hijo.InnerText);
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cbc:InvoicedQuantity")
                            {
                                Cantidad_ = Convert.ToDecimal(nodeInvoiceLine_Hijo.InnerText);
                                foreach (XmlAttribute atributo in nodeInvoiceLine_Hijo.Attributes)
                                {
                                    if (atributo.Name == "unitCode")
                                    {
                                        UnidadDeMedida_ = BimManager.Sunat.Entidad.Constantes.Catalogo_03_TipoUnidadDeMedida.Abreviatura(atributo.Value);
                                    }
                                }
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cbc:LineExtensionAmount")
                            {
                                SubTotal_SinIgv_ = Convert.ToDecimal(nodeInvoiceLine_Hijo.InnerText);
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cac:PricingReference")
                            {
                                foreach (XmlNode nodePrincingReference_Hijo in nodeInvoiceLine_Hijo.ChildNodes)
                                {
                                    if (nodePrincingReference_Hijo.Name == "cac:AlternativeConditionPrice")
                                    {
                                        foreach (XmlNode nodeAlternativeConditionPrice_Hijo in nodePrincingReference_Hijo.ChildNodes)
                                        {
                                            if (nodeAlternativeConditionPrice_Hijo.Name == "cbc:PriceAmount")
                                            {
                                                PrecioReferencia_IncluyeIgv_ = Convert.ToDecimal(nodeAlternativeConditionPrice_Hijo.InnerText);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cac:TaxTotal")
                            {
                                foreach (XmlNode nodeTaxTotal_Hijo in nodeInvoiceLine_Hijo.ChildNodes)
                                {
                                    if (nodeTaxTotal_Hijo.Name == "cbc:TaxAmount")
                                    {
                                        Impuestos_ = Convert.ToDecimal(nodeTaxTotal_Hijo.InnerText);
                                        break;
                                    }
                                }
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cac:Item")
                            {
                                bool ExistenDatosPasajes = false;
                                string PasajeroNombre = "";
                                string PasajeroDocumentoTipo = "";
                                string PasajeroDocumentoNumero = "";
                                string PasajeroOrigen = "";
                                string PasajeroDestino = "";
                                DateTime PasajeroFecha = new DateTime();
                                DateTime PasajeroHora = new DateTime();
                                string PasajeroAsiento = "";
                                string CodigoItem = "";

                                foreach (XmlNode nodeItem_Hijo in nodeInvoiceLine_Hijo.ChildNodes)
                                {
                                    if (nodeItem_Hijo.Name == "cbc:Description")
                                    {
                                        Descripcion_ = nodeItem_Hijo.InnerText;

                                        //SI la descripcion pertene al Primer Item agregamos los documentos anexos si es que existen
                                        if (Item_ == 1 && DocumentosAnexos != null && DocumentosAnexos.Trim() != "")
                                        {
                                            Descripcion_ += (" (DOCUMENTO ANEXOS: " + DocumentosAnexos + ")");
                                        }
                                    }
                                    //Cuando hay datos de boleto de viaje
                                    else if (nodeItem_Hijo.Name == "cac:AdditionalItemProperty")
                                    {                                        
                                        foreach(XmlNode nodeAdditionalItemProperty_Hijo in nodeItem_Hijo.ChildNodes)
                                        {
                                            if (nodeAdditionalItemProperty_Hijo.Name == "cbc:NameCode")
                                            {
                                                ExistenDatosPasajes = true;
                                                CodigoItem = nodeAdditionalItemProperty_Hijo.InnerText;
                                            }
                                            else if (nodeAdditionalItemProperty_Hijo.Name == "cac:UsabilityPeriod")
                                            {
                                                foreach(XmlNode nodeUsabilityPeriod_Hijo in nodeAdditionalItemProperty_Hijo.ChildNodes)
                                                {
                                                    if (nodeUsabilityPeriod_Hijo.Name == "cbc:StartDate") //Fecha de viaje
                                                    {
                                                        PasajeroFecha = Convert.ToDateTime(nodeUsabilityPeriod_Hijo.InnerText);
                                                    }
                                                    else if (nodeUsabilityPeriod_Hijo.Name == "cbc:StartTime") //Hora de viaje
                                                    {
                                                        PasajeroHora = Convert.ToDateTime(nodeUsabilityPeriod_Hijo.InnerText);
                                                    }
                                                }
                                            }
                                            else if (nodeAdditionalItemProperty_Hijo.Name == "cbc:Value")
                                            {
                                                switch (CodigoItem)
                                                {
                                                    case "3050": //Número de asiento
                                                        PasajeroAsiento = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;

                                                    case "3051": //Número de manifiesto
                                                        break;

                                                    case "3052": //Número de documento de identidad del pasajero
                                                        PasajeroDocumentoNumero = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;

                                                    case "3053": //Tipo de documento de identidad del pasajero
                                                        PasajeroDocumentoTipo = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;

                                                    case "3054": //Nombres y apellidos del pasajero
                                                        PasajeroNombre = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;

                                                    case "3055": //Ubigeo de la ciudad o lugar de destino
                                                        break;

                                                    case "3056": //Dirección de la ciudad o lugar de destino
                                                        PasajeroDestino = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;

                                                    case "3057": //Ubigeo de la ciudad o lugar de origen
                                                        break;

                                                    case "3058": //Dirección de la ciudad o lugar de origen
                                                        PasajeroOrigen = nodeAdditionalItemProperty_Hijo.InnerText;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (nodeInvoiceLine_Hijo.Name == "cac:Price")
                            {
                                foreach (XmlNode nodePrice_Hijo in nodeInvoiceLine_Hijo.ChildNodes)
                                {
                                    if (nodePrice_Hijo.Name == "cbc:PriceAmount")
                                    {
                                        PrecioUnitario_SinIgv_ = Convert.ToDecimal(nodePrice_Hijo.InnerText);
                                        break;
                                    }
                                }
                            }
                        }


                        //Evaluamos los valores para mostrar correctamente los de los comprobante mal llenados hasta el 24/01/2017
                        if (PrecioReferencia_IncluyeIgv_ > 0) //Cuando el precio de referencia es mayor a cero
                        {
                            if (PrecioReferencia_IncluyeIgv_ == PrecioUnitario_SinIgv_) //Si el precio de referencia es igual al precio unitario es un comprobante mal llenado
                            {
                                //Calculamos el total del item (multiplicando el precio unitario sin igv * la cantidad + los impuestos
                                Total_ = (PrecioUnitario_SinIgv_ * Cantidad_) + Impuestos_;

                                //Recalculamos el precio referencial que incluye los impuestos (dividiendo el Total por la cantidad)
                                PrecioReferencia_IncluyeIgv_ = Total_ / Cantidad_;
                            }
                            else //Sino el detalle esta bien llenado
                            {
                                //Total del item lo obtenemos sumando el subtotal sin igv + los impuestos;
                                Total_ = SubTotal_SinIgv_ + Impuestos_;
                            }
                        }
                        else //Sino existe precio de refencia
                        {
                            //Calculamos el total del item (multiplicando el precio unitario sin igv * la cantidad + los impuestos
                            Total_ = (PrecioUnitario_SinIgv_ * Cantidad_) + Impuestos_;

                            //Recalculamos el precio referencial que incluye los impuestos (dividiendo el Total por la cantidad)
                            PrecioReferencia_IncluyeIgv_ = Total_ / Cantidad_;
                        }

                        //Llenamos el detalle
                        ComprobanteElectronico_Detalle objComprobanteElectronico_Detalle =
                            new ComprobanteElectronico_Detalle
                            {
                                Item = Item_,
                                Codigo = Codigo_,
                                Descripcion = Descripcion_,
                                Cantidad = Cantidad_,
                                UnidadDeMedida = UnidadDeMedida_,
                                PrecioUnitario = PrecioReferencia_IncluyeIgv_,
                                Importe = Total_
                            };

                        //Agregamos el detalle a la representacion impresa
                        Detalles.Add(objComprobanteElectronico_Detalle);
                    }
                }
                #endregion


                #region[Nota de crédito]
                //Verificamos si es una nota de credito
                else if (xml.GetElementsByTagName("CreditNote").Item(0) != null)
                {
                    //TipoDocumento
                    TipoDocumento = "07";

                    //SerieNumero
                    XmlNode nodeCreditNote = xml.GetElementsByTagName("CreditNote").Item(0);
                    if (nodeCreditNote != null)
                    {
                        foreach (XmlNode nodeInvoice_Hijo in nodeCreditNote.ChildNodes)
                        {
                            if (nodeInvoice_Hijo.Name == "cbc:ID")
                            {
                                SerieNumero = nodeInvoice_Hijo.InnerText;
                                break;
                            }
                        }
                    }

                    //Fecha Emision
                    XmlNode nodeIssueDate = xml.GetElementsByTagName("cbc:IssueDate").Item(0);
                    FechaEmision = (nodeIssueDate != null ? Convert.ToDateTime(nodeIssueDate.InnerText) : new DateTime());

                    //Hora Emisón
                    if (VersionUBL == "2.1")
                    {
                        XmlNode nodeIssueTime = xml.GetElementsByTagName("cbc:IssueTime").Item(0);
                        HoraEmision = (nodeIssueTime != null ? Convert.ToDateTime(nodeIssueTime.InnerText).ToString("hh:mm tt").Replace(".", "").ToUpper() : "");
                    }

                    //TipoMoneda
                    XmlNode nodeDocumentCurrencyCode = xml.GetElementsByTagName("cbc:DocumentCurrencyCode").Item(0);
                    TipoMoneda = (nodeDocumentCurrencyCode != null ? nodeDocumentCurrencyCode.InnerText : "");


                    //Datos del Titular del comprobante
                    XmlNode nodeAccountingCustomerParty = xml.GetElementsByTagName("cac:AccountingCustomerParty").Item(0);
                    if (nodeAccountingCustomerParty != null)
                    {
                        foreach (XmlNode nodeAccountingCustomerParty_Hijo in nodeAccountingCustomerParty.ChildNodes)
                        {
                            /*Version 2.0 y 2.1*/
                            if (nodeAccountingCustomerParty_Hijo.Name == "cbc:AdditionalAccountID")
                            {
                                Titular_DocumentoTipo = nodeAccountingCustomerParty_Hijo.InnerText;
                            }
                            /*Version 2.0 y 2.1*/
                            else if (nodeAccountingCustomerParty_Hijo.Name == "cbc:CustomerAssignedAccountID")
                            {
                                Titular_DocumentoNumero = nodeAccountingCustomerParty_Hijo.InnerText;
                            }
                            else if (nodeAccountingCustomerParty_Hijo.Name == "cac:Party")
                            {
                                foreach (XmlNode nodeParty_Hijo in nodeAccountingCustomerParty_Hijo.ChildNodes)
                                {
                                    /*Version 2.1*/
                                    if (nodeParty_Hijo.Name == "cac:PartyIdentification")
                                    {
                                        foreach (XmlNode nodePartyIdentification_Hijo in nodeParty_Hijo.ChildNodes)
                                        {
                                            if (nodePartyIdentification_Hijo.Name == "cbc:ID")
                                            {
                                                Titular_DocumentoTipo = nodePartyIdentification_Hijo.Attributes.GetNamedItem("schemeID").InnerText;
                                                Titular_DocumentoNumero = nodePartyIdentification_Hijo.InnerText;
                                            }
                                        }
                                    }
                                    /*Version 2.0*/
                                    else if (nodeParty_Hijo.Name == "cac:PartyLegalEntity")
                                    {
                                        foreach (XmlNode nodePartyLegalEntity_Hijo in nodeParty_Hijo.ChildNodes)
                                        {
                                            if (nodePartyLegalEntity_Hijo.Name == "cbc:RegistrationName")
                                            {
                                                Titular_NombreLegal = nodePartyLegalEntity_Hijo.InnerText;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    //DigestValue
                    XmlNode nodeDigestValue = xml.GetElementsByTagName("DigestValue").Item(0);
                    DigestValue = (nodeDigestValue != null ? nodeDigestValue.InnerText : "");


                    //SignatureValue
                    XmlNode nodeSignatureValue = xml.GetElementsByTagName("SignatureValue").Item(0);
                    SignatureValue = (nodeSignatureValue != null ? nodeSignatureValue.InnerText : "");


                    string Codigo = ""; //Variable para identificar los totales y los datos adicionales


                    //Totales Version 2.0
                    foreach (XmlNode nodeAdditionalMonetaryTotal in xml.GetElementsByTagName("sac:AdditionalMonetaryTotal"))
                    {
                        foreach (XmlNode nodeAdditionalInformation_Hijo in nodeAdditionalMonetaryTotal.ChildNodes)
                        {
                            if (nodeAdditionalInformation_Hijo.Name == "cbc:ID")
                            {
                                Codigo = nodeAdditionalInformation_Hijo.InnerText;
                            }
                            else if (nodeAdditionalInformation_Hijo.Name == "cbc:PayableAmount")
                            {
                                switch (Codigo)
                                {
                                    case "1001": //Gravadas
                                        Gravadas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1002": //Inafecta
                                        Inafectas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1003": //Exonerada
                                        Exoneradas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;

                                    case "1004": //Gratuitas
                                        Gratuitas = Convert.ToDecimal(nodeAdditionalInformation_Hijo.InnerText != "" ? nodeAdditionalInformation_Hijo.InnerText : "0");
                                        break;
                                }
                            }
                        }
                    }


                    //Descripcion General
                    XmlNode nodeDiscrepancyResponse = xml.GetElementsByTagName("cac:DiscrepancyResponse").Item(0);
                    foreach (XmlNode nodeDiscrepancyResponse_Hijo in nodeDiscrepancyResponse.ChildNodes)
                    {
                        if (nodeDiscrepancyResponse_Hijo.Name == "cbc:Description")
                        {
                            NotaCredito_NotaDebito_Descripcion_General = nodeDiscrepancyResponse_Hijo.InnerText;
                            break;
                        }
                    }


                    //Documento Modifica
                    foreach (XmlNode nodeBillingReference in xml.GetElementsByTagName("cac:BillingReference"))
                    {
                        foreach (XmlNode nodeBillingReference_Hijo in nodeBillingReference.ChildNodes)
                        {
                            if (nodeBillingReference_Hijo.Name == "cac:InvoiceDocumentReference")
                            {
                                ComprobanteElectronico_DocumentoModifica objDocumentoModifica = new ComprobanteElectronico_DocumentoModifica();
                                foreach (XmlNode nodeInvoiceDocumentReference_Hijo in nodeBillingReference_Hijo.ChildNodes)
                                {
                                    if (nodeInvoiceDocumentReference_Hijo.Name == "cbc:ID")
                                    {
                                        objDocumentoModifica.SerieCorrelativo = nodeInvoiceDocumentReference_Hijo.InnerText;
                                    }
                                    else if (nodeInvoiceDocumentReference_Hijo.Name == "cbc:DocumentTypeCode")
                                    {
                                        objDocumentoModifica.TipoDocumentoCodigo = nodeInvoiceDocumentReference_Hijo.InnerText;
                                    }
                                }
                                DocumentosModifica.Add(objDocumentoModifica);
                            }
                        }
                    }


                    //Impuestos Version 2.0
                    XmlNode nodeTaxTotal = xml.GetElementsByTagName("cac:TaxTotal").Item(0);
                    if (nodeTaxTotal != null)
                    {
                        foreach (XmlNode nodeTaxTotal_Hijo in nodeTaxTotal.ChildNodes)
                        {   //Forma1
                            if (nodeTaxTotal_Hijo.Name == "cbc:TaxAmount")
                            {
                                Igv = Convert.ToDecimal(nodeTaxTotal_Hijo.InnerText);
                            }

                            //Forma 2
                            if (nodeTaxTotal_Hijo.Name == "cac:TaxSubtotal")
                            {
                                decimal Impuesto = 0; //Variable para guardar de forma temporal el importe del impuesto

                                foreach (XmlNode nodeTaxSubtotal_Hijo in nodeTaxTotal_Hijo.ChildNodes)
                                {
                                    if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxAmount") //Capturamos el importe del impuesto
                                    {
                                        Impuesto = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cac:TaxCategory")
                                    {
                                        foreach (XmlNode nodeTaxCategory_Hijo in nodeTaxSubtotal_Hijo.ChildNodes)
                                        {
                                            if (nodeTaxCategory_Hijo.Name == "cac:TaxScheme")
                                            {
                                                foreach (XmlNode nodeTaxScheme_Hijo in nodeTaxCategory_Hijo.ChildNodes)
                                                {
                                                    if (nodeTaxScheme_Hijo.Name == "cbc:Name") //Verificamos el nombre del tipo de impuesto
                                                    {
                                                        if (nodeTaxScheme_Hijo.InnerText == "IGV") //Cuando es IGV
                                                        {
                                                            Igv = Impuesto;         //Asignamos
                                                            Impuesto = 0;           //Limpiamos para el proximo impuesto
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    /*Totales Version 2.1*/
                    if (VersionUBL == "2.1")
                    {
                        nodeTaxTotal = xml.GetElementsByTagName("cac:TaxTotal").Item(0);

                        foreach (XmlNode nodeTaxTotal_Hijo in nodeTaxTotal.ChildNodes)
                        {
                            if (nodeTaxTotal_Hijo.Name == "cac:TaxSubtotal")
                            {
                                decimal Impuesto = 0m;
                                decimal ImporteBase = 0m;
                                foreach (XmlNode nodeTaxSubtotal_Hijo in nodeTaxTotal_Hijo.ChildNodes)
                                {
                                    if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxableAmount")
                                    {
                                        ImporteBase = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cbc:TaxAmount")
                                    {
                                        Impuesto = Convert.ToDecimal(nodeTaxSubtotal_Hijo.InnerText);
                                    }
                                    else if (nodeTaxSubtotal_Hijo.Name == "cac:TaxCategory")
                                    {
                                        foreach (XmlNode nodeTaxScheme in nodeTaxSubtotal_Hijo.ChildNodes)
                                        {
                                            if (nodeTaxScheme.Name == "cac:TaxScheme")
                                            {
                                                foreach (XmlNode nodeTaxScheme_Hijo in nodeTaxScheme.ChildNodes)
                                                {
                                                    if (nodeTaxScheme_Hijo.Name == "cbc:ID")
                                                    {
                                                        switch (nodeTaxScheme_Hijo.InnerText)
                                                        {
                                                            case "1000": //Gravada e IGV
                                                                Gravadas = ImporteBase;
                                                                Igv = Impuesto;
                                                                break;

                                                            case "1015": //IVAP
                                                                break;

                                                            case "2000": //ISC
                                                                break;

                                                            case "9995": //Exportación
                                                                break;

                                                            case "9996": //Gratuita
                                                                Gratuitas = ImporteBase;
                                                                break;

                                                            case "9997": //Exonerada
                                                                Exoneradas = ImporteBase;
                                                                break;

                                                            case "9998": //Inafecta
                                                                Inafectas = ImporteBase;
                                                                break;

                                                            case "9999": //Otros Conceptos
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    //Importe Total
                    XmlNode nodeLegalMonetaryTotal = xml.GetElementsByTagName("cac:LegalMonetaryTotal").Item(0);
                    if (nodeLegalMonetaryTotal != null)
                    {
                        foreach (XmlNode nodeLegalMonetaryTotal_Hijo in nodeLegalMonetaryTotal.ChildNodes)
                        {
                            if (nodeLegalMonetaryTotal_Hijo.Name == "cbc:PayableAmount")
                            {
                                ImporteTotal = Convert.ToDecimal(nodeLegalMonetaryTotal_Hijo.InnerText);
                            }
                        }
                    }


                    //Datos Adicionales Según SUNAT Version 2.0
                    foreach (XmlNode nodeAdditionalProperty in xml.GetElementsByTagName("sac:AdditionalProperty"))
                    {
                        // Recorremos cada dato adicional
                        foreach (XmlNode nodeAdditionalProperty_Hijo in nodeAdditionalProperty.ChildNodes)
                        {
                            //Obtenemos el Codigo del datos adicional
                            if (nodeAdditionalProperty_Hijo.Name == "cbc:ID")
                            {
                                Codigo = nodeAdditionalProperty_Hijo.InnerText;
                            }
                            //Asignamos el valor según el código del dato adicional
                            else if (nodeAdditionalProperty_Hijo.Name == "cbc:Value")
                            {
                                switch (Codigo.ToUpper())
                                {

                                    case "1000": //Son (Monto en el Letras)
                                        Son = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "1002": //Transferencia gratuita de un bien y/o servicio prestado gratuitamente
                                        TransferenciaGratuitaLeyenda = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "HORA EMISION":
                                        HoraEmision = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "CAJERO":
                                        Cajero = nodeAdditionalProperty_Hijo.InnerText;
                                        break;

                                    case "PUNTO EMISION":
                                        PuntoEmision = nodeAdditionalProperty_Hijo.InnerText;
                                        break;
                                }
                            }
                        }
                    }



                    /*Datos Adicionales Según SUNAT Versión 2.1*/
                    foreach (XmlNode nodeNote in xml.GetElementsByTagName("cbc:Note"))
                    {
                        switch (nodeNote.Attributes["languageLocaleID"].InnerText)
                        {
                            case "1000": //Monto en letras
                                Son = nodeNote.InnerText;
                                break;

                            case "1002": //Transferencia Gratuita
                                TransferenciaGratuitaLeyenda = nodeNote.InnerText;
                                break;
                        }
                    }


                    //Datos Adicionales Internos
                    foreach (XmlNode nodeDatoAdicional in xml.GetElementsByTagName("DatoAdicional"))
                    {
                        // Recorremos cada dato adicional
                        foreach (XmlNode nodeDatoAdicional_Hijo in nodeDatoAdicional.ChildNodes)
                        {
                            //Obtenemos el Codigo del datos adicional
                            if (nodeDatoAdicional_Hijo.Name == "Codigo")
                            {
                                Codigo = nodeDatoAdicional_Hijo.InnerText;
                            }
                            //Asignamos el valor según el código del dato adicional
                            else if (nodeDatoAdicional_Hijo.Name == "Valor")
                            {
                                switch (Codigo.ToUpper())
                                {
                                    case "PUNTO EMISION":
                                        PuntoEmision = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "FORMATO CODIGO BARRAS": //Para indicar el tipo de código de barras con el que se imprimirá
                                        Formato_CodigoBarras = nodeDatoAdicional_Hijo.InnerText;
                                        break;

                                    case "HORA EMISION":
                                        HoraEmision = nodeDatoAdicional_Hijo.InnerText;
                                        break;


                                    case "CAJERO":
                                        Cajero = nodeDatoAdicional_Hijo.InnerText;
                                        break;
                                }
                            }
                        }
                    }


                    //Gravada - En caso sea uno de los comprobantes antiguos donde no aparecia el total, validamos si no existe ningun valor de los totales para calcular el valor de gravadas manualmente
                    if (Gravadas == 0 && Exoneradas == 0 && Inafectas == 0 && Gratuitas == 0)
                    {
                        //Si el Igv es mayor a cero es monto gravado
                        if (Igv > 0) Gravadas = ImporteTotal - Igv;
                        //Si el igv es cero es monto exonerado
                        else Exoneradas = ImporteTotal;
                    }

                    //Son
                    Son = new BimManager.Sunat.Entidad.NumberToLetters().ToCustomCardinal(ImporteTotal).ToUpper();

                    //Detalle
                    foreach (XmlNode nodeCreditNoteLine in xml.GetElementsByTagName("cac:CreditNoteLine"))
                    {
                        int Item_ = 0;
                        string Codigo_ = "";
                        string Descripcion_ = "";
                        decimal Cantidad_ = 0;
                        string UnidadDeMedida_ = "";
                        decimal PrecioUnitario_SinIgv_ = 0;
                        decimal PrecioReferencia_IncluyeIgv_ = 0;
                        decimal SubTotal_SinIgv_ = 0;
                        decimal Impuestos_ = 0;
                        decimal Total_ = 0;

                        foreach (XmlNode nodeCreditNoteLine_Hijo in nodeCreditNoteLine.ChildNodes)
                        {
                            if (nodeCreditNoteLine_Hijo.Name == "cbc:ID")
                            {
                                Item_ = Convert.ToInt32(nodeCreditNoteLine_Hijo.InnerText);
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cbc:CreditedQuantity")
                            {
                                Cantidad_ = Convert.ToDecimal(nodeCreditNoteLine_Hijo.InnerText);
                                foreach (XmlAttribute atributo in nodeCreditNoteLine_Hijo.Attributes)
                                {
                                    if (atributo.Name == "unitCode")
                                    {
                                        UnidadDeMedida_ = BimManager.Sunat.Entidad.Constantes.Catalogo_03_TipoUnidadDeMedida.Abreviatura(atributo.Value);
                                    }
                                }
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cbc:LineExtensionAmount")
                            {
                                SubTotal_SinIgv_ = Convert.ToDecimal(nodeCreditNoteLine_Hijo.InnerText);
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cac:PricingReference")
                            {
                                foreach (XmlNode nodePrincingReference_Hijo in nodeCreditNoteLine_Hijo.ChildNodes)
                                {
                                    if (nodePrincingReference_Hijo.Name == "cac:AlternativeConditionPrice")
                                    {
                                        foreach (XmlNode nodeAlternativeConditionPrice_Hijo in nodePrincingReference_Hijo.ChildNodes)
                                        {
                                            if (nodeAlternativeConditionPrice_Hijo.Name == "cbc:PriceAmount")
                                            {
                                                PrecioReferencia_IncluyeIgv_ = Convert.ToDecimal(nodeAlternativeConditionPrice_Hijo.InnerText);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cac:TaxTotal")
                            {
                                foreach (XmlNode nodeTaxTotal_Hijo in nodeCreditNoteLine_Hijo.ChildNodes)
                                {
                                    if (nodeTaxTotal_Hijo.Name == "cbc:TaxAmount")
                                    {
                                        Impuestos_ = Convert.ToDecimal(nodeTaxTotal_Hijo.InnerText);
                                        break;
                                    }
                                }
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cac:Item")
                            {
                                foreach (XmlNode nodeItem_Hijo in nodeCreditNoteLine_Hijo.ChildNodes)
                                {
                                    if (nodeItem_Hijo.Name == "cbc:Description")
                                    {
                                        Descripcion_ = nodeItem_Hijo.InnerText;
                                    }
                                    else if (nodeItem_Hijo.Name == "cac:SellersItemIdentification")
                                    {
                                        foreach (XmlNode nodeID in nodeItem_Hijo.ChildNodes)
                                        {
                                            if (nodeID.Name == "cbc:ID")
                                            {
                                                Codigo_ = nodeID.InnerText;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (nodeCreditNoteLine_Hijo.Name == "cac:Price")
                            {
                                foreach (XmlNode nodePrice_Hijo in nodeCreditNoteLine_Hijo.ChildNodes)
                                {
                                    if (nodePrice_Hijo.Name == "cbc:PriceAmount")
                                    {
                                        PrecioUnitario_SinIgv_ = Convert.ToDecimal(nodePrice_Hijo.InnerText);
                                        break;
                                    }
                                }
                            }
                        }


                        //Evaluamos los valores para mostrar correctamente los de los comprobante mal llenados hasta el 24/01/2017
                        if (PrecioReferencia_IncluyeIgv_ > 0) //Cuando el precio de referencia es mayor a cero
                        {
                            if (PrecioReferencia_IncluyeIgv_ == PrecioUnitario_SinIgv_) //Si el precio de referencia es igual al precio unitario es un comprobante mal llenado
                            {
                                //Calculamos el total del item (multiplicando el precio unitario sin igv * la cantidad + los impuestos
                                Total_ = (PrecioUnitario_SinIgv_ * Cantidad_) + Impuestos_;

                                //Recalculamos el precio referencial que incluye los impuestos (dividiendo el Total por la cantidad)
                                PrecioReferencia_IncluyeIgv_ = Total_ / Cantidad_;
                            }
                            else //Sino el detalle esta bien llenado
                            {
                                //Total del item lo obtenemos sumando el subtotal sin igv + los impuestos;
                                Total_ = SubTotal_SinIgv_ + Impuestos_;
                            }
                        }
                        else //Sino existe precio de referencia
                        {
                            //Calculamos el total del item (multiplicando el precio unitario sin igv * la cantidad + los impuestos
                            Total_ = (PrecioUnitario_SinIgv_ * Cantidad_) + Impuestos_;

                            //Recalculamos el precio referencial que incluye los impuestos (dividiendo el Total por la cantidad)
                            PrecioReferencia_IncluyeIgv_ = Total_ / Cantidad_;
                        }

                        //Llenamos el detalle
                        ComprobanteElectronico_Detalle objComprobanteElectronico_Detalle =
                            new ComprobanteElectronico_Detalle
                            {
                                Item = Item_,
                                Codigo = Codigo_,
                                Descripcion = Descripcion_,
                                Cantidad = Cantidad_,
                                UnidadDeMedida = UnidadDeMedida_,
                                PrecioUnitario = PrecioReferencia_IncluyeIgv_,
                                Importe = Total_
                            };

                        //Agregamos el detalle a la representacion impresa
                        Detalles.Add(objComprobanteElectronico_Detalle);
                    }
                }
                #endregion

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        private string itextSharp_Fuente { get { return "C:/WINDOWS/FONTS/CONSOLA.TTF"; } }

        private BaseFont itextSharp_baseFont { get { return BaseFont.CreateFont(itextSharp_Fuente, BaseFont.CP1252, BaseFont.EMBEDDED); } }

        private iTextSharp.text.Font itextSharp_fontNormal { get { return new iTextSharp.text.Font(itextSharp_baseFont, 10); } }

        private iTextSharp.text.Font itextSharp_fontNegrita { get { return new iTextSharp.text.Font(itextSharp_baseFont, 10, 1); } }

        private iTextSharp.text.Font itextSharp_fontDobleNegrita { get { return new iTextSharp.text.Font(itextSharp_baseFont, 20, 1); } }

        private iTextSharp.text.Paragraph itextSharp_Paragraph(string Texto, iTextSharp.text.Font itextSharp_Font)
        {
            return itextSharp_Paragraph(Texto, itextSharp_Font, iTextSharp.text.Element.ALIGN_LEFT, false);
        }

        private iTextSharp.text.Paragraph itextSharp_Paragraph(string Texto, iTextSharp.text.Font itextSharp_Font, int itextSharp_Element_Aligment)
        {
            return itextSharp_Paragraph(Texto, itextSharp_Font, itextSharp_Element_Aligment, false);
        }

        private iTextSharp.text.Paragraph itextSharp_Paragraph(string Texto, iTextSharp.text.Font itextSharp_Font, int itextSharp_Element_Aligment, bool saltoDeLineaPrevio)
        {
            Paragraph linea = new Paragraph(Texto, itextSharp_Font);
            linea.Alignment = itextSharp_Element_Aligment;
            linea.SetLeading(0, (saltoDeLineaPrevio ? 2f : 1f));

            return linea;
        }

        private iTextSharp.text.Image itextSharp_Image(Bitmap Bitmap_Logo)
        {
            iTextSharp.text.Image Logo;

            System.Drawing.Image img = Bitmap_Logo;

            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                Logo = iTextSharp.text.Image.GetInstance(stream.ToArray());
            }

            Logo.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;

            return Logo;
        }

        public void Generar_Ticket_En_Pdf(string RutaPdf)
        {
            try
            {
                float tamañoBase = 420; //20 por linea
                tamañoBase += 97; //97 por el logo


                foreach(ComprobanteElectronico_Detalle detalle in Detalles)
                {
                    decimal Lineas = 1;

                    if ((detalle.Codigo + " " + detalle.Descripcion).Length > 48)
                    {
                        Lineas = Convert.ToDecimal((detalle.Codigo + " " + detalle.Descripcion).Length / 48);
                    }
                    tamañoBase += Convert.ToSingle(Math.Ceiling(Lineas) * 20);
                }
                if (Inafectas > 0) tamañoBase += 20;
                if (Exoneradas > 0) tamañoBase += 20;

                iTextSharp.text.Rectangle r = new iTextSharp.text.Rectangle(275, tamañoBase);
                iTextSharp.text.Document document = new iTextSharp.text.Document(r, 5, 5, 5, 5);
                PdfWriter.GetInstance
                (
                    document, 
                    new FileStream(RutaPdf, FileMode.OpenOrCreate)
                );
                document.Open();

                //Logo
                document.Add(itextSharp_Image(BimManager.Sunat.Entidad.Properties.Resources.Alinur));

                //Razon Social
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        EmpresaDatos.RazonSocial,
                        itextSharp_fontNormal,
                        iTextSharp.text.Element.ALIGN_CENTER,
                        true
                    )
                );

                //Direccion fiscal
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Direccion + 
                        (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion != "" ? " " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion : ""),
                        itextSharp_fontNormal,
                        Element.ALIGN_CENTER
                    )
                );



                //Departamento - Provincia - Distrito
                if (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento != "")
                {
                    document.Add
                    (
                        itextSharp_Paragraph
                        (
                            BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento +
                            (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia != "" ? " - " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia : "") +
                            (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito != "" ? " - " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito : ""),
                            itextSharp_fontNormal,
                            Element.ALIGN_CENTER
                        )
                    );
                }

                //Punto de Emisión
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        (PuntoEmision != null ? PuntoEmision : ""),
                        itextSharp_fontNormal,
                        Element.ALIGN_CENTER
                    )
                );

                //RUC
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        "RUC: " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RUC, 
                        itextSharp_fontNormal,
                        Element.ALIGN_CENTER
                    )
                );

                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));


                //Tipo de comprobante
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        TipoDocumento_Nombre + " ELECTRÓNICA",
                        itextSharp_fontNormal,
                        Element.ALIGN_CENTER
                    )
                );

                //Serie y correlativo
                document.Add
                (
                    itextSharp_Paragraph
                    (
                        SerieNumero,
                        itextSharp_fontDobleNegrita,
                        Element.ALIGN_CENTER
                    )
                );

                //Fecha Emisión
                document.Add
                (
                   itextSharp_Paragraph
                   (
                       "FECHA EMISIÓN: " + FechaEmision.ToShortDateString(),
                       itextSharp_fontNormal,
                       Element.ALIGN_CENTER
                    )
                );


                //Hora Emisión
                document.Add
                (
                   itextSharp_Paragraph
                   (
                       "HORA EMISIÓN: " + HoraEmision,
                       itextSharp_fontNormal,
                       Element.ALIGN_CENTER
                    )
                );


                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                //Cliente
                document.Add(itextSharp_Paragraph("CLIENTE: " + Titular_NombreLegal, itextSharp_fontNormal));
                if (Titular_DocumentoTipo_Nombre != "")
                {
                    document.Add(itextSharp_Paragraph(Titular_DocumentoTipo_Nombre + ": " + Titular_DocumentoNumero, itextSharp_fontNormal));
                }

                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                //Cabecera detalle
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("DESCRIPCIÓN", " ", 48), itextSharp_fontNormal));
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("CANTIDAD", " ", 16)
                                                  + RellenarCaracterDerecha("PRECIO UNITARIO", " ", 16)
                                                  + RellenarCaracterIzquierda("SUBTOTAL", " ", 16), itextSharp_fontNormal));

                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                //Detalle
                foreach (RepresentacionImpresa.ComprobanteElectronico_Detalle Detalle in Detalles)
                {
                    document.Add(itextSharp_Paragraph((Detalle.Codigo + " " + Detalle.Descripcion).Trim(), itextSharp_fontNormal));
                    document.Add(itextSharp_Paragraph(RellenarCaracterDerecha(Detalle.Cantidad.ToString("#,#0.00") + " " + Detalle.UnidadDeMedida.ToUpper(), " ", 16)
                                                       + RellenarCaracterDerecha("S/ " + Detalle.PrecioUnitario.ToString("#,#0.00"), " ", 16)
                                                       + RellenarCaracterIzquierda("S/ " + (Detalle.PrecioUnitario * Detalle.Cantidad).ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                }

                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                //Totales
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("OP. GRAVADA", " ", 32) + RellenarCaracterIzquierda("S/ " + Gravadas.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                if (Inafectas > 0) document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("OP. INAFECTA", " ", 32) + RellenarCaracterIzquierda("S/ " + Inafectas.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                if (Exoneradas > 0) document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("OP. EXONERADA", " ", 32) + RellenarCaracterIzquierda("S/ " + Exoneradas.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("DESCUENTO", " ", 32) + RellenarCaracterIzquierda("S/ " + Descuentos.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("I.G.V. (18.00%)", " ", 32) + RellenarCaracterIzquierda("S/ " + Igv.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                document.Add(itextSharp_Paragraph(RellenarCaracterDerecha("IMPORTE TOTAL", " ", 32) + RellenarCaracterIzquierda("S/ " + ImporteTotal.ToString("#,#0.00"), " ", 16), itextSharp_fontNormal));
                
                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                document.Add(itextSharp_Paragraph("SON: " + new NumberToLetters().ToCustomCardinal(ImporteTotal).ToUpper().Trim() + " SOLES", itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER));
                
                //Linea separadora
                document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));

                //QR
                string RutaImagenCodigoBarras = System.IO.Path.GetTempPath() + System.IO.Path.GetRandomFileName() + ".jpg";

                var qrEncoder = new Gma.QrCodeNet.Encoding.QrEncoder(ErrorCorrectionLevel.Q);
                var qrCode = qrEncoder.Encode(CodigoBarras_QR);

                var renderer = new Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(new FixedModuleSize(2, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                using (var stream = new FileStream(RutaImagenCodigoBarras, FileMode.Create))
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg, stream);

                iTextSharp.text.Image jpg =
                    iTextSharp.text.Image.GetInstance(RutaImagenCodigoBarras);
                jpg.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;

                document.Add(jpg);

                //DigestValue
                document.Add(itextSharp_Paragraph("Hash: " + DigestValue, itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER, true));

                //Datos finales
                document.Add(itextSharp_Paragraph("ESTO ES UN REPRESENTACIÓN IMPRESA DE LA ", itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER));
                document.Add(itextSharp_Paragraph(TipoDocumento_Nombre + " ELECTRÓNICA", itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER));
                //stringTicket += SaltoDeLinea(true) + "Para consultar el comprobante ingrese a" + SaltoDeLinea(true) + "www.emtrafesa.com";

                //document.Add(itextSharp_Paragraph(LineaLLenaDeUnCaracter("-", 48), itextSharp_fontNormal));
                //document.Add(itextSharp_Paragraph("ATENDIDO POR: " + Cajero, itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER));
                //document.Add(itextSharp_Paragraph("¡Gracias por su visita vuelva pronto!", itextSharp_fontNormal, iTextSharp.text.Element.ALIGN_CENTER));

                document.Close();
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }



        /// <summary>
        /// Genera una cadena de comandos para la impresión de un ticket e imprime el cantidad de copias en la impresa indicada
        /// </summary>
        /// <param name="ImpresoraNombre"></param>        
        public void Generar_Ticket_E_Imprimir(int Copias, string ImpresoraNombre)
        {
            try
            {
                string ImpresoraEncontrada = Buscar_Impresora(ImpresoraNombre);



                string stringTicket = IniciarImpresora;
                stringTicket += TablaDeCaracteres(6); //Usamos el valor 6 que hace referencia a CodePage 860(Portuguese) y es la única que soporta los caracteres del español
                //stringTicket += Logo_To_Hexadecimal(BimManager.Sunat.Entidad.Properties.Resources.logoOriginal);

                stringTicket += Interlineado(55);
                stringTicket += /*SaltoDeLinea(true) +*/ AlinearCentro + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RazonSocial;
                stringTicket += SaltoDeLinea(true) + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Direccion + (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion != "" ? " " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion : "");
                if (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento != "")
                {
                    stringTicket += SaltoDeLinea(true) + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento + 
                                    (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia != "" ? " - " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia : "") +
                                    (BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito != "" ? " - " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito : "");
                }
                //stringTicket += SaltoDeLinea(true) + (PuntoEmision != null ? PuntoEmision : "");
                stringTicket += SaltoDeLinea(true) + "RUC: " + BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RUC;


                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);
                stringTicket += SaltoDeLinea(true) + TipoDocumento_Nombre + " ELECTRÓNICA";
                stringTicket += SaltoDeLinea(true) + FormatoNegritaActivar + FormatoDobleActivar + SerieNumero + FormatoDobleDesactivar + FormatoNegritaDesactivar;
                stringTicket += SaltoDeLinea(true) + "FECHA EMISIÓN: " + FechaEmision.ToShortDateString();
                stringTicket += SaltoDeLinea(true) + "HORA EMISIÓN: " + HoraEmision;
                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);

                stringTicket += SaltoDeLinea(true) + AlinearIzquierda;
                stringTicket += "CLIENTE: " + Titular_NombreLegal;
                if (Titular_DocumentoTipo_Nombre != "")
                {
                    stringTicket += SaltoDeLinea(true) + Titular_DocumentoTipo_Nombre + ": " + Titular_DocumentoNumero;
                }
                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);

                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("DESCRIPCIÓN", " ", 48);
                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("CANTIDAD", " ", 16)
                                                   + RellenarCaracterDerecha("PRECIO UNITARIO", " ", 16)
                                                   + RellenarCaracterIzquierda("SUBTOTAL", " ", 16);
                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);

                foreach (RepresentacionImpresa.ComprobanteElectronico_Detalle Detalle in Detalles)
                {
                    stringTicket += SaltoDeLinea(true) + (Detalle.Codigo + " " + Detalle.Descripcion).Trim();
                    stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha(Detalle.Cantidad.ToString("#,#0.00") + " " + Detalle.UnidadDeMedida.ToUpper(), " ", 16)
                                                       + RellenarCaracterDerecha("S/ " + Detalle.PrecioUnitario.ToString("#,#0.00"), " ", 16)
                                                       + RellenarCaracterIzquierda("S/ " + (Detalle.PrecioUnitario * Detalle.Cantidad).ToString("#,#0.00"), " ", 16);
                }

                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);
                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("OP. GRAVADA", " ", 32) + RellenarCaracterIzquierda("S/ " + Gravadas.ToString("#,#0.00"), " ", 16);
                if (Inafectas > 0) stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("OP. INAFECTA", " ", 32) + RellenarCaracterIzquierda("S/ " + Inafectas.ToString("#,#0.00"), " ", 16);
                if (Exoneradas > 0) stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("OP. EXONERADA", " ", 32) + RellenarCaracterIzquierda("S/ " + Exoneradas.ToString("#,#0.00"), " ", 16);
                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("DESCUENTO", " ", 32) + RellenarCaracterIzquierda("S/ " + Descuentos.ToString("#,#0.00"), " ", 16);
                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("I.G.V. (18.00%)", " ", 32) + RellenarCaracterIzquierda("S/ " + Igv.ToString("#,#0.00"), " ", 16);
                stringTicket += SaltoDeLinea(true) + RellenarCaracterDerecha("IMPORTE TOTAL", " ", 32) + RellenarCaracterIzquierda("S/ " + ImporteTotal.ToString("#,#0.00"), " ", 16);


                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);
                stringTicket += SaltoDeLinea(true) + AlinearCentro + "SON: " + new NumberToLetters().ToCustomCardinal(ImporteTotal).ToUpper().Trim() + " SOLES";
                stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);
                
                //Codigo de barras
                stringTicket += SaltoDeLinea(2, true) + AlinearCentro + CodigoBarras_Formato_QR(49, 6, 50, CodigoBarras_QR);

                stringTicket += SaltoDeLinea(true) + "Hash: " + DigestValue;
                stringTicket += SaltoDeLinea(true) + "ESTO ES UN REPRESENTACIÓN IMPRESA DE LA ";
                stringTicket += SaltoDeLinea(true) + TipoDocumento_Nombre + " ELECTRÓNICA";
                //stringTicket += SaltoDeLinea(true) + "Para consultar el comprobante ingrese a" + SaltoDeLinea(true) + "www.emtrafesa.com";

                //stringTicket += SaltoDeLinea(true) + LineaLLenaDeUnCaracter("-", 48);
                //stringTicket += SaltoDeLinea(true) + "ATENDIDO POR: " + Cajero;
                //stringTicket += SaltoDeLinea(true) + "¡Gracias por su visita vuelva pronto!";



                stringTicket += SaltoDeLinea(false) + CorteDePapel;


                for (int Copia = 2; Copia <= Copias; Copia++)
                {
                    stringTicket += stringTicket;
                }

                SendStringToPrinter(TipoDocumento_Nombre + " " + SerieNumero, ImpresoraEncontrada, stringTicket);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        public string VersionUBL { get; set; }

        public string TipoDocumento { get; set; }

        public string TipoDocumento_Nombre
        {
            get
            {
                string TipoDocumento_Nombre_ = "";
                switch (TipoDocumento)
                {
                    case "01":
                        TipoDocumento_Nombre_ = "FACTURA";
                        break;

                    case "03":
                        TipoDocumento_Nombre_ = "BOLETA DE VENTA";
                        break;

                    case "07":
                        TipoDocumento_Nombre_ = "NOTA DE CREDITO";
                        break;

                    case "08":
                        TipoDocumento_Nombre_ = "NOTA DE DEBITO";
                        break;
                }
                return TipoDocumento_Nombre_;
            }
        }

        public string SerieNumero { get; set; }

        public DateTime FechaEmision { get; set; }

        public string Clave { get; set; }

        public string PuntoEmision { get; set; }

        public string Formato { get; set; }

        public string Formato_CodigoBarras { get; set; }

        public string Pasajero { get; set; }

        public string PasajeroNombreApellido { get; set; }

        public string PasajeroDocumento { get; set; }

        public string ViajeRuta { get; set; }

        public string ViajeFechaHora { get; set; }

        public string ViajeAsiento { get; set; }

        public string DesplazamientoTipo { get; set; }

        public string EmbarqueLugar { get; set; }

        public string DesembarqueLugar { get; set; }

        public string PolizaTexto { get; set; }

        public string Boleto { get; set; }

        public string NroAsiento { get; set; }

        public string NroBultos { get; set; }

        public string TipoUnidad { get; set; }

        public string FechaHoraViaje { get; set; }

        public string HoraEmision { get; set; }

        public string Cajero { get; set; }

        public string EquipajeDetalle { get; set; }

        public string Titular_DocumentoTipo { get; set; }

        public string Titular_DocumentoTipo_Nombre
        {
            get
            {
                string Titular_DocumentoTipo_Nombre_ = "";

                if (Titular_DocumentoTipo == BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Ruc)
                {
                    Titular_DocumentoTipo_Nombre_ = "RUC";
                }
                else if (Titular_DocumentoTipo == BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Dni)
                {
                    Titular_DocumentoTipo_Nombre_ = "DNI";
                }
                else if (Titular_DocumentoTipo == BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Pasaporte)
                {
                    Titular_DocumentoTipo_Nombre_ = "PAS";
                }
                else if (Titular_DocumentoTipo == BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.CarnetExtranjeria)
                {
                    Titular_DocumentoTipo_Nombre_ = "C.E.";
                }

                return Titular_DocumentoTipo_Nombre_;
            }
        }

        public string Titular_DocumentoNumero { get; set; }

        public string Titular_NombreLegal { get; set; }

        public string Titular_DireccionTelefonos { get; set; }

        public string Mensajero { get; set; }

        public string Remitente { get; set; }

        public string Consignado { get; set; }

        public List<string> ConsignadosAdicionales { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public string FormaEntrega { get; set; }

        public string CodigoCliente { get; set; }

        public string Servicio { get; set; }

        public string OrdenServicio { get; set; }

        public string Anexo { get; set; }

        public string DocumentosAnexos { get; set; }

        public string CondicionPago { get; set; }

        public string Bultos { get; set; }

        public string SegunGuia { get; set; }

        public string DireccionRecojo { get; set; }

        public string DireccionEntrega { get; set; }

        public string Observacion { get; set; }

        public string TipoMoneda { get; set; }

        public string TipoMoneda_Nombre
        {
            get
            {
                string TipoMoneda_Nombre_ = "";

                switch(TipoMoneda)
                {
                    case "PEN":
                        TipoMoneda_Nombre_ = "SOLES";
                        break;

                    case "USD":
                        TipoMoneda_Nombre_ = "DOLARES AMERICANOS";
                        break;

                    case "EUR":
                        TipoMoneda_Nombre_ = "EUROS";
                        break;
                }

                return TipoMoneda_Nombre_;
            }
        }

        public decimal Exoneradas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Descuentos { get; set; }

        public decimal Igv { get; set; }

        public decimal OtrosCargos { get; set; }

        public decimal OtrosTributos { get; set; }

        public decimal ImporteTotal { get; set; }

        public string Son { get; set; }

        public string TransferenciaGratuitaLeyenda { get; set; }

        public string DigestValue { get; set; }

        public string SignatureValue { get; set; }

        public string NotaCredito_NotaDebito_Descripcion_General { get; set; }

        public string CodigoBarras_PDF417
        {
            get
            {
                string CodigoBarras_ = "";

                //RUC | TIPO DE DOCUMENTO | SERIE | NUMERO | MTO TOTAL IGV | MTO TOTAL DEL COMPROBANTE | FECHA DE EMISION | TIPO DE DOCUMENTO ADQUIRENTE | NUMERO DE DOCUMENTO ADQUIRENTE | VALOR RESUMEN | VALOR DE LA FIRMA |

                CodigoBarras_ += "20133605291|";                                //Ruc
                CodigoBarras_ += TipoDocumento + "|";                           //Tipo de documento
                CodigoBarras_ += SerieNumero.Split('-')[0] + "|";               //Serie
                CodigoBarras_ += SerieNumero.Split('-')[1] + "|";               //Numero
                CodigoBarras_ += Igv.ToString() + "|";                          //Monto Total Igv
                CodigoBarras_ += ImporteTotal.ToString() + "|";                 //Monto Total del Comprobante
                CodigoBarras_ += FechaEmision.ToString("yyyy-MM-dd") + "|";     //Fecha Emision
                CodigoBarras_ += Titular_DocumentoTipo.Trim() + "|";            //Tipo de documento del adquiriente
                CodigoBarras_ += Titular_DocumentoNumero.Trim() + "|";          //Numero de documento del adquiriente
                CodigoBarras_ += DigestValue + "|";                             //Valor resumen
                CodigoBarras_ += SignatureValue + "|";                          //Valor de la firma

                return CodigoBarras_;
            }
        }

        public string CodigoBarras_QR
        {
            get
            {
                string CodigoBarras_ = "";

                //RUC | TIPO DE DOCUMENTO | SERIE | NUMERO | MTO TOTAL IGV | MTO TOTAL DEL COMPROBANTE | FECHA DE EMISION | TIPO DE DOCUMENTO ADQUIRENTE | NUMERO DE DOCUMENTO ADQUIRENTE | VALOR RESUMEN | VALOR DE LA FIRMA |

                CodigoBarras_ += BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RUC + "|";                                //Ruc
                CodigoBarras_ += TipoDocumento + "|";                           //Tipo de documento
                CodigoBarras_ += SerieNumero.Split('-')[0] + "|";               //Serie
                CodigoBarras_ += SerieNumero.Split('-')[1] + "|";               //Numero
                CodigoBarras_ += Igv.ToString() + "|";                          //Monto Total Igv
                CodigoBarras_ += ImporteTotal.ToString() + "|";                 //Monto Total del Comprobante
                CodigoBarras_ += FechaEmision.ToString("yyyy-MM-dd") + "|";     //Fecha Emision
                CodigoBarras_ += Titular_DocumentoTipo.Trim() + "|";            //Tipo de documento del adquiriente
                CodigoBarras_ += Titular_DocumentoNumero.Trim() + "|";          //Numero de documento del adquiriente

                return CodigoBarras_;
            }
        }

        public List<ComprobanteElectronico_Detalle> Detalles { get; set; }


        public List<ComprobanteElectronico_DocumentoModifica> DocumentosModifica { get; set; }
    }
}
