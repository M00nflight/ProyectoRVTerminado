using System;
namespace ProyectoTerminado
{
    public class Ceramica
    {
        public string Animal { get; set; }
        public int Numero { get; set; }
        public string Tecnica { get; set; }
        public string Dimensiones { get; set; }
        public Ceramica()
        {
        }
        public Ceramica(string animal, int numero, string tecnica, string dimensiones)
        {
            Animal = animal;
            Numero = numero;
            Tecnica = tecnica;
            Dimensiones = dimensiones;
        }

        public Ceramica(string animal, int numero)
        {
            Animal = animal;
            Numero = numero;
        }

        public override string ToString()
        {
            return "Cerámica de " + Animal + "\nNúmero: " + Numero + "\nTécnica: " + Tecnica + "\nDimensiones: " + Dimensiones + " cm";
        }
    }
}