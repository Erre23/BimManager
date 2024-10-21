using CapaDatos;
using CapaEntidad;
using CapaILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaLogica
{
    [Serializable]
    public class LogDepartamento : Conexion, ILogDepartamento
    {
        #region sigleton
        private static readonly LogDepartamento _instancia = new LogDepartamento();
        public static LogDepartamento Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<Departamento> DepartamentoBuscarPorDepartamentoID(short departamentoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var departamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(departamentoID);
                Close(cnn);
                return departamento;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Departamento>> DepartamentoBuscarTodos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();

                var listaDepartamentos = await new DaoDepartamento(cnn).BuscarTodos();
                var listaProvincias = await new DaoProvincia(cnn).BuscarTodos();
                var listaDistritos = await new DaoDistrito(cnn).BuscarTodos();

                foreach (var departamento in listaDepartamentos)
                {
                    departamento.Provincias = listaProvincias.FindAll(x => x.DepartamentoID == departamento.DepartamentoID);
                }

                foreach (var provincia in listaProvincias)
                {
                    provincia.Distritos = listaDistritos.FindAll(x => x.ProvinciaID == provincia.ProvinciaID);
                }

                Close(cnn);
                return listaDepartamentos;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion metodos
    }
}
