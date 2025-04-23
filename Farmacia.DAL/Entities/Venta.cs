using System;

namespace Farmacia.DAL.Entities
{
    public class Venta
    {
        private int númeroVenta;
        private DateTime fecha;
        private string estado;
        private int ci;
        private string codigoA;
        private int cantidad;
        private string direccion;

        public int NúmeroVenta
        {
            get { return númeroVenta; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El número de venta no puede ser menor o igual a cero.");
                númeroVenta = value;
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El estado no puede estar vacío.");
                if (value.Length > 20)
                    throw new ArgumentException("El estado no puede tener más de 20 caracteres.");
                estado = value;
            }
        }

        public int CI
        {
            get { return ci; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El CI no puede ser menor o igual a cero.");
                ci = value;
            }
        }

        public string CodigoA
        {
            get { return codigoA; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código del artículo no puede estar vacío.");
                if (value.Length > 10)
                    throw new ArgumentException("El código del artículo no puede tener más de 10 caracteres.");
                codigoA = value;
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor que cero.");
                cantidad = value;
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La dirección no puede estar vacía.");
                if (value.Length > 200)
                    throw new ArgumentException("La dirección no puede tener más de 200 caracteres.");
                direccion = value;
            }
        }

        // Constructor para ventas existentes
        public Venta(int númeroVenta, DateTime fecha, string estado, int ci, string codigoA, int cantidad, string direccion)
        {
            NúmeroVenta = númeroVenta;
            Fecha = fecha;
            Estado = estado;
            CI = ci;
            CodigoA = codigoA;
            Cantidad = cantidad;
            Direccion = direccion;
        }

        // Constructor para nuevas ventas
        public Venta(DateTime fecha, string estado, int ci, string codigoA, int cantidad, string direccion)
        {
            Fecha = fecha;
            Estado = estado;
            CI = ci;
            CodigoA = codigoA;
            Cantidad = cantidad;
            Direccion = direccion;
        }

        public override string ToString()
        {
            return $"Venta {NúmeroVenta}: {Fecha.ToShortDateString()} - {Estado} - CI Cliente: {CI}, Artículo: {CodigoA}, Cantidad: {Cantidad}, Dirección: {Direccion}";
        }
    }
}