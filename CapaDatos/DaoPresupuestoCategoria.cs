using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoPresupuestoCategoria
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoPresupuestoCategoria(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoPresupuestoCategoria(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<short> Insertar(PresupuestoCategoria presupuestoCategoria)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spPresupuestoCategoriaInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.NVarchar("Nombre", presupuestoCategoria.Nombre, 250));
                cmd.Parameters.Add(CreateParams.NVarchar("Observaciones", presupuestoCategoria.Observaciones, -1));
                cmd.Parameters.Add(CreateParams.Decimal("Porcentaje", presupuestoCategoria.Porcentaje, 3, 0));
                cmd.Parameters.Add(CreateParams.SmallInt("PadrePresupuestoCategoriaID", presupuestoCategoria.PadrePresupuestoCategoriaID));

                presupuestoCategoria.PresupuestoCategoriaID = Convert.ToInt16(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return presupuestoCategoria.PresupuestoCategoriaID;
        }


        public async Task Actualizar(PresupuestoCategoria presupuestoCategoria)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spPresupuestoCategoriaActualizar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.SmallInt("PresupuestoCategoriaID", presupuestoCategoria.PresupuestoCategoriaID));
                cmd.Parameters.Add(CreateParams.NVarchar("Nombre", presupuestoCategoria.Nombre, 250));
                cmd.Parameters.Add(CreateParams.NVarchar("Observaciones", presupuestoCategoria.Observaciones, -1));
                cmd.Parameters.Add(CreateParams.Decimal("Porcentaje", presupuestoCategoria.Porcentaje, 3, 0));
                cmd.Parameters.Add(CreateParams.SmallInt("PadrePresupuestoCategoriaID", presupuestoCategoria.PadrePresupuestoCategoriaID));

                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task<PresupuestoCategoria> BuscarPorPresupuestoCategoriaID(short PresupuestoCategoriaID)
        {
            var cmd = (SqlCommand)null;
            var PresupuestoCategoria = (PresupuestoCategoria)null;
            try
            {
                cmd = new SqlCommand("spPresupuestoCategoriaBuscarPorPresupuestoCategoriaID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.SmallInt("PresupuestoCategoriaID", PresupuestoCategoriaID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    PresupuestoCategoria = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return PresupuestoCategoria;
        }

        public async Task<List<PresupuestoCategoria>> BuscarPorPadrePresupuestoCategoria(short padrePresupuestoCaterogiaID)
        {
            var cmd = (SqlCommand)null;
            var listaPresupuestoCategorias = new List<PresupuestoCategoria>();
            try
            {
                cmd = new SqlCommand("spPresupuestoCategoriaBuscarPorpadrePresupuestoCaterogiaID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.SmallInt("padrePresupuestoCaterogiaID", padrePresupuestoCaterogiaID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var PresupuestoCategoria = await ReadEntidad(dr);
                    listaPresupuestoCategorias.Add(PresupuestoCategoria);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaPresupuestoCategorias;
        }

        public async Task<List<PresupuestoCategoria>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaPresupuestoCategorias = new List<PresupuestoCategoria>();
            try
            {
                cmd = new SqlCommand("spPresupuestoCategoriaBuscarTodos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var PresupuestoCategoria = await ReadEntidad(dr);
                    listaPresupuestoCategorias.Add(PresupuestoCategoria);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaPresupuestoCategorias;
        }

        private async Task<PresupuestoCategoria> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new PresupuestoCategoria();
                obj.PresupuestoCategoriaID = Convert.ToInt16(dr["PresupuestoCategoriaID"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);
				if (!(await dr.IsDBNullAsync(dr.GetOrdinal("Observaciones")))) obj.Observaciones = dr["Observaciones"].ToString();
                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("Porcentaje")))) obj.Porcentaje = Convert.ToDecimal(dr["Porcentaje"]);
                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("PadrePresupuestoCategoriaID")))) obj.PadrePresupuestoCategoriaID = Convert.ToInt16(dr["PadrePresupuestoCategoriaID"]);                

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
