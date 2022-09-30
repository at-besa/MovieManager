namespace MovieManager.Shared.Models
{
    public partial class CountryLink
    {
        public int? CountryId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
    }
}
