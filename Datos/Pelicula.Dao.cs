using Cinestar.database;
using Cinestar.Models;

namespace Cinestar.Datos
{
    public class daoPelicula
    {
        private readonly clsBD clsBD;

        //Constructor para inicializar la clase clsBD con la configuración de la cadena de conexión
        public daoPelicula(IConfiguration configuration)
        {
            clsBD = new clsBD(configuration, "CadenaSQLLocal");
        }
        //Metodo para obtener todas las peliculas de un cine en especifico
        internal List<Pelicula> getVerPeliculas(int id)
        {
            clsBD.Setencia($"exec sp_getPeliculas {id}");
            return new Pelicula().getList(clsBD.getRegistros());
        }

        //Metodo para obtener una pelicula en especifico
        internal Pelicula getVerPelicula(int idPelicula)
        {
            clsBD.Setencia($"exec sp_getPelicula {idPelicula}");
            return new Pelicula(clsBD.getRegistro());
        }
    }
}
