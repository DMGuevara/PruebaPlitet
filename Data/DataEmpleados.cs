using RestDemo.Context;
using RestDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace RestDemo.Data
{
    public class DataEmpleados
    {
        DataContext cn = new DataContext();
        public async Task<List<EmpleadoInfo>> Mostrarempleados()
        {
            var lista = new List<EmpleadoInfo>();
            using(var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using(var cmd = new SqlCommand("mostrarEmpleados", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var empleadoinf = new EmpleadoInfo();
                            empleadoinf.empleado_id=(int)item["empleado_id"];
                            empleadoinf.nombres = (string)item["nombres"];
                            empleadoinf.apellidos = (string)item["apellidos"];
                            empleadoinf.telefono = (string)item["telefono"];
                            empleadoinf.fecha_nacimiento = (DateTime)item["fecha_nacimiento"];
                            empleadoinf.sueldo = (decimal)item["sueldo"];
                            lista.Add(empleadoinf);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task Insertarempleados(EmpleadoInfo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using(var cmd = new SqlCommand("insertarEmpleados",sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombres", parametros.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", parametros.apellidos);
                    cmd.Parameters.AddWithValue("@telefono", parametros.telefono);
                    cmd.Parameters.AddWithValue("@correo", parametros.correo);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", parametros.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@sueldo", parametros.sueldo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Editarempleados(EmpleadoInfo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("EditarEmpleados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empleado_id", parametros.empleado_id);
                    cmd.Parameters.AddWithValue("@nombres", parametros.nombres);
                    cmd.Parameters.AddWithValue("@apellidos", parametros.apellidos);
                    cmd.Parameters.AddWithValue("@telefono", parametros.telefono);
                    cmd.Parameters.AddWithValue("@correo", parametros.correo);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", parametros.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@sueldo", parametros.sueldo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task Eliminarempleados(EmpleadoInfo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarEmpleados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empleado_id", parametros.empleado_id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Consultarempleados(EmpleadoInfo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("consultarEmpleados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empleado_id", parametros.empleado_id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
