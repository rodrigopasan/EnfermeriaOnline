using Farmacia.DAL.Data;
using Farmacia.DAL.Entities;
using System;
using System.Collections.Generic;


namespace Farmacia.BLL.Services
{
    public class EmpleadoService
    {
        private EmpleadoDAL _empleadoDAL;

        public EmpleadoService()
        {
            _empleadoDAL = new EmpleadoDAL();
        }

        public void AltaEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoDAL.AltaEmpleado(empleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al dar de alta el empleado: " + ex.Message);
            }
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoDAL.ModificarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al modificar el empleado: " + ex.Message);
            }
        }

        public void EliminarEmpleado(string usuario)
        {
            try
            {
                _empleadoDAL.EliminarEmpleado(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al eliminar el empleado: " + ex.Message);
            }
        }

        public Empleado ObtenerEmpleadoPorUsuario(string usuario)
        {
            return _empleadoDAL.ObtenerEmpleadoPorUsuario(usuario);
        }

        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            return _empleadoDAL.ObtenerTodosLosEmpleados();
        }
    }
}
