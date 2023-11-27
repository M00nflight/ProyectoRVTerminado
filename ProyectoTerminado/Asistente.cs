using System;
namespace ProyectoTerminado
{
    public class Asistente : Persona
    {
        public string Afp { get; set; }
        public double Porcentaje { get; set; }

        public Asistente()
        {
        }

        public Asistente(string nombre, string rut, string afp, double porcentaje)
            : base(nombre, rut)
        {
            Afp = afp;
            Porcentaje = porcentaje;
        }

        public override string ToString()
        {
            return base.ToString() + "\nAFP: " + Afp + "\nPorcentaje: " + Porcentaje;
        }
    }
}
