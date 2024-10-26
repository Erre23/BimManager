using BimManager.Entidad;
using System;
using System.ServiceModel;

namespace BimManager.ILogica
{
    public class RemoteObject
    {
        public readonly string direccion = $"net.tcp://localhost:{Configuracion.Puerto}/";
        
        public ILogCliente LogCliente { get { return (new ChannelFactory<ILogCliente>(CreateBinding(), new EndpointAddress(direccion + "LogCliente"))).CreateChannel(); } }
        public ILogContrato LogContrato { get { return (new ChannelFactory<ILogContrato>(CreateBinding(), new EndpointAddress(direccion + "LogContrato"))).CreateChannel(); } }
        public ILogDepartamento LogDepartamento { get { return (new ChannelFactory<ILogDepartamento>(CreateBinding(), new EndpointAddress(direccion + "LogDepartamento"))).CreateChannel(); } }
        public ILogPlan LogPlan { get { return (new ChannelFactory<ILogPlan>(CreateBinding(), new EndpointAddress(direccion + "LogPlan"))).CreateChannel(); } }
        public ILogPresupuesto LogPresupuesto { get { return (new ChannelFactory<ILogPresupuesto>(CreateBinding(), new EndpointAddress(direccion + "LogPresupuesto"))).CreateChannel(); } }
        public ILogPresupuestoCategoria LogPresupuestoCategoria { get { return (new ChannelFactory<ILogPresupuestoCategoria>(CreateBinding(), new EndpointAddress(direccion + "LogPresupuestoCategoria"))).CreateChannel(); } }
        public ILogProyecto LogProyecto { get { return (new ChannelFactory<ILogProyecto>(CreateBinding(), new EndpointAddress(direccion + "LogProyecto"))).CreateChannel(); } }
        public ILogTipoDocumentoIdentidad LogTipoDocumentoIdentidad { get { return (new ChannelFactory<ILogTipoDocumentoIdentidad>(CreateBinding(), new EndpointAddress(direccion + "LogTipoDocumentoIdentidad"))).CreateChannel(); } }
        public ILogTipoDocumentoSunat LogTipoDocumentoSunat { get { return (new ChannelFactory<ILogTipoDocumentoSunat>(CreateBinding(), new EndpointAddress(direccion + "LogTipoDocumentoSunat"))).CreateChannel(); } }
        public ILogUsuario LogUsuario { get { return (new ChannelFactory<ILogUsuario>(CreateBinding(), new EndpointAddress(direccion + "LogUsuario"))).CreateChannel();} }
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
