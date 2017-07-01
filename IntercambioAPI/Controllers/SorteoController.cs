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
    public class SorteoController : ApiController
    {

        private SorteoBLL sorteoBll = new SorteoBLL();

        [HttpPost, Route("api/sorteo")]
        public IHttpActionResult RegistrarUsuario()
        {
            try
            {
                if (sorteoBll.GenerarSorteo())
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
