namespace Categorias.Api.Helpers
{
    public class PaginateTramite
    {
        public PaginateTramite()
        {
            this.filtro = "0";
        }
        public string idParametro { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int orden { get; set; }
        public bool ascd { get; set; }
        public int tipo { get; set; }
        public string filtro { get; set; }
    }
}