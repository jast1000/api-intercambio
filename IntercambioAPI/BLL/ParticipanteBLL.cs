using IntercambioAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntercambioAPI.BLL
{
    public class ParticipanteBLL : BLLBase
    {

        public bool ActualizarPerfilParticipante(Participantes participante)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                Participantes part = db.Participantes.Where(p => p.IdUsuario == participante.IdUsuario)
                    .FirstOrDefault();

                if(part != null)
                {
                    part.Area = participante.Area;
                    part.Edad = participante.Edad;
                    part.Grado = participante.Grado;
                    part.Grupo = participante.Grupo;
                    part.Gustos = participante.Gustos;
                    part.Nombre = participante.Nombre;
                    part.OpcionesIntercambio = participante.OpcionesIntercambio;
                    part.Sexo = participante.Sexo;

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Participantes ObtenerPerfilParticipante(string usuario)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Participantes
                    .Where(p => p.IdUsuario == usuario)
                    .FirstOrDefault();
            }
        }

        public List<Participantes> ObtenerParticipantesPorAsistencia(bool asistencia)
        {
            using(var db = this.dbContext)
            {
                return db.Participantes
                    .Include("Asistencia")
                    .Where(p => p.Asistencia.Afirmacion == true)
                    .ToList();
            }
        }
    }
}