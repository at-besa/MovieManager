namespace MovieManager.Shared.Models
{
    public partial class SeasonView
    {
        public int IdSeason { get; set; }
        public int? IdShow { get; set; }
        public int? Season { get; set; }
        public string Name { get; set; }
        public int? Userrating { get; set; }
        public string StrPath { get; set; }
        public string ShowTitle { get; set; }
        public string Plot { get; set; }
        public string Premiered { get; set; }
        public string Genre { get; set; }
        public string Studio { get; set; }
        public string Mpaa { get; set; }
        public long Episodes { get; set; }
        public long PlayCount { get; set; }
        public string Aired { get; set; }
    }
}
