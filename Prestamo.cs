public class Prestamo : Biblioteca
{
     public int CodigoEjemplar {get; set;}
     public DateTime FechaPréstamo {get; set;}
     public DateTime FechaDevolución {get; set;}
     public string NombreSocio {get; set;}
     public bool Devolucion {get; set;}

}