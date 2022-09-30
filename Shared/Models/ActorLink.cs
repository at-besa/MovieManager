namespace MovieManager.Shared.Models
{
    public partial class ActorLink
    {
        public int? ActorId { get; set; }
        public int? MediaId { get; set; }
        public string MediaType { get; set; }
        public string Role { get; set; }
        public int? CastOrder { get; set; }
    }
}
