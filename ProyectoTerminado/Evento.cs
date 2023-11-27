using System;
namespace ProyectoTerminado;

public class Evento
{
    public string Nombre { get; set; }

    public string Codigo { get; set; }
    public List<object> Jugadores { get; internal set; }

    List<Persona> personas;

    public Evento()
    {
    }

    public Evento(string nombre, string codigo)
    {
        Nombre = nombre;
        Codigo = codigo;
        personas = new List<Persona>();

    }

    public override string ToString()
    {
        return "Código: " + Codigo + "\nNombre: " + Nombre;
    }
    public void AgregarJugador(Jugador jugador)
    {
        personas.Add(jugador);
    }

    public Jugador BuscarJugador()
    {
        Console.WriteLine("Ingrese R.U.T.: ");
        string rutb = Console.ReadLine();
        foreach (Persona persona in personas)
        {
            if (rutb == persona.Rut)
            {
                if (persona is Jugador)
                {
                    Jugador j = (Jugador)persona;
                    return j;
                }
            }
        }
        return null;
    }

    public void EliminarJugador(Jugador j)
    {
        personas.Remove(j);
    }

    public string ImprimirJugadores()
    {
        string jugadores = "";
        Jugador j;
        foreach (Persona persona in personas)
        {
            if (persona is Jugador)
            {
                j = (Jugador)persona;
                jugadores += j;
            }
        }
        return jugadores;
    }
}
