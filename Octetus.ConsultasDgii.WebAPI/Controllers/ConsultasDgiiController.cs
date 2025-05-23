using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Octetus.ConsultasDgii.Core.Interfaces;
using Octetus.ConsultasDgii.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octetus.ConsultasDgii.WebAPI.Controllers
{
    [ApiController]
    [Route("consultas-dgii")]
    public class ConsultasDgiiController : ControllerBase, IServicioConsultasDgii
    {
        private readonly IServicioConsultasDgii _servicioConsultasDgii;

        public ConsultasDgiiController(IServicioConsultasDgii servicioConsultasDgii)
        {
            this._servicioConsultasDgii = servicioConsultasDgii;
        }

        [HttpPost("consutar-ncf")]
        [Consumes("application/x-www-form-urlencoded")]
        public RespuestaConsultaNcf ConsultarNcf([FromForm] string ncf, [FromForm] string rnc)
        {
            return _servicioConsultasDgii.ConsultarNcf(ncf, rnc);
        }

        [HttpPost("consutar-encf")]
        [Consumes("application/x-www-form-urlencoded")]
        public RespuestaConsultaENcf ConsultarENcf(string rncEmisor, string eNcf, string rncComprador, string codigoSeg)
        {
            return _servicioConsultasDgii.ConsultarENcf(rncEmisor, eNcf, rncComprador, codigoSeg);
        }

        [HttpPost("consutar-rnc-contribuyente")]
        [Consumes("application/x-www-form-urlencoded")]
        public RespuestaConsultaRncContribuyentes ConsultarRncContribuyentes([FromForm] string rnc)
        {
            return _servicioConsultasDgii.ConsultarRncContribuyentes(rnc);
        }

        [HttpPost("consutar-rnc-registrados")]
        [Consumes("application/x-www-form-urlencoded")]
        public RespuestaConsultaRncRegistrados ConsultarRncRegistrados([FromForm] string rnc)
        {
            return _servicioConsultasDgii.ConsultarRncRegistrados(rnc);
        }
    }
}
