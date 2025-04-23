using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Farmacia.DAL.Entities;

namespace Farmacia.DAL.Data
{
    public class ArticuloDAL
    {
        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerArticulos", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Articulo articulo = new Articulo(
                                _Reader["CódigoA"].ToString(),
                                _Reader["Nombre"].ToString(),
                                (decimal)_Reader["Precio"],
                                _Reader["Presentación"].ToString(),
                                _Reader["Tamaño"].ToString(),
                                _Reader["CódigoC"].ToString(),
                                _Reader["NombreCategoría"].ToString()
                            );
                            articulos.Add(articulo);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener los artículos: " + ex.Message, ex);
                    }
                }
            }
            return articulos;
        }

        public Articulo ObtenerArticuloPorCodigo(string códigoA)
        {
            Articulo articulo = null;
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerArticuloPorCodigo", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@CódigoA", códigoA);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        if (_Reader.Read())
                        {
                            articulo = new Articulo(
                                _Reader["CódigoA"].ToString(),
                                _Reader["Nombre"].ToString(),
                                (decimal)_Reader["Precio"],
                                _Reader["Presentación"].ToString(),
                                _Reader["Tamaño"].ToString(),
                                _Reader["CódigoC"].ToString(),
                                _Reader["NombreCategoría"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener el artículo: " + ex.Message, ex);
                    }
                }
            }
            return articulo;
        }

        public void AltaArticulo(Articulo articulo)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("AltaArticulo", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                    _Comando.Parameters.AddWithValue("@Precio", articulo.Precio);
                    _Comando.Parameters.AddWithValue("@Presentación", articulo.Presentación);
                    _Comando.Parameters.AddWithValue("@Tamaño", articulo.Tamaño);
                    _Comando.Parameters.AddWithValue("@CódigoC", articulo.CódigoC);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de alta el artículo: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ModificarArticulo(Articulo articulo)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ModificarArticulo", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CódigoA", articulo.CódigoA);
                    _Comando.Parameters.AddWithValue("@NuevoNombre", articulo.Nombre);
                    _Comando.Parameters.AddWithValue("@NuevoPrecio", articulo.Precio);
                    _Comando.Parameters.AddWithValue("@NuevaPresentación", articulo.Presentación);
                    _Comando.Parameters.AddWithValue("@NuevoTamaño", articulo.Tamaño);
                    _Comando.Parameters.AddWithValue("@NuevoCódigoC", articulo.CódigoC);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar el artículo: " + ex.Message, ex);
                    }
                }
            }
        }

        public void EliminarArticulo(string códigoA)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("EliminarArticulo", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CódigoA", códigoA);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar el artículo: " + ex.Message, ex);
                    }
                }
            }
        }

        public List<Articulo> BuscarArticulos(string criterio)
        {
            List<Articulo> articulos = new List<Articulo>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("BuscarArticulos", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@Criterio", criterio);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Articulo articulo = new Articulo(
                                _Reader["CódigoA"].ToString(),
                                _Reader["Nombre"].ToString(),
                                (decimal)_Reader["Precio"],
                                _Reader["Presentación"].ToString(),
                                _Reader["Tamaño"].ToString(),
                                _Reader["CódigoC"].ToString(),
                                _Reader["NombreCategoría"].ToString()
                            );
                            articulos.Add(articulo);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al buscar los artículos: " + ex.Message, ex);
                    }
                }
            }
            return articulos;
        }
    }
}
