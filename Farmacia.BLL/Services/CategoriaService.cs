using Farmacia.DAL.Data;
using Farmacia.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Farmacia.BLL.Services
{
    public class CategoriaService
    {
        private CategoriaDAL categoriaDAL;

        public CategoriaService()
        {
            categoriaDAL = new CategoriaDAL();
        }

        public List<Categoria> ObtenerCategorias()
        {
            return categoriaDAL.ObtenerCategorias();
        }

        public void AltaCategoria(Categoria categoria)
        {
            try
            {
                categoriaDAL.AltaCategoria(categoria);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error en la lógica de negocio al dar de alta la categoría: " + ex.Message);
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDAL.ModificarCategoria(categoria);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error en la lógica de negocio al modificar la categoría: " + ex.Message);
            }
        }

        public void EliminarCategoria(string codigoC)
        {
            try
            {
                categoriaDAL.EliminarCategoria(codigoC);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error en la lógica de negocio al eliminar la categoría: " + ex.Message);
            }
        }

        public Categoria ObtenerCategoriaPorCodigo(string codigoC)
        {
            try
            {
                return categoriaDAL.ObtenerCategoriaPorCodigo(codigoC);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error en la lógica de negocio al obtener la categoría por código: " + ex.Message);
            }
        }
    }
}
