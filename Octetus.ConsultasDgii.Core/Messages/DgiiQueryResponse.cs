namespace Octetus.ConsultasDgii.Core.Messages
{
    public class DgiiQueryResponse
    {
        public string Rnc { get; set; }

        public string Nombre { get; set; }

        public bool IsOk => !string.IsNullOrEmpty(Rnc) && !string.IsNullOrEmpty(Nombre);
    }

}
