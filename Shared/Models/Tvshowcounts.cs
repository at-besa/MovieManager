namespace MovieManager.Shared.Models
{
    public partial class Tvshowcounts
    {
        public int IdShow { get; set; }
        public string LastPlayed { get; set; }
        public long TotalCount { get; set; }
        public long Watchedcount { get; set; }
        public long TotalSeasons { get; set; }
        public string DateAdded { get; set; }
    }
}
