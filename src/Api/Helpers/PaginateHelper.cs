namespace Api.Helpers
{
    public class PaginateHelper
    {
        public byte[] predicate { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public byte[] selector { get; set; }
        public bool descending { get; set; }
    }
}