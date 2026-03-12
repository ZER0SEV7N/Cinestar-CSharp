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

        public CineTarifa() { }
        public CineTarifa(string DiasSemana, decimal Precio)
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
                if (decimal.TryParse(aRegistro[1], out decimal precio))
                    lstLista.Add(new CineTarifa(aRegistro[0], precio));
            }
            return lstLista;
        }
    }
}
