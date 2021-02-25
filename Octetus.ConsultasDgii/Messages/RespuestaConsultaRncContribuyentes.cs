namespace Octetus.ConsultasDgii.Core.Messages
{
    public class RespuestaConsultaRncContribuyentes
    {
        public string CedulaORnc { get; set; }
        public string NombreORazónSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Categoría { get; set; }
        public string RegimenDePagos { get; set; }
        public string Estado { get; set; }
        public string ActividadEconomica { get; set; }
        public string AdministracionLocal { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }


}
