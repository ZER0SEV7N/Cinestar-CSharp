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

        //Titulo de la pelicula 
        public string Titulo { get; set; }

        //Horarios
        public string Horarios { get; set; }

        public CinePelicula() { }
        public CinePelicula(string titulo, string horarios)
        {
            this.Titulo = titulo;
            this.Horarios = horarios;
        }

        internal dynamic getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;
            List<CinePelicula> lstLista = new List<CinePelicula>();
            foreach (string[] aRegistro in mRegistros)
                 lstLista.Add(new CinePelicula(aRegistro[0], aRegistro[1]));
            return lstLista;
        }
    }
}
