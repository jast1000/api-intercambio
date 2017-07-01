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
    public class IntercambioController : ApiController
    {
        private ReglaBLL reglaBll = new ReglaBLL();

        [HttpGet, Route("api/intercambios")]
        public IHttpActionResult ConsultarPerfilParticipante()
        {
            try
            {
                List<IntercambioDTO> intercambios = reglaBll.ListarReglas();
                if (intercambios != null && intercambios.Count() > 0)
                {
                    return Ok(intercambios);
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

        [HttpPost, Route("api/intercambios")]
        public IHttpActionResult GuardarIntercambio([FromBody] IntercambioDTO intercambio)
        {
            try
            {
                if (reglaBll.GuardarRegla(new Reglas(intercambio)))
                {
                    return Ok();
                } else
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
