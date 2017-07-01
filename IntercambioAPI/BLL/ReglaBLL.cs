using IntercambioAPI.Models;
using IntercambioAPI.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace IntercambioAPI.BLL
{
    public class ReglaBLL : BLLBase
    {
        public List<IntercambioDTO> ListarReglas()
        {
            List<IntercambioDTO> intercambios = new List<IntercambioDTO>();
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<Sorteo> sorteos = db.Sorteo.ToList();
                List<Reglas> reglas = db.Reglas.ToList();

                IntercambioDTO intercambio;
                foreach(var i in reglas)
                {
                    intercambio = new IntercambioDTO(i);
                    intercambio.estado = sorteos.Count() == 0 ? (short)1 : (short)2;
                    intercambios.Add(intercambio);
                }
                return intercambios;
            }
        }

        public bool GuardarRegla(Reglas regla)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<Reglas> reglas = db.Reglas.ToList();

                if(reglas != null && reglas.Count() > 0)
                {
                    return false;
                }
                else
                {
                    db.Reglas.Add(regla);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}