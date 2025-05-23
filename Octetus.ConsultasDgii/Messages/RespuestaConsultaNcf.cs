namespace Octetus.ConsultasDgii.Core.Messages
{
    public class RespuestaConsultaNcf
    {
        public string RncOCedula { get; set; }
        public string NombreORazónSocial { get; set; }
        public string TipoDeComprobante { get; set; }
        public string NCF { get; set; }
        public string Estado { get; set; }
        public string VálidoHasta	 { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
