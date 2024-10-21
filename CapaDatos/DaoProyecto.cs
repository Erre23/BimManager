using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoProyecto
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoProyecto(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoProyecto(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos
        public async Task<int> Insertar(Proyecto Proyecto)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spProyectoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ClienteID", Proyecto.ClienteID));
				cmd.Parameters.Add(CreateParams.NVarchar("Nombre", Proyecto.Nombre, 250));
				cmd.Parameters.Add(CreateParams.NVarchar("Direccion", Proyecto.Direccion, 250));
				cmd.Parameters.Add(CreateParams.NVarchar("DireccionReferencia", Proyecto.DireccionReferencia, 250));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionDistritoID", Proyecto.DireccionDistritoID));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionProvinciaID", Proyecto.DireccionProvinciaID));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionDepartamentoID", Proyecto.DireccionDepartamentoID));

                Proyecto.ProyectoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Proyecto.ProyectoID;
        }


        public async Task Actualizar(Proyecto Proyecto)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spProyectoActualizar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", Proyecto.ProyectoID));
				cmd.Parameters.Add(CreateParams.Int("ClienteID", Proyecto.ClienteID));
				cmd.Parameters.Add(CreateParams.NVarchar("Nombre", Proyecto.Nombre, 250));
				cmd.Parameters.Add(CreateParams.NVarchar("Direccion", Proyecto.Direccion, 250));
				cmd.Parameters.Add(CreateParams.NVarchar("DireccionReferencia", Proyecto.DireccionReferencia, 250));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionDistritoID", Proyecto.DireccionDistritoID));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionProvinciaID", Proyecto.DireccionProvinciaID));
				cmd.Parameters.Add(CreateParams.SmallInt("DireccionDepartamentoID", Proyecto.DireccionDepartamentoID));

				await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }


        public async Task Deshabilitar(int ProyectoID)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spProyectoDeshabilitar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", ProyectoID));

                await cmd.ExecuteNonQueryAsync(); 
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task<Proyecto> BuscarPorProyectoID(int proyectoID)
        {
            var cmd = (SqlCommand)null;
            var Proyecto = (Proyecto)null;
            try
            {
                cmd = new SqlCommand("spProyectoBuscarPorProyectoID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Proyecto = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Proyecto;
        }

        public async Task<List<Proyecto>> BuscarPorClienteID(int clienteID)
        {
            var cmd = (SqlCommand)null;
            var listaProyectos = new List<Proyecto>();
            try
            {
                cmd = new SqlCommand("spProyectoBuscarPorClienteID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var proyecto = await ReadEntidad(dr);
                    listaProyectos.Add(proyecto);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaProyectos;
        }

        public async Task<List<Proyecto>> BusquedaGeneral(int? clienteID, string nombre, short? distritoID, short? provinciaID, short? departamentoID)
        {
            var cmd = (SqlCommand)null;
            var listaProyectos = new List<Proyecto>();
            try
            {
                cmd = new SqlCommand("spProyectoBusquedaGeneral", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
                cmd.Parameters.Add(CreateParams.NVarchar("Nombre", nombre, 250));
                cmd.Parameters.Add(CreateParams.SmallInt("DistritoID", distritoID));
				cmd.Parameters.Add(CreateParams.SmallInt("ProvinciaID", provinciaID));
				cmd.Parameters.Add(CreateParams.SmallInt("DepartamentoID", departamentoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Proyecto = await ReadEntidad(dr);
                    listaProyectos.Add(Proyecto);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaProyectos;
        }

        private async Task<Proyecto> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Proyecto();
                obj.ProyectoID = Convert.ToInt32(dr["ProyectoID"]);
                obj.ClienteID = Convert.ToInt32(dr["ClienteID"]);
                obj.Nombre = dr["Nombre"].ToString();
				obj.Direccion = dr["Direccion"].ToString();
				if (!(await dr.IsDBNullAsync(dr.GetOrdinal("DireccionReferencia")))) obj.DireccionReferencia = dr["DireccionReferencia"].ToString();
				obj.DireccionDistritoID = Convert.ToInt16(dr["DireccionDistritoID"]);
				obj.DireccionProvinciaID = Convert.ToInt16(dr["DireccionProvinciaID"]);
				obj.DireccionDepartamentoID = Convert.ToInt16(dr["DireccionDepartamentoID"]);
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
