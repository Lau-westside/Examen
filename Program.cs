
List<Ejemplar> ejemplares = new List<Ejemplar>();
List<Prestamo> prestamos = new List<Prestamo>();

void CrearLibros()
{
    Console.WriteLine("Ingrese que quiere Registrar, 1- DVD, 2- Libro, 3- Revista");
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
            dvd.Duracion = Console.ReadLine();
            ejemplares.Add(dvd);
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
            libro.AnioPublicado = DateTime.Parse(Console.ReadLine());
            ejemplares.Add(libro);
            break;
        case 3:
            Revista revista = new Revista();
            Console.WriteLine("Ingrese el Titulo de la Revista");
            revista.Titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el Autor de la Revista");
            revista.Autor = Console.ReadLine();
            Console.WriteLine("Ingrese el Genero de la Revista");
            revista.Genero = Console.ReadLine();
            Console.WriteLine("Ingrese el Numero de la Revista");
            revista.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Fecha de la Revista");
            revista.Fecha = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Numero de Codigo de la Revista");
            revista.Código = int.Parse(Console.ReadLine());
            ejemplares.Add(revista); 
            break;
    }
    Console.WriteLine("El ejemplar ha sido registrado correctamente");
   Menu();
}

void RegistrarPrestamo()
{
    Console.WriteLine("Ingrese el Titulo del libro que desea prestar");
    string buscar = Console.ReadLine();
    Ejemplar ejemplar = null;
    foreach (Ejemplar p in ejemplares)
    {
        if (p.Titulo == buscar)
        {
            ejemplar = p;
            break;
        }
    }

    if (ejemplar == null)
    {
        Console.WriteLine("No se encontró el ejemplar con ese título");
        return;
    }

    Console.WriteLine("Ingrese el nombre del socio");
    string nombreSocio = Console.ReadLine();
    Console.WriteLine("Ingrese la fecha de prestamo");
    DateTime fechaPrestamo = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese la fecha de devolución");
    DateTime fechaDevolucion = DateTime.Parse(Console.ReadLine());

    Prestamo prestamo = new Prestamo();
    prestamo.CodigoEjemplar = ejemplar.Código;
    prestamo.FechaPréstamo = fechaPrestamo;
    prestamo.FechaDevolución = fechaDevolucion;
    prestamo.NombreSocio = nombreSocio;
    prestamo.Devolucion = true;
    prestamos.Add(prestamo);

    Console.WriteLine("El prestamo ha sido registrado correctamente");
    Menu();
}

void RegistrarDevolucion()
{
    Console.WriteLine("Ingrese el Titulo del libro que desea devolver");
    string buscar = Console.ReadLine();
    Ejemplar e = null;

    foreach (Ejemplar ejemplar in ejemplares)
    {
        if (ejemplar.Titulo == buscar)
        {
            e = ejemplar;
            break;
        }
    }

    if (e == null)
    {
        Console.WriteLine("No se encontró el ejemplar con ese título");
        Menu();
        return;
    }

    foreach (Prestamo p in prestamos)
    {
        if (p.CodigoEjemplar == e.Código && p.Devolucion == true)
        {
            p.Devolucion = false;
            Console.WriteLine("El libro ha sido devuelto correctamente");
            Menu();
            return;
        }
    }

    Console.WriteLine("No hay un prestamo activo para ese ejemplar");
    Menu();
}

void ConsultarDisp()
{
    Console.WriteLine("Que Libro, o Ejemplar, desea buscar");
    string buscar = Console.ReadLine();
    Ejemplar ejemplar = null;

    foreach (Ejemplar e in ejemplares)
    {
        if (e.Titulo == buscar)
        {
            ejemplar = e;
            break;
        }
    }

    if (ejemplar == null)
    {
        Console.WriteLine("No se encontró el ejemplar con ese título");
        Menu();
        return;
    }

    bool estaPrestado = false;
    foreach (Prestamo p in prestamos)
    {
        if (p.CodigoEjemplar == ejemplar.Código && p.Devolucion == true)
        {
            estaPrestado = true;
            break;
        }
    }

    if (estaPrestado)
    {
        Console.WriteLine("El libro no se encuentra disponible");
    }
    else
    {
        Console.WriteLine("El libro se encuentra disponible");
    }

}


void ListaPendienteDevo()
{
    foreach (Prestamo p in prestamos)
    {
        if (p.Devolucion == true)
        {
            Ejemplar ejemplar = null;
            foreach (Ejemplar e in ejemplares)
            {
                if (e.Código == p.CodigoEjemplar)
                {
                    ejemplar = e;
                    break;
                }
            }
            if (ejemplar != null)
            {
                Console.WriteLine($"Los ejemplares pendientes de devolución son: {ejemplar.Titulo}, {ejemplar.Autor}, {ejemplar.Genero}, {ejemplar.Código}");
            }
        }
    }

}


void ListaEjemplaresPrestados()
{
    foreach (Prestamo p in prestamos)
    {
        if (p.Devolucion == true)
        {
            Ejemplar ejemplar = null;
            foreach (Ejemplar e in ejemplares)
            {
                if (e.Código == p.CodigoEjemplar)
                {
                    ejemplar = e;
                    break;
                }
            }
            if (ejemplar != null)
            {
                Console.WriteLine($"Los ejemplares prestados son: {ejemplar.Titulo}, {ejemplar.Autor}, {ejemplar.Genero}, {ejemplar.Código}");
            }
        }
    }
Menu();
}


void Menu()
{
    Console.WriteLine(@"Ingrese una opción: 
1-Registar Ejemplar, 
2-Registrar Prestamo, 
3-Registrar Devolución, 
4-Consultar Disponibilidad, 
5-Listado de ejemplares pendientes de devolución
6- Listado de ejemplares prestados.
7- Salir");

    int Opcion;
    Opcion = int.Parse(Console.ReadLine());
    do
    {
        switch (Opcion)
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
} 
while (Opcion != 7);
Menu();
}




