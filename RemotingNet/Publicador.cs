using CapaLogica;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingNet
{
    public class Publicador
    {
        public void publicar(int puerto)
        {
            TcpChannel chnl = new TcpChannel(puerto);
            ChannelServices.RegisterChannel(chnl, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogCliente), "LogCliente", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogDepartamento), "LogDepartamento", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogPlan), "LogPlan", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogPresupuesto), "LogPresupuesto", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogPresupuestoCategoria), "LogPresupuestoCategoria", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogProyecto), "LogProyecto", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogTipoDocumentoIdentidad), "LogTipoDocumentoIdentidad", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogTipoDocumentoSunat), "LogTipoDocumentoSunat", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogUsuario), "LogUsuario", WellKnownObjectMode.Singleton);

            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
        }
    }
}
