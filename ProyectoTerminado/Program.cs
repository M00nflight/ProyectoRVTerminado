using System;
namespace ProyectoTerminado;

class MainClass
{
    public static List<Evento> eventos = new List<Evento>();
    public static List<Asistente> asistentes = new List<Asistente>();
    public static Museo museo = new Museo();
    private static List<Museo> museos = new List<Museo>();


    public static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            switch (Menu())
            {
                case 1: // Eventos
                    EventosMenu();
                    break;
                case 2: // Jugadores
                    JugadoresMenu();
                    break;
                case 3: // Asistentes
                    AsistentesMenu();
                    break;
                case 4: // Museo
                    MuseoMenu();
                    break;
                case 5: //Ceramicas
                    CeramicasMenu();
                    break;
                case 0: // Salir
                    Console.WriteLine("Gracias por elegirnos");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    // EVENTOS MENU
    public static void EventosMenu()
    {
        bool volver = false;

        while (!volver)
        {
            switch (SubMenu("Evento"))
            {
                case 1: // Agregar Evento
                    AgregarEvento();
                    break;
                case 2: // Editar Evento
                    EditarEvento();
                    break;
                case 3: // Eliminar Evento
                    EliminarEvento();
                    break;
                case 4: // Imprimir Evento
                    ImprimirEvento();
                    break;
                case 5: // Imprimir todos los eventos
                    ImprimirTodos(eventos);
                    break;
                case 0: // Volver
                    Console.WriteLine("Volviendo al menú anterior... ");
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    private static void ImprimirEvento()
    {
        Console.WriteLine("Ingrese codigo del evento: ");
        string codigob = Console.ReadLine();
        Evento e = BuscarEvento(codigob);
        if (e != null)
        {
            Console.WriteLine(e);
        }
        else
        {
            Console.WriteLine("Evento no encontrado");
        }
    }

    private static void EliminarEvento()
    {
        Console.WriteLine("Ingrese codigo del evento: ");
        string codigob = Console.ReadLine();
        Evento e = BuscarEvento(codigob);
        if (e != null)
        {
            if (eventos.Remove(e))
            {
                Console.WriteLine("Evento eliminado");
            }
            else
            {
                Console.WriteLine("Evento no eliminado");
            }
        }
        else
        {
            Console.WriteLine("Evento no encontrado");
        }
    }

    private static void EditarEvento()
    {
        Console.WriteLine("Ingrese código evento: ");
        string codigob = Console.ReadLine();
        Evento e = BuscarEvento(codigob);
        if (e != null)
        {
            Console.WriteLine("Menu edición");
            Console.WriteLine("1.- Nombre");
            Console.WriteLine("2.- Código");
            Console.WriteLine("Seleccione una opción: ");
            int op2 = LeerEntero();
            if (op2 == 1)
            {
                Console.WriteLine("El nombre actual es: " + e.Nombre);
                Console.WriteLine("Ingrese nuevo nombre: ");
                e.Nombre = Console.ReadLine();
            }
            else if (op2 == 2)
            {
                Console.WriteLine("El codigo actual es: " + e.Codigo);
                Console.WriteLine("ingrese nuevo codigo: ");
                e.Codigo = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No se realizarán cambios");
            }
        }
        else
        {
            Console.WriteLine("Evento no encontrado");
        }
    }

    private static void AgregarEvento()
    {
        Console.WriteLine("Ingrese código: ");
        string codigo = Console.ReadLine();
        Console.WriteLine("Ingrese Nombre: ");
        string nombre = Console.ReadLine();
        eventos.Add(new Evento(nombre, codigo));
        Console.WriteLine("Se ha agregado el evento");
    }

    private static Evento BuscarEvento(string codigob)
    {
        foreach (Evento evento in eventos)
        {
            if (evento.Codigo == codigob)
            {
                return evento;
            }
        }
        return null;
    }

    private static void ImprimirTodos<T>(List<T> lista)
    {
        Console.WriteLine($"Lista de {typeof(T).Name}s:");
        foreach (var elemento in lista)
        {
            Console.WriteLine(elemento);
        }
    }


    //JUGADORES MENU
    private static void JugadoresMenu()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine("Ingrese código evento para gestionar Jugadores");
            string codigob = Console.ReadLine();
            Evento e = BuscarEvento(codigob);

            if (e != null)
            {
                switch (SubMenu("Jugador"))
                {
                    case 1: // Agregar Jugador
                        AgregarJugador(e);
                        break;
                    case 2: // Editar Jugador
                        EditarJugador(e);
                        break;
                    case 3: // Eliminar Jugador
                        EliminarJugador(e);
                        break;
                    case 4: // Imprimir Jugador
                        ImprimirJugador(e);
                        break;
                    case 5: // Imprimir Todos
                        ImprimirTodos(e.Jugadores);
                        break;
                    case 0: // Volver
                        Console.WriteLine("Volviendo al menú anterior... ");
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
    private static void ImprimirJugador(Evento e)
    {
        Jugador j = e.BuscarJugador();
        if (j != null)
        {
            Console.WriteLine(j);
        }
        else
        {
            Console.WriteLine("Jugador no existe");
        }
    }

    private static void EliminarJugador(Evento e)
    {
        Jugador j = e.BuscarJugador();
        if (j != null)
        {
            e.EliminarJugador(j);
        }
        else
        {
            Console.WriteLine("Jugador no encontrado");
        }
    }

    private static void EditarJugador(Evento e)
    {
        Jugador jugador = e.BuscarJugador();
        if (jugador != null)
        {
            Console.WriteLine("Menu edicion: ");
            Console.WriteLine("1.- nombre");
            Console.WriteLine("2.- telefono");
            Console.WriteLine("3.- año nacimiento");
            Console.WriteLine("4.- nickname");
            Console.WriteLine("5.- genero");
            Console.WriteLine("6.- plataforma");
            Console.WriteLine("Seleccione una opcion: ");
            int op = LeerEntero();
            if (op == 1)
            {
                Console.WriteLine("Su nombre es: " + jugador.Nombre);
                Console.WriteLine("Ingrese un nuevo nombre: ");
                jugador.Nombre = Console.ReadLine();
            }
            else if (op == 2)
            {
                Console.WriteLine("Su telefono: " + jugador.Telefono);
                Console.WriteLine("Ingrese nuevo telefono");
                jugador.Telefono = LeerEntero();
            }
            else if (op == 3)
            {
                Console.WriteLine("Su año de nacimiento: " + jugador.AñoNacimiento);
                Console.WriteLine("Ingrese nuevo año de nacimiento");
                jugador.AñoNacimiento = LeerEntero();
            }
            else if (op == 4)
            {
                Console.WriteLine("Su Nickname: " + jugador.Nickname);
                Console.WriteLine("Ingrese nuevo nickname");
                jugador.Nickname = Console.ReadLine();
            }
            else if (op == 5)
            {
                Console.WriteLine("Su genero: " + jugador.Genero);
                Console.WriteLine("Ingrese nuevo teleono");
                jugador.Genero = Console.ReadLine();
            }
            else if (op == 6)
            {
                Console.WriteLine("Su plataforma: " + jugador.Plataforma);
                Console.WriteLine("Ingrese nuevo plataforma");
                jugador.Plataforma = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No eligio una opcion valida. No se realizaron cambios");
            }
        }
        else
        {
            Console.WriteLine("Jugador no encontrado");
        }
    }

    private static void AgregarJugador(Evento e)
    {
        Console.WriteLine("Ingrese nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese R.U.T: ");
        string rut = Console.ReadLine();
        Console.WriteLine("Ingrese telefono: ");
        int telefono = LeerEntero();
        Console.WriteLine("Ingrese año de nacimiento: ");
        int anacimiento = LeerEntero();
        Console.WriteLine("Ingrese nickname: ");
        string nickname = Console.ReadLine();
        Console.WriteLine("Ingrese genero: ");
        string genero = Console.ReadLine();
        Console.WriteLine("Ingrese plataforma: ");
        string plataforma = Console.ReadLine();
        e.AgregarJugador(new Jugador(nombre, rut, telefono, anacimiento, nickname, genero, plataforma));
    }

    private static void ImprimirTodos()
    {
        foreach (Evento evento in eventos)
        {
            Console.WriteLine(evento);
        }
    }


    // ASISTENTES MENU
    private static void AsistentesMenu()
    {
        bool volver = false;

        while (!volver)
        {
            switch (SubMenu("Asistente"))
            {
                case 1: // Agregar Asistente
                    AgregarAsistente();
                    break;
                case 2: // Editar Asistente
                    EditarAsistente();
                    break;
                case 3: // Eliminar Asistente
                    EliminarAsistente();
                    break;
                case 4: // Imprimir Asistente
                    ImprimirAsistente();
                    break;
                case 5: // Imprimir Todos
                    ImprimirTodos(asistentes);
                    break;
                case 0: // Volver
                    Console.WriteLine("Volviendo al menú anterior... ");
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
        
    public static void AgregarAsistente()
    {
        Console.WriteLine("Ingrese nombre del asistente: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese rut del asistente: ");
        string rut = Console.ReadLine();
        Console.WriteLine("Ingrese AFP del asistente: ");
        string afp = Console.ReadLine();
        Console.WriteLine("Ingrese porcentaje del asistente: ");
        double porcentaje = Convert.ToDouble(Console.ReadLine());

        Asistente asistente = new Asistente(nombre, rut, afp, porcentaje);
        asistentes.Add(asistente);
        Console.WriteLine("Asistente agregado con éxito.");
    }

    public static void EditarAsistente()
    {
        Console.WriteLine("Ingrese el rut del asistente a editar: ");
        string rut = Console.ReadLine();
        Asistente asistente = asistentes.Find(a => a.Rut == rut);

        if (asistente != null)
        {
            Console.WriteLine("Ingrese el nuevo nombre del asistente: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva AFP del asistente: ");
            string afp = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo porcentaje del asistente: ");
            double porcentaje = Convert.ToDouble(Console.ReadLine());

            asistente.Nombre = nombre;
            asistente.Afp = afp;
            asistente.Porcentaje = porcentaje;
            Console.WriteLine("Asistente editado con éxito.");
        }
        else
        {
            Console.WriteLine("Asistente no encontrado.");
        }
    }

    public static void EliminarAsistente()
    {
        Console.WriteLine("Ingrese el rut del asistente a eliminar: ");
        string rut = Console.ReadLine();
        Asistente asistente = asistentes.Find(a => a.Rut == rut);

        if (asistente != null)
        {
            asistentes.Remove(asistente);
            Console.WriteLine("Asistente eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Asistente no encontrado.");
        }
    }

    public static void ImprimirAsistente()
    {
        Console.WriteLine("Ingrese el rut del asistente a imprimir: ");
        string rut = Console.ReadLine();
        Asistente asistente = asistentes.Find(a => a.Rut == rut);

        if (asistente != null)
        {
            Console.WriteLine(asistente);
        }
        else
        {
            Console.WriteLine("Asistente no encontrado.");
        }
    }

    public static void ImprimirTodosAsistentes()
    {
        Console.WriteLine("Lista de Asistentes:");
        foreach (var asistente in asistentes)
        {
            Console.WriteLine(asistente);
        }
    }

    // MUSEO y CERAMICAS MENU
    private static void MuseoMenu()
    {
        bool volver = false;

        while (!volver)
        {
            switch (SubMenu("Museo"))
            {
                case 1:
                    AñadirMuseo();
                    break;
                case 2:
                    EditarMuseo();
                    break;
                case 3:
                    EliminarMuseo();
                    break;
                case 4:
                    BuscarMuseo();
                    break;
                case 5:
                    ImprimirMuseos();
                    break;
                case 0: // Volver
                    Console.WriteLine("Volviendo al menú anterior... ");
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private static void AñadirMuseo()
    {
        Console.WriteLine("Ingrese el nombre del museo: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la dirección del museo: ");
        string direccion = Console.ReadLine();
        Museo museo = new Museo(nombre, direccion);
        museos.Add(museo);
        Console.WriteLine("Museo configurado con éxito.");
    }

    private static void EditarMuseo()
    {
        Console.WriteLine("Ingrese el nombre del museo a editar: ");
        string nombre = Console.ReadLine();
        Museo museo = BuscarMuseoPorNombre(nombre);
        if (museo != null)
        {
            Console.WriteLine("Ingrese la nueva dirección del museo: ");
            string nuevaDireccion = Console.ReadLine();
            museo.Direccion = nuevaDireccion;
            Console.WriteLine("Museo editado con éxito.");
        }
        else
        {
            Console.WriteLine("Museo no encontrado.");
        }
    }

    private static void EliminarMuseo()
    {
        Console.WriteLine("Ingrese el nombre del museo a eliminar: ");
        string nombre = Console.ReadLine();
        Museo museo = BuscarMuseoPorNombre(nombre);
        if (museo != null)
        {
            museos.Remove(museo);
            Console.WriteLine("Museo eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Museo no encontrado.");
        }
    }

    private static void BuscarMuseo()
    {
        Console.WriteLine("Ingrese el nombre del museo a buscar: ");
        string nombre = Console.ReadLine();
        Museo museo = BuscarMuseoPorNombre(nombre);
        if (museo != null)
        {
            Console.WriteLine($"Nombre: {museo.Nombre}, Dirección: {museo.Direccion}");
        }
        else
        {
            Console.WriteLine("Museo no encontrado.");
        }
    }

    private static Museo BuscarMuseoPorNombre(string nombre)
    {
        return museos.Find(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    private static void ImprimirMuseos()
    {
        Console.WriteLine("Museos en la colección:");
        foreach (Museo museo in museos)
        {
            Console.WriteLine($"Nombre: {museo.Nombre}, Dirección: {museo.Direccion}");
        }
    }


    // Menu Ceramicas
    private static void CeramicasMenu()
    {
        bool volver = false;

        while (!volver)
        {
            switch (SubMenu("Cerámica"))
            {
                case 1: // Agregar Cerámica
                    AgregarCeramicaAlMuseo();
                    break;
                case 2: // Editar Cerámica
                    EditarCeramica();
                    break;
                case 3: // Eliminar Cerámica
                    EliminarCeramicaDelMuseo();
                    break;
                case 4: // Buscar Cerámica
                    BuscarCeramicaEnMuseo();
                    break;
                case 5: // Imprimir Todas las Cerámicas
                    ImprimirCeramicasDelMuseo();
                    break;
                case 0: // Volver
                    Console.WriteLine("Volviendo al menú anterior... ");
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private static void AgregarCeramicaAlMuseo()
    {
        Console.WriteLine("Ingrese el nombre del animal de la cerámica: ");
        string animal = Console.ReadLine();
        Console.WriteLine("Ingrese el número de la cerámica: ");
        int numero = LeerEntero();
        Console.WriteLine("Ingrese la técnica usada de la cerámica: ");
        string tecnica = Console.ReadLine();
        Console.WriteLine("Ingrese las dimensiones de la figura de cerámica (cm): ");
        string dimensiones = Console.ReadLine();

        try
        {
            Ceramica ceramica = new Ceramica(animal, numero, tecnica, dimensiones);
            museo.AgregarCeramica(ceramica);
            Console.WriteLine("Cerámica agregada al museo con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al agregar la cerámica: " + ex.Message);
        }
    }

    private static void BuscarCeramicaEnMuseo()
    {
        Console.WriteLine("Ingrese el número de la cerámica a buscar: ");
        int numero = LeerEntero();
        Ceramica ceramica = museo.BuscarCeramicaPorNumero(numero);

        if (ceramica != null)
        {
            Console.WriteLine(ceramica);
        }
        else
        {
            Console.WriteLine("Cerámica no encontrada en el museo.");
        }
    }

    private static void EliminarCeramicaDelMuseo()
    {
        Console.WriteLine("Ingrese el número de la cerámica a eliminar del museo: ");
        int numero = LeerEntero();

        try
        {
            museo.EliminarCeramica(numero);
            Console.WriteLine("Cerámica eliminada del museo con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar la cerámica: " + ex.Message);
        }
    }

    private static void EditarCeramica()
    {
        Console.WriteLine("Ingrese el número de la cerámica a modificar: ");
        int numero = LeerEntero();
        Ceramica ceramica = museo.BuscarCeramicaPorNumero(numero);

        if (ceramica != null)
        {
            Console.WriteLine("Ingrese el nuevo nombre del animal de la cerámica: ");
            string animal = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva técnica de la cerámica: ");
            string tecnica = Console.ReadLine();
            Console.WriteLine("Ingrese nuevamente las dimensiones de la cerámica (cm): ");
            string dimensiones = Console.ReadLine();

            ceramica.Animal = animal;
            ceramica.Tecnica = tecnica;
            ceramica.Dimensiones = dimensiones;

            Console.WriteLine("Cerámica modificada con éxito.");
        }
        else
        {
            Console.WriteLine("Cerámica no encontrada en el museo.");
        }
    }

    private static void ImprimirCeramicasDelMuseo()
    {
        Console.WriteLine("Cerámicas en el Museo:");
        string ceramicas = museo.ImprimirCeramicas();
        Console.WriteLine(ceramicas);
    }


    // SUBMENU
    private static int SubMenu(string v)
    {
        int op = -1;
        do
        {
            Console.WriteLine("SubMenu " + v);
            Console.WriteLine("1.- Agregar " + v);
            Console.WriteLine("2.- Editar " + v);
            Console.WriteLine("3.- Eliminar " + v);
            Console.WriteLine("4.- Imprimir " + v);
            Console.WriteLine("5.- Imprimir todos");
            Console.WriteLine("0.- Volver");
            Console.WriteLine("Seleccione una opción");
            op = LeerEntero();
        } while (op < 0 || op > 5);
        return op;
    }


    // MENU
    private static int Menu()
    {
        int op = -1;
        while (op < 0 || op > 6)
        {
            Console.WriteLine("Evento Gamer");
            Console.WriteLine("1.- Eventos");
            Console.WriteLine("2.- Jugadores");
            Console.WriteLine("3.- Asistentes");
            Console.WriteLine("4.- Museo");
            Console.WriteLine("5.- Ceramicas");
            Console.WriteLine("0.- Salir");
            Console.WriteLine("Ingrese una opción: ");
            op = LeerEntero();
            if (op < 0 || op > 6)
            {
                Console.WriteLine("Ingresa una opción entre 0 y 4");
            }
        }
        return op;
    }


    // FUNCION LEER ENTERO
    private static int LeerEntero()
    {
        int num = -1;
        bool entradaValida = false;

        while (!entradaValida)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out num))
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Debe ingresar un número válido.");
            }
        }

        return num;
    }
}
