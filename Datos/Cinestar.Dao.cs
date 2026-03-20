using Cinestar.database;
using Cinestar.Models;
using Microsoft.Extensions.Configuration;

namespace Cinestar.Datos
{
    public class daoCinestar
    {
        private readonly ConexionBD clsBD;

        //Constructor para inicializar la clase clsBD con la configuración de la cadena de conexión
        public daoCinestar(IConfiguration configuration)
        {
            clsBD = new ConexionBD(configuration, "CadenaSQLAzure");
        }

        //Metodo para obtener un cine en especifico
        internal Cine getCine(int idCine)
        {
            clsBD.Setencia($"exec sp_getCine {idCine}");

            Cine cine = new Cine();
            cine.setRegistro(clsBD.getRegistro());

            return cine;
        }

        //Metodo para obtener la lista de cines
        internal List<Cine> getVerCines()
        {
            clsBD.Setencia("exec sp_getCines");
            return new Cine().getList(clsBD.getRegistros());
        }

        //Metodo para obtener las tarifas de un cine
        internal dynamic getCineTarifas(int idCine)
        {
            clsBD.Setencia($"exec sp_getCineTarifas {idCine}");
            return new CineTarifa().getList(clsBD.getRegistros());
        }

        //Metodo para obtener las peliculas de un cine
        internal dynamic getCinePeliculas(int idCine)
        {
            clsBD.Setencia($"exec sp_getCinePeliculas {idCine}");
            return new CinePelicula().getList(clsBD.getRegistros());
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
