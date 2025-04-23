using Farmacia.DAL.Data;
using Farmacia.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Farmacia.BLL.Services
{
    public class ArticuloService
    {
        private ArticuloDAL articuloDAL;

        public ArticuloService()
        {
            articuloDAL = new ArticuloDAL();
        }

        public List<Articulo> ObtenerArticulos()
        {
            return articuloDAL.ObtenerArticulos();
        }

        public void AltaArticulo(Articulo articulo)
        {
            try
            {
                articuloDAL.AltaArticulo(articulo);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al dar de alta el artículo: " + ex.Message);
            }
        }

        public void ModificarArticulo(Articulo articulo)
        {
            try
            {
                articuloDAL.ModificarArticulo(articulo);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al modificar el artículo: " + ex.Message);
            }
        }

        public void EliminarArticulo(string códigoA)
        {
            try
            {
                articuloDAL.EliminarArticulo(códigoA);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
        }

        public Articulo ObtenerArticuloPorCodigo(string códigoA)
        {
            return articuloDAL.ObtenerArticuloPorCodigo(códigoA);
        }

        // Nueva función para buscar artículos
        public List<Articulo> BuscarArticulos(string criterio)
        {
            return articuloDAL.BuscarArticulos(criterio);
        }
    }
}
