namespace Api.Helpers
{
    public class PaginateVincular
    {
        public PaginateVincular()
        {
            this.filtro = "0";
        }
        public int idParametro { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int orden { get; set; }
        public bool ascd { get; set; }
        public int tipo { get; set; }
        public string filtro { get; set; }
    }
}