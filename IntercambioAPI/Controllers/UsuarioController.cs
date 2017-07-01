using IntercambioAPI.BLL;
using IntercambioAPI.Models;
using IntercambioAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntercambioAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        private UsuarioBLL usuarioBll = new UsuarioBLL();
        private SorteoBLL sorteoBll = new SorteoBLL();

        [HttpPost, Route("api/usuarios/identificacion")]
        public IHttpActionResult IdentificarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                Usuarios u = usuarioBll.BuscarUsuario(usuario.usuario, usuario.password);
                if(u == null)
                {
                    return Unauthorized();
                }
                else
                {
                    usuario = new UsuarioDTO(u);
                    usuario.password = null;
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost, Route("api/usuarios")]
        public IHttpActionResult RegistrarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                usuario.password = System.Guid.NewGuid().ToString().Substring(0, 5);
                if(usuarioBll.RegistrarUsuario(new Usuarios(usuario)))
                {
                    return Ok();
                }
                else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet, Route("api/usuarios/{usuario}/pareja")]
        public IHttpActionResult ConsultarPareja(string usuario)
        {
            try
            {
                Sorteo sorteo = this.sorteoBll.ObtenerSorteoPorUsuario(usuario);
                if(sorteo != null)
                {
                    return Ok(new PerfilUsuarioDTO(sorteo.Participantes1));
                } else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet, Route("api/usuarios/{usuario}/invitacion")]
        public IHttpActionResult ConsultarInvitacion(string usuario)
        {
            try
            {
                EstadoAsistenciaDTO asistencia = usuarioBll.ConsultarInvitacionUsuario(usuario);
                if (asistencia != null)
                {
                    return Ok(asistencia);
                }
                else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPut, Route("api/usuarios/{usuario}/invitacion")]
        public IHttpActionResult ActualizarEstadoAsistencia(string usuario, [FromBody] EstadoAsistenciaDTO estadoAsistencia)
        {
            try
            {   
                if (usuarioBll.ActualizarEstadoAsistencia(usuario, estadoAsistencia))
                {
                    return Ok();
                }
                else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }


}
