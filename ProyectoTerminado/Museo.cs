using System;
namespace ProyectoTerminado;
public class Museo
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public List<Ceramica> Coleccion { get; set; }

    public Museo()
    {
        Coleccion = new List<Ceramica>();

    }

    public Museo(string nombre, string direccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        Coleccion = new List<Ceramica>();
    }

    public override string ToString()
    {
        return "Nombre del Museo: " + Nombre + "\nDireccion: " + Direccion;
    }

    public void AgregarCeramica(Ceramica ceramica) => Coleccion.Add(ceramica);

    public Ceramica BuscarCeramicaPorNumero(int numero)
    {
        foreach (Ceramica ceramica in Coleccion)
        {
            if (ceramica.Numero == numero)
            {
                return ceramica;
            }
        }
        return null;
    }

    public void EliminarCeramica(int numero)
    {
        Ceramica ceramica = BuscarCeramicaPorNumero(numero);
        if (ceramica != null)
        {
            Coleccion.Remove(ceramica);
        }
    }

    public string ImprimirCeramicas()
    {
        string ceramicas = "Colección de Cerámicas en el Museo:\n";
        foreach (Ceramica ceramica in Coleccion)
        {
            ceramicas += ceramica.ToString() + "\n";
        }
        return ceramicas;
    }
}