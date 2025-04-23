using Farmacia.DAL.Data;
using Farmacia.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Farmacia.BLL.Services
{
    public class VentaService
    {
        private VentaDAL ventaDAL;

        public VentaService()
        {
            ventaDAL = new VentaDAL();
        }

        public List<Venta> ObtenerVentas()
        {
            return ventaDAL.ObtenerVentas();
        }

        public Venta ObtenerVentaPorNumero(int númeroVenta)
        {
            return ventaDAL.ObtenerVentaPorNumero(númeroVenta);
        }

        public void AltaVenta(Venta venta)
        {
            try
            {
                ventaDAL.AltaVenta(venta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al dar de alta la venta: " + ex.Message);
            }
        }

        public void ModificarVenta(Venta venta)
        {
            try
            {
                ventaDAL.ModificarVenta(venta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al modificar la venta: " + ex.Message);
            }
        }

        public void EliminarVenta(int númeroVenta)
        {
            try
            {
                ventaDAL.EliminarVenta(númeroVenta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al eliminar la venta: " + ex.Message);
            }
        }

        public void ModificarEstadoVenta(int númeroVenta)
        {
            try
            {
                ventaDAL.ModificarEstadoVenta(númeroVenta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al modificar el estado de la venta: " + ex.Message);
            }
        }
    }
}
