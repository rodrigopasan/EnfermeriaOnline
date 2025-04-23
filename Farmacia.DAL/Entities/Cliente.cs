using System;

namespace Farmacia.DAL.Entities
{
    public class Cliente
    {
        private int ci;
        private string nombre;
        private string número;
        private string numTarjeta;
        private string teléfono;

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

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");
                nombre = value;
            }
        }

        public string Número
        {
            get { return número; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El número no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El número no puede tener más de 50 caracteres.");
                número = value;
            }
        }

        public string NumTarjeta
        {
            get { return numTarjeta; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El número de tarjeta no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El número de tarjeta no puede tener más de 50 caracteres.");
                numTarjeta = value;
            }
        }

        public string Teléfono
        {
            get { return teléfono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono no puede estar vacío.");
                if (value.Length > 15)
                    throw new ArgumentException("El teléfono no puede tener más de 15 caracteres.");
                teléfono = value;
            }
        }

        // Constructor para clientes existentes
        public Cliente(int ci, string nombre, string número, string numTarjeta, string teléfono)
        {
            CI = ci;
            Nombre = nombre;
            Número = número;
            NumTarjeta = numTarjeta;
            Teléfono = teléfono;
        }

        // Constructor para nuevos clientes sin CI asignado (por ejemplo, si se genera automáticamente)
        public Cliente(string nombre, string número, string numTarjeta, string teléfono)
        {
            Nombre = nombre;
            Número = número;
            NumTarjeta = numTarjeta;
            Teléfono = teléfono;
        }

        public override string ToString()
        {
            return $"{Nombre} (CI: {CI}, Teléfono: {Teléfono}, Número de Tarjeta: {NumTarjeta})";
        }
    }
}