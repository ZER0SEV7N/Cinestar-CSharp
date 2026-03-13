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

        //Director
        public string Director { get; set; }

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

        //Valido
        public bool Valido { get; set; }

        //Constructor vacio
        public Pelicula() { }

        //Constructor para inicializar la pelicula con un registro de la base de datos
        public Pelicula(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        //Metodo para asignar los valores del registro a las propiedades de la pelicula
        private void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro != null;
            if (!Valido) return;

            id = int.Parse(aRegistro[0]);
            Titulo = aRegistro[1];
            if (aRegistro.Length == 4)
            {
                Link = aRegistro[2];
                Sinopsis = aRegistro[3];
            }
            else
            {
                FechaEstreno = aRegistro[2];
                Director = aRegistro[3];
                Generos = aRegistro[11];
                idClasificacion = int.Parse(aRegistro[5]);
                idEstado = int.Parse(aRegistro[6]);
                Duracion = aRegistro[7];
                Link = aRegistro[8];
                Reparto = aRegistro[9];
                Sinopsis = aRegistro[10];

            }
        }

        //Metodo para obtener la lista de peliculas a partir de los registros de la base de datos
        internal List<Pelicula> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;
            List<Pelicula> lstLista = new List<Pelicula>();
            foreach (string[] aRegistro in mRegistros)
                lstLista.Add(new Pelicula(aRegistro));
            return lstLista;
        }
    }
}
