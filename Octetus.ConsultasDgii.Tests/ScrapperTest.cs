using Octetus.ConsultasDgii.ConsultasWeb;
using Octetus.ConsultasDgii.Core.Messages;
using System;
using Xunit;

namespace Octetus.ConsultasDgii.Tests
{
    public class ScrapperTest
    {
        DgiiScraper dgiiScraper = new DgiiScraper();

        [Fact]
        public void TestCedulaValidaIsOk()
        {

            string[] cedulas = new[]
            {
                "00115620486",
                "001-1562048-6",
            };

            foreach (var cedula in cedulas)
            {
                DgiiQueryRequest request = new DgiiQueryRequest();
                request.Rnc = cedula;
                DgiiQueryResponse response = dgiiScraper.Execute(request);
                Assert.True(response.IsOk);
                Assert.Equal("001-1562048-6", response.Rnc);
                Assert.Equal("ESMELIN SANTIAGO MATIAS GARCIA", response.Nombre);
            }
        }

        [Fact]
        public void TestRncValidoIsOk()
        {
            string[] rncs = new []
            {
                "130-17528-4",
                "130175284",
            };

            foreach (var rnc in rncs)
            {
                DgiiQueryRequest request = new DgiiQueryRequest();
                request.Rnc = rnc;
                DgiiQueryResponse response = dgiiScraper.Execute(request);
                Assert.True(response.IsOk);
                Assert.Equal("130-17528-4", response.Rnc);
                Assert.Equal("ADAM AND EVE CLUB S A", response.Nombre);
            }
        }
       
    }
}
