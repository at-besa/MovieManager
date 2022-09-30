using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManager.Shared.Models
{
    public partial class MovieView
    {
        public int IdMovie { get; set; }
        public int? IdFile { get; set; }
        public string C00 { get; set; }
        public string C01 { get; set; }
        public string C02 { get; set; }
        public string C03 { get; set; }
        public string C04 { get; set; }
        public string C05 { get; set; }
        public string C06 { get; set; }
        public string C07 { get; set; }
        public string C08 { get; set; }
        public string C09 { get; set; }
        public string C10 { get; set; }
        public string C11 { get; set; }
        public string C12 { get; set; }
        public string C13 { get; set; }
        public string C14 { get; set; }
        public string C15 { get; set; }
        public string C16 { get; set; }
        public string C17 { get; set; }
        public string C18 { get; set; }
        public string C19 { get; set; }
        public string C20 { get; set; }
        public string C21 { get; set; }
        public string C22 { get; set; }
        public string C23 { get; set; }
        public int? IdSet { get; set; }
        public int? Userrating { get; set; }
        public string Premiered { get; set; }
        public string StrSet { get; set; }
        public string StrSetOverview { get; set; }
        public string StrFileName { get; set; }
        public string StrPath { get; set; }
        public int? PlayCount { get; set; }
        public string LastPlayed { get; set; }
        public string DateAdded { get; set; }
        public double? ResumeTimeInSeconds { get; set; }
        public double? TotalTimeInSeconds { get; set; }
        public string PlayerState { get; set; }
        public float? Rating { get; set; }
        public int? Votes { get; set; }
        public string RatingType { get; set; }
        public string UniqueidValue { get; set; }
        public string UniqueidType { get; set; }

        [NotMapped] 
        public string  Title { get => C00; set => C00 = value; }
        [NotMapped]
        public string PathPreview { get; set; }
    }
}
