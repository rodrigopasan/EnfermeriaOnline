using System;

namespace Farmacia.DAL.Entities
{
    public class Articulo
    {
        private string códigoA;
        private string nombre;
        private decimal precio;
        private string presentación;
        private string tamaño;
        private string códigoC;
        private string nombreCategoría;

        public string CódigoA
        {
            get { return códigoA; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) && value != null) // Permitir null para nuevos artículos
                    throw new ArgumentException("El código del artículo no puede estar vacío.");
                if (value != null && value.Length > 10)
                    throw new ArgumentException("El código del artículo no puede tener más de 10 caracteres.");
                códigoA = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del artículo no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre del artículo no puede tener más de 100 caracteres.");
                nombre = value;
            }
        }

        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio del artículo debe ser mayor que cero.");
                precio = value;
            }
        }

        public string Presentación
        {
            get { return presentación; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La presentación del artículo no puede estar vacía.");
                if (value.Length > 50)
                    throw new ArgumentException("La presentación del artículo no puede tener más de 50 caracteres.");
                presentación = value;
            }
        }

        public string Tamaño
        {
            get { return tamaño; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tamaño del artículo no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El tamaño del artículo no puede tener más de 50 caracteres.");
                tamaño = value;
            }
        }

        public string CódigoC
        {
            get { return códigoC; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código de la categoría no puede estar vacío.");
                if (value.Length > 6)
                    throw new ArgumentException("El código de la categoría no puede tener más de 6 caracteres.");
                códigoC = value;
            }
        }

        public string NombreCategoría
        {
            get { return nombreCategoría; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre de la categoría no puede tener más de 100 caracteres.");
                nombreCategoría = value;
            }
        }

        // Constructor para Artículos existentes
        public Articulo(string códigoA, string nombre, decimal precio, string presentación, string tamaño, string códigoC, string nombreCategoría)
        {
            CódigoA = códigoA;
            Nombre = nombre;
            Precio = precio;
            Presentación = presentación;
            Tamaño = tamaño;
            CódigoC = códigoC;
            NombreCategoría = nombreCategoría;
        }

        // Constructor para nuevos Artículos sin código asignado
        public Articulo(string nombre, decimal precio, string presentación, string tamaño, string códigoC, string nombreCategoría)
        {
            Nombre = nombre;
            Precio = precio;
            Presentación = presentación;
            Tamaño = tamaño;
            CódigoC = códigoC;
            NombreCategoría = nombreCategoría;
        }

        public override string ToString()
        {
            return $"{Nombre} (Código: {CódigoA}, Precio: {Precio}, Presentación: {Presentación}, Tamaño: {Tamaño}, Categoría: {NombreCategoría} - Código: {CódigoC})";
        }
    }
}
