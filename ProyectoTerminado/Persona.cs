using System;
namespace ProyectoTerminado
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Telefono { get; set; }
        public int AñoNacimiento { get; set; }
        public Persona()
        {
        }

        public Persona(string nombre, string rut, int telefono, int anacimiento)
        {
            Nombre = nombre;
            Rut = rut;
            Telefono = telefono;
            AñoNacimiento = anacimiento;
        }

        public Persona(string nombre, string rut)
        {
            Nombre = nombre;
            Rut = rut;
        }

        public override string ToString()
        {
            return "Persona\nNombre: " + Nombre + "\nRUT: " + Rut +
                "\nTelefono: " + Telefono + "\nAño Nacimiento: " + AñoNacimiento;
        }
    }
}