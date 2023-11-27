using System;
namespace ProyectoTerminado
{
    public class Jugador : Persona
    {
        public string Nickname { get; set; }
        public string Genero { get; set; }
        public string Plataforma { get; set; }

        public Jugador()
        {
        }

        public Jugador(string nombre, string rut, int telefono, int anacimiento,
            string nickname, string genero, string plataforma)
            : base(nombre, rut, telefono, anacimiento)
        {
            Nombre = nombre;
            Rut = rut;
            Telefono = telefono;
            AñoNacimiento = anacimiento;
            Nickname = nickname;
            Genero = genero;
            Plataforma = plataforma;
        }

        public override string ToString()
        {
            return base.ToString() + "\nNickName: " + Nickname + "\nGenero: " + Genero + "\nPlataforma: " + Plataforma;
        }
    }
}

