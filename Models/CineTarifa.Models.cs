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
        public string Precio { get; set; }

        public CineTarifa() { }
        public CineTarifa(string DiasSemana, string Precio)
        {
            this.DiasSemana = DiasSemana;
            this.Precio = Precio;
        }

        internal dynamic getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;
            List<CineTarifa> lstLista = new List<CineTarifa>();
            foreach (string[] aRegistro in mRegistros)
            {
                lstLista.Add(new CineTarifa(aRegistro[0], aRegistro[1]));
            }
            return lstLista;
        }
    }
}
