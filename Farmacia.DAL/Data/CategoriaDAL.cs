using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Farmacia.DAL.Entities;

namespace Farmacia.DAL.Data
{
    public class CategoriaDAL
    {
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerCategorías", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        while (_Reader.Read())
                        {
                            Categoria categoria = new Categoria(
                                _Reader["CódigoC"].ToString(),
                                _Reader["Nombre"].ToString()
                            );
                            categorias.Add(categoria);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener las categorías: " + ex.Message, ex);
                    }
                }
            }
            return categorias;
        }

        public void AltaCategoria(Categoria categoria)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("AltaCategoria", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CodigoC", categoria.CódigoC);
                    _Comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al dar de alta la categoría: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("sp_ModificarCategoria", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;

                    _Comando.Parameters.AddWithValue("@CodigoC", categoria.CódigoC);
                    _Comando.Parameters.AddWithValue("@NuevoNombre", categoria.Nombre);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al modificar la categoría: " + ex.Message, ex);
                    }
                }
            }
        }

        public void EliminarCategoria(string codigoC)
        {
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("EliminarCategoria", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@CodigoC", codigoC);

                    try
                    {
                        _Conexion.Open();
                        _Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar la categoría: " + ex.Message, ex);
                    }
                }
            }
        }

        public Categoria ObtenerCategoriaPorCodigo(string codigoC)
        {
            Categoria categoria = null;
            using (SqlConnection _Conexion = new SqlConnection(Conexion.CNN))
            {
                using (SqlCommand _Comando = new SqlCommand("ObtenerCategoriaPorCodigo", _Conexion))
                {
                    _Comando.CommandType = CommandType.StoredProcedure;
                    _Comando.Parameters.AddWithValue("@CódigoC", codigoC);

                    try
                    {
                        _Conexion.Open();
                        SqlDataReader _Reader = _Comando.ExecuteReader();

                        if (_Reader.Read())
                        {
                            categoria = new Categoria(
                                _Reader["CódigoC"].ToString(),
                                _Reader["Nombre"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener la categoría: " + ex.Message, ex);
                    }
                }
            }
            return categoria;
        }
    }
}
