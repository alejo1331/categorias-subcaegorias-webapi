

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class PPTAM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string municipioCodigo { get; set; }
        public string municipioNombre { get; set; }
        public string departamentoCodigo { get; set; }
        public string departamentoNombre { get; set; }
        public string horarioAtencion { get; set; }
        public string puntoAtencionDireccion { get; set; }
        public string puntoAtencionTelefono { get; set; }
        public string institucionId { get; set; }
        public string esSedePrincipal { get; set; }
    }
}