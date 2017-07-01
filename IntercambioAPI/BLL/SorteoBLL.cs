using IntercambioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntercambioAPI.BLL
{
    public class SorteoBLL : BLLBase
    {

        public bool GenerarSorteo()
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Sorteo> sorteosExistentes = db.Sorteo.ToList();
                if(sorteosExistentes != null && sorteosExistentes.Count() > 0)
                {
                    return false;
                }

                Random rnd = new Random();
                List<Participantes> participantes = db.Participantes
                    .Where(pp => pp.Asistencia.Afirmacion == true)
                    .ToList();

                Participantes p;
                int i;
                int iteraciones = participantes.Count() * 5;
                for (i = 1; i < iteraciones; i++)
                {
                    int idx = rnd.Next(0, participantes.Count());
                    p = participantes.ElementAt(idx);
                    participantes.RemoveAt(idx);
                    participantes.Add(p);
                }

                i = 0;
                Sorteo s;
                while(i < participantes.Count())
                {
                    s = new Sorteo();
                    if(i == participantes.Count() - 1)
                    {
                        s.IdPart1 = participantes.ElementAt(i).IdPart;
                        s.IdPartInter = participantes.ElementAt(0).IdPart;
                    }
                    else
                    {
                        s.IdPart1 = participantes.ElementAt(i).IdPart;
                        s.IdPartInter = participantes.ElementAt(i +1).IdPart;
                    }
                    db.Sorteo.Add(s);
                    i++;
                }

                db.SaveChanges();
                return true;
            }
        }


        public List<Sorteo> ListarSorteos()
        {
            using(var db = this.dbContext)
            {
                return db.Sorteo.ToList();
            }
        }

        public void RegistrarSorteos(List<Sorteo> sorteos)
        {
            this.dbContext.Sorteo.AddRange(sorteos);
            this.dbContext.SaveChanges();
        }

        public Sorteo ObtenerSorteoPorUsuario(string usuario)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Sorteo
                    .Include("Participantes")
                    .Include("Participantes1")
                    .Where(s => s.Participantes.IdUsuario == usuario)
                    .FirstOrDefault();
            }
        }
    }
}