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
    public class PerfilController : ApiController
    {
        private ParticipanteBLL participanteBll = new ParticipanteBLL();

        [HttpGet, Route("api/perfiles/{usuario}")]
        public IHttpActionResult ConsultarPerfilParticipante(string usuario)
        {
            try
            {
                Participantes participante = participanteBll.ObtenerPerfilParticipante(usuario);
                if(participante != null && participante.Nombre != null && participante.Nombre.Length > 0)
                {
                    return Ok(new PerfilUsuarioDTO(participante));
                }else
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost, Route("api/perfiles")]
        public IHttpActionResult GuardarPerfilUsuario(PerfilUsuarioDTO perfil)
        {
            try
            {
                if (participanteBll.ActualizarPerfilParticipante(new Participantes(perfil)))
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
    }
}
