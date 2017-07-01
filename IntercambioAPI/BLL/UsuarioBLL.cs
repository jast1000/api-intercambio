using IntercambioAPI.Models;
using IntercambioAPI.Models.DTO;
using System.Linq;

namespace IntercambioAPI.BLL
{
    public class UsuarioBLL : BLLBase
    {

        public Usuarios BuscarUsuario(string usuario, string password)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Usuarios
                    .Where(u => u.IdUsuario == usuario && u.Password == password)
                    .FirstOrDefault();
            }
        }

        public Usuarios BuscarUsuario(string usuario)
        {
            using (var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;
                Usuarios user = db.Usuarios
                    .Where(u => u.IdUsuario == usuario)
                    .SingleOrDefault();
                return user;
            }
        }

        public bool RegistrarUsuario(Usuarios usuario)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                Usuarios user = db.Usuarios
                    .Where(u => u.IdUsuario == usuario.IdUsuario)
                    .SingleOrDefault();
                if(user == null)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public EstadoAsistenciaDTO ConsultarInvitacionUsuario(string usuario)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;

                Sorteo sorteoUsuario = db.Sorteo
                    .Include("Participantes")
                    .Where(s => s.Participantes.IdUsuario == usuario)
                    .FirstOrDefault();
                if(sorteoUsuario == null)
                {
                    Asistencia asistencia = db.Asistencia.
                    Where(aa => aa.Participantes.IdUsuario == usuario).FirstOrDefault();

                    Reglas regla = db.Reglas.FirstOrDefault();

                    EstadoAsistenciaDTO estadoAsistencia = new EstadoAsistenciaDTO(regla);
                    estadoAsistencia.confirmacion = asistencia != null ? asistencia.Afirmacion : null;

                    return estadoAsistencia;
                }
                return null;
            }
        }

        public bool ActualizarEstadoAsistencia(string usuario, EstadoAsistenciaDTO estadoAsistencia)
        {
            using(var db = this.dbContext)
            {
                db.Configuration.LazyLoadingEnabled = false;
                Asistencia asistencia = db.Asistencia
                    .Where(a => a.Participantes.IdUsuario == usuario)
                    .FirstOrDefault();

                if(asistencia != null)
                {
                    asistencia.Afirmacion = estadoAsistencia.confirmacion;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}