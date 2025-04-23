using System;

namespace Farmacia.DAL.Entities
{
    public class Categoria
    {
        private string códigoC;
        private string nombre;

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

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre de la categoría no puede tener más de 100 caracteres.");
                nombre = value;
            }
        }

        public Categoria(string códigoC, string nombre)
        {
            CódigoC = códigoC;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Nombre} (Código: {CódigoC})";
        }
    }
}
