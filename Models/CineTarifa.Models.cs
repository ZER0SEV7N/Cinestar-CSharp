namespace Cinestar.Models
{
    //Modelo de CineTarifa
    public class CineTarifa
    {
        //Id del cine
        public int idCine { get; set; }

        //Dias de la semana
        public string DiasSemana { get; set; }

        //Precio
        public decimal Precio { get; set; }
    }
}
