﻿using Octetus.ConsultasDgii.Core.Messages;

namespace Octetus.ConsultasDgii.Core.Interfaces
{
    public interface IServicioConsultasDgii
    {
        RespuestaConsultaRncContribuyentes ConsultarRncContribuyentes(string rnc);

        RespuestaConsultaRncRegistrados ConsultarRncRegistrados(string rnc);

        RespuestaConsultaNcf ConsultarNcf(string ncf, string rnc);

        RespuestaConsultaENcf ConsultarENcf(string rncEmisor, string ncf, string rncComprador, string codigoSeg);
    }

}
