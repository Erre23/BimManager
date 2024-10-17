using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoPresupuestoDetalle
	{
        #region sigleton
        private static readonly DaoPresupuestoDetalle _instancia = new DaoPresupuestoDetalle();
        public static DaoPresupuestoDetalle Instancia { get { return _instancia; } }
        #endregion singleton

        #region métodos

        public async Task<int> Insertar(PresupuestoDetalle presupuestoDetalle, SqlConnection cnn, SqlTransaction tran)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spPresupuestoDetalleInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoDetalle.PresupuestoID));
                cmd.Parameters.Add(CreateParams.SmallInt("PresupuestoCategoriaID", presupuestoDetalle.PresupuestoCategoriaID));
                cmd.Parameters.Add(CreateParams.TinyInt("Orden", presupuestoDetalle.Orden));
                cmd.Parameters.Add(CreateParams.Decimal("Porcentaje", presupuestoDetalle.Porcentaje, 3, 0));
                cmd.Parameters.Add(CreateParams.Decimal("Importe", presupuestoDetalle.Importe, 10, 2));

                presupuestoDetalle.PresupuestoDetalleID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
            catch (Exception e)
            {
                throw e;
            }

            return presupuestoDetalle.PresupuestoDetalleID;
        }

        public async Task<List<PresupuestoDetalle>> BuscarPorPresupuestoID(int presupuestoID)
        {
            var cmd = (SqlCommand)null;
            var presupuestoDetalles = new List<PresupuestoDetalle>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spPresupuestoDetalleBuscarPorPresupuestoID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoID));
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var presupuestoDetalle = await ReadEntidad(dr);
                    presupuestoDetalles.Add(presupuestoDetalle);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

            return presupuestoDetalles;
        }

        public async Task<List<PresupuestoDetalle>> BusquedaGeneral()
        {
            var cmd = (SqlCommand)null;
            var listaPresupuestoDetalles = new List<PresupuestoDetalle>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spPresupuestoDetalleBuscarTodos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var PresupuestoDetalle = await ReadEntidad(dr);
                    listaPresupuestoDetalles.Add(PresupuestoDetalle);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

            return listaPresupuestoDetalles;
        }

        private async Task<PresupuestoDetalle> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new PresupuestoDetalle();
                obj.PresupuestoDetalleID = Convert.ToInt32(dr["PresupuestoDetalleID"]);
                obj.PresupuestoID = Convert.ToInt32(dr["PresupuestoID"]);
                obj.PresupuestoCategoriaID = Convert.ToInt16(dr["PresupuestoCategoriaID"]);
                obj.Orden = Convert.ToByte(dr["Orden"]);
                obj.Porcentaje = Convert.ToDecimal(dr["Porcentaje"]);
                obj.Importe = Convert.ToDecimal(dr["Importe"]);


                return await Task.FromResult(obj);
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
