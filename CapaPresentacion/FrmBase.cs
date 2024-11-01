using BimManager.Entidad;
using BimManager.ILogica;
using System;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmBase : Form
    {

        protected ToolStripMenuItem _menu;
        protected Usuario _usuario;

        public FrmBase()
        {
            InitializeComponent();
        }

        protected RemoteObject ObjRemoteObject
        {
            get { return new RemoteObject(); }
        }


        #region[Busqueda de Archivos (OpenFileDialog) y carpetas (FolderBrowserDialog)]
        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog()
        {
            try
            {
                return Archivo_Buscar_Crear_OpenFileDialog("", "", false);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog(string DirectorioInicio)
        {
            try
            {
                return Archivo_Buscar_Crear_OpenFileDialog(DirectorioInicio, "", false);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog(bool SeleccionarVariosArchivos)
        {
            try
            {
                return Archivo_Buscar_Crear_OpenFileDialog("", "", SeleccionarVariosArchivos);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog(string DirectorioInicio, string FiltroExtension)
        {
            try
            {
                return Archivo_Buscar_Crear_OpenFileDialog(DirectorioInicio, FiltroExtension, false);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog(string DirectorioInicio, bool SeleccionarVariosArchivos)
        {
            try
            {
                return Archivo_Buscar_Crear_OpenFileDialog(DirectorioInicio, "", SeleccionarVariosArchivos);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }


        /// <summary>
        /// Muestra una ventana de dialogo para elegir un único archivo y retorna la ruta de su ubicación
        /// </summary>
        /// <param name="FiltroExtension">Permite definir un filtro para el tipo de archivo a buscar ejemplos ('Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif'), ('Archivo de texto (txt)|*.txt')</param>
        protected System.Windows.Forms.OpenFileDialog Archivo_Buscar_Crear_OpenFileDialog(string DirectorioInicio, string FiltroExtension, bool SeleccionarVariosArchivos)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog objOfd = new OpenFileDialog();
                objOfd.Multiselect = SeleccionarVariosArchivos;
                objOfd.InitialDirectory = (DirectorioInicio.Trim() != "" ? DirectorioInicio : Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                if (FiltroExtension != "") objOfd.Filter = FiltroExtension;
                return objOfd;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        protected System.Windows.Forms.SaveFileDialog Archivo_Guardar_Crear_SaveFileDialog(string FiltroExtension)
        {
            try
            {
                return Archivo_Guardar_Crear_SaveFileDialog("", FiltroExtension);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }

        protected System.Windows.Forms.SaveFileDialog Archivo_Guardar_Crear_SaveFileDialog(string DirectorioInicio, string FiltroExtension)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog objSfd = new SaveFileDialog();
                objSfd.CheckFileExists = false;
                objSfd.InitialDirectory = (DirectorioInicio.Trim() != "" ? DirectorioInicio : Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                if (FiltroExtension != "") objSfd.Filter = FiltroExtension;
                return objSfd;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }
        #endregion

    }
}
