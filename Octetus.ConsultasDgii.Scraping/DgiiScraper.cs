using HtmlAgilityPack;
using Octetus.ConsultasDgii.Core.Interfaces;
using Octetus.ConsultasDgii.Core.Messages;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Octetus.ConsultasDgii.ConsultasWeb
{
    public class DgiiScraper : IDgiiQuery
    {
        public  DgiiQueryResponse Execute(DgiiQueryRequest request)
        {
            var resultaConsulta = new DgiiQueryResponse();

            var datos = CosultarRncCedula(request.Rnc);
            if (datos != null)
            {
                resultaConsulta.Rnc = datos[0];
                resultaConsulta.Nombre = datos[1];
            }

            return resultaConsulta;
        }

        private const string RequestUrlConsultaRnc = "https://dgii.gov.do/app/WebApps/ConsultasWeb2/ConsultasWeb/consultas/rnc.aspx";
        private const string RequestUrlConsultaCiudadanos = "https://dgii.gov.do/app/WebApps/ConsultasWeb2/ConsultasWeb/consultas/ciudadanos.aspx";

        public static string[] CosultarRncCedula(string input)
        {
            input = input.Trim().Replace("-", "");

            string[] datos;

            if (input.Length > 9)
            {
                datos = ConsultarCiudadano(input);
            }
            else
            {
                datos = ConsultarRnc(input);
            }

            return datos;
        }

        private static string[] ConsultarRnc(string rnc)
        {
            CookieContainer cookieContainer = new CookieContainer();

            var htmlDocument = GetHtmlDocument(RequestUrlConsultaRnc, cookieContainer);

            string __VIEWSTATE = htmlDocument.DocumentNode.SelectNodes("//input[@name='__VIEWSTATE']").First().Attributes["value"].Value;
            string __EVENTVALIDATION = htmlDocument.DocumentNode.SelectNodes("//input[@name='__EVENTVALIDATION']").First().Attributes["value"].Value;
            string __VIEWSTATEGENERATOR = htmlDocument.DocumentNode.SelectNodes("//input[@name='__VIEWSTATEGENERATOR']").First().Attributes["value"].Value;

            string formData = "";
            formData += "ctl00$smMain=ctl00$cphMain$upBusqueda|ctl00$cphMain$btnBuscarPorRNC&";
            formData += "ctl00$cphMain$txtRNCCedula=" + rnc + "&";
            formData += "ctl00$cphMain$txtRazonSocial=&";
            formData += "__EVENTTARGET=&";
            formData += "__EVENTARGUMENT=&";
            formData += "__VIEWSTATEGENERATOR=" + __VIEWSTATEGENERATOR + "&";

            formData += "__VIEWSTATE=" + HttpUtility.UrlEncode(__VIEWSTATE) + "&";
            formData += "__EVENTVALIDATION=" + HttpUtility.UrlEncode(__EVENTVALIDATION) + "&";
            formData += "__ASYNCPOST=true&";
            formData += "ctl00$cphMain$btnBuscarPorRNC=BUSCAR";

            var postResponseText = SendPostRequest(RequestUrlConsultaRnc, formData, cookieContainer);

            return
                ExtraerValoresRncNombre(postResponseText, "//tr[1]/td[2]", "//tr[2]/td[2]");
        }

        private static string[] ConsultarCiudadano(string rnc)
        {
            CookieContainer container = new CookieContainer();

            var htmlDocument = GetHtmlDocument(RequestUrlConsultaCiudadanos, container);

            string __VIEWSTATE = htmlDocument.DocumentNode.SelectNodes("//input[@name='__VIEWSTATE']").First().Attributes["value"].Value;
            string __EVENTVALIDATION = htmlDocument.DocumentNode.SelectNodes("//input[@name='__EVENTVALIDATION']").First().Attributes["value"].Value;
            string __VIEWSTATEGENERATOR = htmlDocument.DocumentNode.SelectNodes("//input[@name='__VIEWSTATEGENERATOR']").First().Attributes["value"].Value;

            string formData = "";
            formData += "ctl00$smMain=ctl00$cphMain$upBusqueda|ctl00$cphMain$btnBuscarCedula&";
            formData += "ctl00$cphMain$txtCedula=" + rnc + "&";
            formData += "__EVENTTARGET=&";
            formData += "__EVENTARGUMENT=&";
            formData += "__VIEWSTATEGENERATOR=" + __VIEWSTATEGENERATOR + "&";

            formData += "__VIEWSTATE=" + HttpUtility.UrlEncode(__VIEWSTATE) + "&";
            formData += "__EVENTVALIDATION=" + HttpUtility.UrlEncode(__EVENTVALIDATION) + "&";
            formData += "__ASYNCPOST=true&";
            formData += "ctl00$cphMain$btnBuscarCedula=Buscar";

            var postResponseText = SendPostRequest(RequestUrlConsultaCiudadanos, formData, container);

            return
                ExtraerValoresRncNombre(postResponseText, "//tr[4]/td[2]", "//tr[1]/td[2]");
        }

        private static string[] ExtraerValoresRncNombre(string content, string xPathRnc, string xPathNombre)
        {
            // Extrae la table HTML con Regex. 
            // La pagina utiliza el componente update panel de ASP.NET
            // El HTML resultante no puede cangarse directamente en el un objeto HtmlDocument

            Regex regex = new Regex(@"<table.*>[\S\s]*?<\/table>");
            var match = regex.Match(content);
            if (!match.Success)
            {
                return null;
            }

            // Extraemos los valores del la tabla HTML
            var xDocument = XDocument.Parse("<!DOCTYPE doctypeName [<!ENTITY nbsp \"&#160;\">]> " + match.Value);
            var xElementRnc = xDocument.XPathSelectElement(xPathRnc);
            var xElementNombre = xDocument.XPathSelectElement(xPathNombre);

            if (xElementRnc == null || xElementNombre == null)
            {
                return null;
            }

            string valueRnc = xElementRnc.Value;
            string valueNombre = xElementNombre.Value;

            return new[] {
                valueRnc,
                valueNombre
            };
        }

        private static HtmlDocument GetHtmlDocument(string requestUrl, CookieContainer container)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var httpRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            httpRequest.CookieContainer = container;

            var httpResponse = httpRequest.GetResponse();
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(httpResponse.GetResponseStream());
            httpResponse.Close();

            return htmlDocument;
        }

        private static string SendPostRequest(string requestUriString, string postData, CookieContainer container)
        {
            var requestData = Encoding.UTF8.GetBytes(postData);

            var request = WebRequest.Create(requestUriString) as HttpWebRequest;
            request.Headers.Add("X-MicrosoftAjax", "Delta=true");
            request.Referer = requestUriString;
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Origin", "https://dgii.gov.do");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = requestData.Length;
            request.CookieContainer = container;
            request.Timeout = System.Threading.Timeout.Infinite;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
                requestStream.Close();
            }

            string responseText = "";
            using (var response = request.GetResponse())
            using (var responseStreamReader = new StreamReader(response.GetResponseStream()))
            {
                responseText = responseStreamReader.ReadToEnd();
                responseStreamReader.Close();
                response.Close();
            }

            return responseText;
        }
    }
}
