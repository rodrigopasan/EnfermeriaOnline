using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Farmacia.DAL.Entities;

namespace Farmacia.DAL.Data
{
    public class ClienteDAL
    {
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerClientes", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Cliente cliente = new Cliente(
                                (int)_Reader["CI"],
                                _Reader["Nombre"].ToString(),
                                _Reader["Número"].ToString(),
                                _Reader["NumTarjeta"].ToString(),
                                _Reader["Teléfono"].ToString()
                            );
                            clientes.Add(cliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener los clientes: " + ex.Message, ex);
                    }
                }
            }
            return clientes;
        }
        public List<Cliente> BuscarClientes(string criterio)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("BuscarClientes", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@Criterio", criterio);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Cliente cliente = new Cliente(
                                (int)_Reader["CI"],
                                _Reader["Nombre"].ToString(),
                                _Reader["Número"].ToString(),
                                _Reader["NumTarjeta"].ToString(),
                                _Reader["Teléfono"].ToString()
                            );
                            clientes.Add(cliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al buscar clientes: " + ex.Message, ex);
                    }
                }
            }
            return clientes;
        }
        public Cliente ObtenerClientePorCI(int ci)
        {
            Cliente cliente = null;
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerClientePorCI", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@CI", ci);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        if (_Reader.Read())
                        {
                            cliente = new Cliente(
                                (int)_Reader["CI"],
                                _Reader["Nombre"].ToString(),
                                _Reader["Número"].ToString(),
                                _Reader["NumTarjeta"].ToString(),
                                _Reader["Teléfono"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener el cliente: " + ex.Message, ex);
                    }
                }
            }
            return cliente;
        }

        public void AltaCliente(Cliente cliente)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("AltaCliente", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CI", cliente.CI);
                    _Comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    _Comando.Parameters.AddWithValue("@Numero", cliente.Número);
                    _Comando.Parameters.AddWithValue("@NumTarjeta", cliente.NumTarjeta);
                    _Comando.Parameters.AddWithValue("@Telefono", cliente.Teléfono);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de alta el cliente: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ModificarCliente", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CI", cliente.CI);
                    _Comando.Parameters.AddWithValue("@NuevoNombre", cliente.Nombre);
                    _Comando.Parameters.AddWithValue("@NuevoNumero", cliente.Número);
                    _Comando.Parameters.AddWithValue("@NuevoNumTarjeta", cliente.NumTarjeta);
                    _Comando.Parameters.AddWithValue("@NuevoTelefono", cliente.Teléfono);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar el cliente: " + ex.Message, ex);
                    }
                }
            }
        }

        public void EliminarCliente(int ci)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("EliminarCliente", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CI", ci);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar el cliente: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
