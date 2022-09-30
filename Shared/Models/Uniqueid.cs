namespace MovieManager.Shared.Models
{
    public partial class Uniqueid
    {
        public int UniqueidId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
