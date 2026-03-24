using Microsoft.Data.SqlClient;
using System.Data;

namespace Cinestar.database
{
    //Conexion a la base de datos
    public class ConexionBD
    {
        //Cadena de conexion
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        //Constructor
        public ConexionBD(IConfiguration configuration, string bd )
        {
            cn = new SqlConnection(configuration.GetConnectionString(bd));
            cmd = new SqlCommand("", cn);
            da = new SqlDataAdapter(cmd);
        }

        //Metodo para ejecutar una sentencia SQL
        internal void Setencia(string SQL)
        {
            cmd.CommandText = SQL;
            cmd.Parameters.Clear();
        }

        //Metodo para obtener un DataTable
        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Metodo para obtener un registro
        internal string[]? getRegistro()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;
            return System.Array.ConvertAll(dt.Rows[0].ItemArray, x => x?.ToString()?.Trim() ?? "");
        }
        //Metodo para obtener los registros
        internal string[][]? getRegistros()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;
            int i = 0;
            string[][] mRegistros = new string[dt.Rows.Count][];
            foreach(DataRow dr in dt.Rows) 
                mRegistros[i++] = System.Array.ConvertAll(dr.ItemArray, x => x?.ToString()?.Trim() ?? ""); 
            return mRegistros;
        }
    }
}
