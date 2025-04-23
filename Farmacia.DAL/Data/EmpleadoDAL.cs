using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Farmacia.DAL.Entities;


namespace Farmacia.DAL.Data
{
    public class EmpleadoDAL
    {
        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            using (SqlConnection connection = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerTodosLosEmpleados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado(
                                reader["Usuario"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Contraseña"].ToString()
                            );
                            empleados.Add(empleado);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener los empleados: " + ex.Message, ex);
                    }
                }
            }
            return empleados;
        }

        public Empleado ObtenerEmpleadoPorUsuario(string usuario)
        {
            Empleado empleado = null;
            using (SqlConnection connection = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerEmpleadoPorUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            empleado = new Empleado(
                                reader["Usuario"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Contraseña"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener el empleado: " + ex.Message, ex);
                    }
                }
            }
            return empleado;
        }

        public void AltaEmpleado(Empleado empleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand command = new SqlCommand("sp_AltaEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Usuario", empleado.Usuario);
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@Contraseña", empleado.Contraseña);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de alta el empleado: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand command = new SqlCommand("ModificarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Usuario", empleado.Usuario);
                    command.Parameters.AddWithValue("@NuevoNombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@NuevaContraseña", empleado.Contraseña);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar el empleado: " + ex.Message, ex);
                    }
                }
            }
        }

        public void EliminarEmpleado(string usuario)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Usuario", usuario);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar el empleado: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}