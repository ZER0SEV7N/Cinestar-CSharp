using Cinestar.database;
using Cinestar.Models;

namespace Cinestar.Datos
{
    public class daoCinestar
    {
        private readonly ConexionBD _ConexionBD;

        //Constructor para inicializar la clase clsBD con la configuración de la cadena de conexión
        public daoCinestar(ConexionBD ConexionBD)
        {
            _ConexionBD = ConexionBD;
        }

        //Metodo para obtener un cine en especifico
        internal Cine getCine(int idCine)
        {
            _ConexionBD.Setencia($"sp_getCine {idCine}");

            Cine cine = new Cine();
            cine.setRegistro(_ConexionBD.getRegistro());

            return cine;
        }

        //Metodo para obtener la lista de cines
        internal List<Cine> getVerCines()
        {
            _ConexionBD.Setencia("sp_getCines");
            return new Cine().getList(_ConexionBD.getRegistros());
        }

        //Metodo para obtener las tarifas de un cine
        internal dynamic getCineTarifas(int idCine)
        {
            _ConexionBD.Setencia($"sp_getCineTarifas {idCine}");
            return new CineTarifa().getList(_ConexionBD.getRegistros());
        }

        //Metodo para obtener las peliculas de un cine
        internal dynamic getCinePeliculas(int idCine)
        {
            _ConexionBD.Setencia($"sp_getCinePeliculas {idCine}");
            return new CinePelicula().getList(_ConexionBD.getRegistros());
        }
        //Metodo para obtener todas las peliculas de un cine en especifico
        internal List<Pelicula> getVerPeliculas(int id)
        {
            _ConexionBD.Setencia($"sp_getPeliculas {id}");
            return new Pelicula().getList(_ConexionBD.getRegistros());
        }

        //Metodo para obtener una pelicula en especifico
        internal Pelicula getVerPelicula(int idPelicula)
        {
            _ConexionBD.Setencia($"sp_getPelicula {idPelicula}");
            return new Pelicula(_ConexionBD.getRegistro());
        }
    }
}
