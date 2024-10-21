using CapaILogica;
using CapaLogica;
using System;
using System.ServiceModel;
using System.Xml;

namespace WCF
{
    public class Publicador
    {
        
        public void publicar(int puerto)
        {
            Uri baseAddress = new Uri($"net.tcp://localhost:{puerto}/");

            var serviceHostCliente = new ServiceHost(typeof(LogCliente), baseAddress);
            serviceHostCliente.AddServiceEndpoint(typeof(ILogCliente), CreateBinding(), "LogCliente");
            serviceHostCliente.Open();

            var serviceHostDepartamento = new ServiceHost(typeof(LogDepartamento), baseAddress);
            serviceHostDepartamento.AddServiceEndpoint(typeof(ILogDepartamento), CreateBinding(), "LogDepartamento");
            serviceHostDepartamento.Open();

            var serviceHostPlan = new ServiceHost(typeof(LogPlan), baseAddress);
            serviceHostPlan.AddServiceEndpoint(typeof(ILogPlan), CreateBinding(), "LogPlan");
            serviceHostPlan.Open();

            var serviceHostPresupuesto = new ServiceHost(typeof(LogPresupuesto), baseAddress);
            serviceHostPresupuesto.AddServiceEndpoint(typeof(ILogPresupuesto), CreateBinding(), "LogPresupuesto");
            serviceHostPresupuesto.Open();

            var serviceHostPresupuestoCategoria = new ServiceHost(typeof(LogPresupuestoCategoria), baseAddress);
            serviceHostPresupuestoCategoria.AddServiceEndpoint(typeof(ILogPresupuestoCategoria), CreateBinding(), "LogPresupuestoCategoria");
            serviceHostPresupuestoCategoria.Open();

            var serviceHostProyecto = new ServiceHost(typeof(LogProyecto), baseAddress);
            serviceHostProyecto.AddServiceEndpoint(typeof(ILogProyecto), CreateBinding(), "LogProyecto");
            serviceHostProyecto.Open();

            var serviceHostTipoDocumentoIdentidad = new ServiceHost(typeof(LogTipoDocumentoIdentidad), baseAddress);
            serviceHostTipoDocumentoIdentidad.AddServiceEndpoint(typeof(ILogTipoDocumentoIdentidad), CreateBinding(), "LogTipoDocumentoIdentidad");
            serviceHostTipoDocumentoIdentidad.Open();

            var serviceHostTipoDocumentoSunat = new ServiceHost(typeof(LogTipoDocumentoSunat), baseAddress);
            serviceHostTipoDocumentoSunat.AddServiceEndpoint(typeof(ILogTipoDocumentoSunat), CreateBinding(), "LogTipoDocumentoSunat");
            serviceHostTipoDocumentoSunat.Open();

            var serviceHostUsuario = new ServiceHost(typeof(LogUsuario), baseAddress);
            serviceHostUsuario.AddServiceEndpoint(typeof(ILogUsuario), CreateBinding(), "LogUsuario");
            serviceHostUsuario.Open();
        }

        private NetTcpBinding CreateBinding()
        {
            return new NetTcpBinding
            {
                OpenTimeout = TimeSpan.FromMinutes(1),
                CloseTimeout = TimeSpan.FromMinutes(1),
                SendTimeout = TimeSpan.FromMinutes(1),
                ReceiveTimeout = TimeSpan.FromMinutes(2),
                MaxReceivedMessageSize = 2147483647,
                ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas
                {
                    MaxDepth = 32,
                    MaxStringContentLength = 2147483647,
                    MaxArrayLength = 2147483647,
                    MaxBytesPerRead = 4096,
                }
            };
        }
    }
}
