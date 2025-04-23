using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Farmacia.DAL.Entities;

namespace Farmacia.DAL.Data
{
    public class VentaDAL
    {
        public List<Venta> ObtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerVentas", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Venta venta = new Venta(
                                (int)_Reader["NúmeroVenta"],
                                (DateTime)_Reader["Fecha"],
                                _Reader["Estado"].ToString(),
                                (int)_Reader["CI"],
                                _Reader["CódigoA"].ToString(),
                                (int)_Reader["Cantidad"],
                                _Reader["Direccion"].ToString()
                            );
                            ventas.Add(venta);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener las ventas: " + ex.Message, ex);
                    }
                }
            }
            return ventas;
        }

        public Venta ObtenerVentaPorNumero(int númeroVenta)
        {
            Venta venta = null;
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerVentaPorNumero", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@NúmeroVenta", númeroVenta);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        if (_Reader.Read())
                        {
                            venta = new Venta(
                                (int)_Reader["NúmeroVenta"],
                                (DateTime)_Reader["Fecha"],
                                _Reader["Estado"].ToString(),
                                (int)_Reader["CI"],
                                _Reader["CódigoA"].ToString(),
                                (int)_Reader["Cantidad"],
                                _Reader["Direccion"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener la venta: " + ex.Message, ex);
                    }
                }
            }
            return venta;
        }

        public void AltaVenta(Venta venta)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("AltaVenta", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CodigoA", venta.CodigoA);
                    _Comando.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                    _Comando.Parameters.AddWithValue("@CI", venta.CI);
                    _Comando.Parameters.AddWithValue("@Direccion", venta.Direccion);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de alta la venta: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ModificarVenta(Venta venta)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ModificarVenta", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@NúmeroVenta", venta.NúmeroVenta);
                    _Comando.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    _Comando.Parameters.AddWithValue("@Estado", venta.Estado);
                    _Comando.Parameters.AddWithValue("@CI", venta.CI);
                    _Comando.Parameters.AddWithValue("@CódigoA", venta.CodigoA);
                    _Comando.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                    _Comando.Parameters.AddWithValue("@Direccion", venta.Direccion);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar la venta: " + ex.Message, ex);
                    }
                }
            }
        }

        public void EliminarVenta(int númeroVenta)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("EliminarVenta", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@NúmeroVenta", númeroVenta);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar la venta: " + ex.Message, ex);
                    }
                }
            }
        }

        // Ajustado para modificar el estado de una venta
        public void ModificarEstadoVenta(int númeroVenta)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("sp_ModificarEstadoVenta", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@NumeroVenta", númeroVenta);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar el estado de la venta: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
