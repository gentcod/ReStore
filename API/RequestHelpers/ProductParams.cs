namespace API.RequestHelpers
{
   public class ProductParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string Keyword { get; set; }
        public string Brands { get; set; }
        public string Types { get; set; }
    }
}