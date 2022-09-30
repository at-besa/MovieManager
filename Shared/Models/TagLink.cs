namespace MovieManager.Shared.Models
{
    public partial class TagLink
    {
        public int? TagId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
    }
}
