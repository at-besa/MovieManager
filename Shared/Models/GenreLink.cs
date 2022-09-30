namespace MovieManager.Shared.Models
{
    public partial class GenreLink
    {
        public int? GenreId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
    }
}
