using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoCuentaBancaria
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoCuentaBancaria(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoCuentaBancaria(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<CuentaBancaria> BuscarPorCuentaBancariaID(short cuentaBancariaID)
        {
            var cmd = (SqlCommand)null;
            var cuentaBancaria = (CuentaBancaria)null;
            try
            {
                cmd = new SqlCommand("spCuentaBancariaBuscarPorCuentaBancariaID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.SmallInt("CuentaBancariaID", cuentaBancariaID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    cuentaBancaria = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return cuentaBancaria;
        }

        public async Task<List<CuentaBancaria>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var listaCuentaBancariaS = new List<CuentaBancaria>();
            try
            {
                cmd = new SqlCommand("spCuentaBancariaListarActivos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var cuentaBancaria = ReadEntidad(dr);
                    listaCuentaBancariaS.Add(cuentaBancaria);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaCuentaBancariaS;
        }

        private CuentaBancaria ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new CuentaBancaria();
                obj.CuentaBancariaID = Convert.ToInt16(dr["CuentaBancariaID"]);
                obj.BancoID = Convert.ToByte(dr["BancoID"]);
                obj.Banco = new Banco
                {
                    BancoID = obj.BancoID,
                    Nombre = Convert.ToString(dr["BancoNombre"])
                };
                obj.CuentaBancariaTipoID = Convert.ToByte(dr["CuentaBancariaTipoID"]);
                obj.CuentaBancariaTipo = new CuentaBancariaTipo
                {
                    CuentaBancariaTipoID = obj.CuentaBancariaTipoID,
                    Nombre = Convert.ToString(dr["CuentaBancariaTipoNombre"])
                };
                obj.MonedaTipoID = Convert.ToByte(dr["MonedaTipoID"]);
                obj.MonedaTipo = new MonedaTipo
                {
                    MonedaTipoID = obj.MonedaTipoID,
                    Nombre = Convert.ToString(dr["MonedaTipoNombre"]),
                    Divisa = Convert.ToString(dr["Divisa"])
                };
                obj.Nombre = Convert.ToString(dr["Nombre"]);
                obj.CuentaNumero = Convert.ToString(dr["CuentaNumero"]);
                obj.CCI = Convert.ToString(dr["CCI"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);
                obj.Activo = Convert.ToBoolean(dr["Activo"]);

                return obj;
            }
            catch(Exception ex)
            {
                dr.Close();
                throw ex;
            }
        }
        #endregion métodos
    }
}
