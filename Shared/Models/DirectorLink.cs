namespace MovieManager.Shared.Models
{
    public partial class DirectorLink
    {
        public int? ActorId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
    }
}
