using IntercambioAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntercambioAPI.BLL
{
    public class AsistenciaBLL: BLLBase
    {

        public void RegistrarAsistencia(Asistencia asistencia)
        {
            this.dbContext.Asistencia.Add(asistencia);
            this.dbContext.SaveChanges();
        }

        public void ActualizarAsistencia(Asistencia asistencia)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                Asistencia a = db.Asistencia.Where(asi => asi.IdPart == asistencia.IdPart).FirstOrDefault();
                a.Afirmacion = asistencia.Afirmacion;

                db.SaveChanges();
            }
        }

        public Asistencia ObtenerAsistenciaUsuario(string usuario)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Asistencia
                    .Include("Participantes")
                    .Where(a => a.Participantes.IdUsuario == usuario)
                    .FirstOrDefault();
            }
        }
    }
}