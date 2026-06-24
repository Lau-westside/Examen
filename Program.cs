
List<Ejemplares> ejemplar = new List();

void CrearLibros()
{
    Console.WriteLine("Ingrese que quiere Registrar, 1- DVD, 2- Libro");
    int opcion = int.Parse(Console.ReadLine());
    switch(opcion)
    {
        case 1:
            DVD dvd = new DVD();
            Console.WriteLine("Ingrese el Titulo del DVD");
            dvd.Titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el Autor del DVD");
            dvd.Autor = Console.ReadLine();
            Console.WriteLine("Ingrese el Genero del DVD");
            dvd.Genero = Console.ReadLine();
            Console.WriteLine("Ingrese la Duracion del DVD");
            dvd.Duracion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese año de publicacion del DVD");
            dvd.AnioPublicado = Console.ReadLine();
            ejemplar.Add(dvd);
            break;
        case 2:
            Libro libro = new Libro();
            Console.WriteLine("Ingrese el Titulo del Libro");
            libro.Titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el Autor del Libro");
            libro.Autor = Console.ReadLine();
            Console.WriteLine("Ingrese el Genero del Libro");
            libro.Genero = Console.ReadLine();
            Console.WriteLine("Ingrese el ISBN del Libro");
            libro.ISBN = Console.ReadLine();
            Console.WriteLine("Ingrese año de publicacion del Libro");
            libro.AnioPublicado = Console.ReadLine();
            ejemplar.Add(libro);
            break;
    }
    ejemplar.Add();
}
void RegistrarPrestamo()
{
    Console.WriteLine("Ingrese el Titulo del libro que desea prestar");
    string buscar = Console.ReadLine();
    foreach(Ejemplares e in ejemplar)
    {
        if(e.Titulo == buscar)
        {
            Console.WriteLine("Ingrese el nombre del socio");
            string nombreSocio = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de prestamo");
            DateTime fechaPrestamo = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de devolución");
            DateTime fechaDevolucion = DateTime.Parse(Console.ReadLine());
            e.Devolucion = true;
            Prestamo prestamo = new Prestamo();
            prestamo.CodigoEjemplar = e.Código;
            prestamo.FechaPréstamo = fechaPrestamo;
            prestamo.FechaDevolución = fechaDevolucion;
            prestamo.NombreSocio = nombreSocio;
        }
    }

}
void RegistrarDevolucion()
{
 foreach(Ejemplares e in ejemplar)
    {
        if(e.Devolucion == true)
        {
            Console.WriteLine("Ingrese el Titulo del libro que desea devolver");
            string buscar = Console.ReadLine();
            if(e.Titulo == buscar)
            {
                e.Devolucion = false;
                Console.WriteLine("El libro ha sido devuelto correctamente");
            }
        }
    }
}
void ConsultarDisp()
{

    Console.WriteLine("Que Libro, o Ejemplar, desea buscar");
    string buscar = Console.ReadLine();

    foreach(Ejemplares e in ejemplar)
    {
     if(e.Devolucion == buscar)
        {
            Console.WriteLine("El libro se encuentra disponible");
            return True;
        }
        else 
        {
            Console.WriteLine("El libro no se encuentra disponible");
            return False;
        }
    }

}

void ListaPendienteDevo()
{
    foreach(Ejemplares e in ejemplar)
    {
        if(e.Devolucion == false)
        {
            Console.WriteLine($"Los ejemplares pendientes de devolución son: {Titulo}, {Autor}, {Genero}, {Código}");
        }
    }
    
}
void ListaEjemplaresPrestados()
{
    foreach(Ejemplares e in ejemplar)
    {
        if(e.Devolucion == true)
        {
            Console.WriteLine($"Los ejemplares prestados son: {Titulo}, {Autor}, {Genero}, {Código}");
        }
    }
    
}

opcion = 0;
opcion = int.Parse(Console.ReadLine());

Console.WriteLine(@"Ingrese una opción: 1,Registar Ejemplar, 
2,Registrar Prestamo, 
3,Registrar Devolución, 
4,Consultar Disponibilidad, 
5,Listado de ejemplares pendientes de devolución
6, Listado de ejemplares prestados.
7, Salir");
switch (opcion)
{
    case 1:
        CrearLibros();
        break;
    case 2:
        RegistrarPrestamo();
        break;
    case 3:
        RegistrarDevolucion();
        break;
        case 4:
        ConsultarDisp();
        break;
    case 5:
        ListaPendienteDevo();
        break;
        case 6:
        ListaEjemplaresPrestados();
        break;
    case 7:
        break;
}

