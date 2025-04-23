using Farmacia.DAL.Data;
using Farmacia.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Farmacia.BLL.Services
{
    public class ClienteService
    {
        private ClienteDAL clienteDAL;

        public ClienteService()
        {
            clienteDAL = new ClienteDAL();
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes();
        }
        public List<Cliente> BuscarClientes(string criterio)
        {
            return clienteDAL.BuscarClientes(criterio);
        }
        public Cliente ObtenerClientePorCI(int ci)
        {
            return clienteDAL.ObtenerClientePorCI(ci);
        }

        public void AltaCliente(Cliente cliente)
        {
            try
            {
                clienteDAL.AltaCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al dar de alta el cliente: " + ex.Message);
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                clienteDAL.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al modificar el cliente: " + ex.Message);
            }
        }

        public void EliminarCliente(int ci)
        {
            try
            {
                clienteDAL.EliminarCliente(ci);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al eliminar el cliente: " + ex.Message);
            }
        }
    }
}