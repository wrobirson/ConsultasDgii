namespace Octetus.ConsultasDgii.Core.Messages
{
    public class RespuestaConsultaRncRegistrados
    {
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string RncOCedula { get; set; }
        public string Actividad { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }


}
