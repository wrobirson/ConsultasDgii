namespace Octetus.ConsultasDgii.Core.Messages
{
    public class RespuestaConsultaENcf
    {
        public string RncEmisor { get; set; }
        public string RncComprador { get; set; }
        public string ENcf { get; set; }
        public string CodigoSeguridad { get; set; }
        public string Estado { get; set; }

        public decimal MontoTotal	 { get; set; }
        public decimal TotalITBIS { get; set; }
        public string FechaEmision	 { get; set; }
        public string FechaFirma { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }


}
