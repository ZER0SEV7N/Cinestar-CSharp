namespace Cinestar.Models
{
    //Modelo de CinePelicula
    public class CinePelicula
    {
        //Id del cine
        public int idCine { get; set; }

        //id de la pelicula
        public int idPelicula { get; set; }

        //Sala
        public int Sala { get; set; }

        //Horarios
        public string Horarios { get; set; }
    }
}
