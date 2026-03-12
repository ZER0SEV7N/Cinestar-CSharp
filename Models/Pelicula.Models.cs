namespace Cinestar.Models
{
    //Modelo de Pelicula
    public class Pelicula
    {
        //id de la pelicula
        public int id { get; set; }

        //titulo de la pelicula
        public string Titulo { get; set; }

        //Fecha de estreno
        public string FechaEstreno { get; set; }

        //Generos
        public string Generos { get; set; }

        //idClasificacion
        public int idClasificacion { get; set; }

        //idEstado
        public int idEstado { get; set; }

        //Duracion
        public string Duracion { get; set; }

        //Link 
        public string Link { get; set; }

        //Reparto
        public string Reparto { get; set; }

        //Sinopsis
        public string Sinopsis { get; set; }
    }
}
