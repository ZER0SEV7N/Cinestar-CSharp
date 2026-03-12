namespace Cinestar.Models
{
    //Modelo de Cine
    public class Cine
    {
        //Id del cine
        public int id { get; set; }

        //Razon Social
        public string RazonSocial { get; set; }

        //Salas
        public int Salas { get; set; }

        //idDistrito
        public int idDistrito { get; set; }

        //Direccion
        public string Direccion { get; set; }

        //Telefonos
        public string Telefonos { get; set; }
    }
}
