
using Octetus.ConsultasDgii.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Octetus.ConsultasDgii.Tests
{

    public class ConsultasWebDgiiTest
    {

        ServicioConsultasWebDgii consultasWebDgii = new ServicioConsultasWebDgii();


        [Fact]
        public void TestConsultarRncContribuyentes()
        {
            var res = consultasWebDgii.ConsultarRncContribuyentes("132100123");
            Assert.True(res.Success, "No éxito con un RNC valido ");

            res = consultasWebDgii.ConsultarRncContribuyentes("40220227033");
            Assert.True(res.Success == false && res.Message == "El RNC/Cédula consultado no se encuentra inscrito como Contribuyente.",
                "RNC invalido no retorna mensaje de error");
        }


        [Fact]
        public void TestConsultarNcf()
        {
            // NCF Valido
            var res = consultasWebDgii.ConsultarNcf("B0100000001", "132100123");
            Assert.True(res.Success, "No éxito con un NCF valido ");

            // NCF invalido
            res = consultasWebDgii.ConsultarNcf("B0100000021", "132100123");
            Assert.True(res.Success == false && res.Message == "El Número de Comprobante Fiscal ingresado no es correcto o no corresponde a este RNC",
                "NCF invalido no retorna mensaje de error");
        }

    }


}
