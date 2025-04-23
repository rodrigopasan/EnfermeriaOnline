using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace Farmacia.DAL.Entities
{
    public class Empleado
    {
        private string _usuario;
        private string _nombre;
        private string _contraseña;

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (value.Length > 50) // Suponiendo que la longitud máxima es 50
                    throw new Exception("El usuario no puede tener más de 50 caracteres.");
                _usuario = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Length > 100) // Suponiendo que la longitud máxima es 100
                    throw new Exception("El nombre no puede tener más de 100 caracteres.");
                _nombre = value;
            }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (value.Length > 50) // Suponiendo que la longitud máxima es 50
                    throw new Exception("La contraseña no puede tener más de 50 caracteres.");
                _contraseña = value;
            }
        }

        public Empleado(string usuario, string nombre, string contraseña)
        {
            Usuario = usuario;
            Nombre = nombre;
            Contraseña = contraseña;
        }

        public override string ToString()
        {
            return Usuario;
        }
    }
}