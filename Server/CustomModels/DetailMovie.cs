using System.Collections.Generic;
using MovieManager.Shared.Models;

namespace MovieManager.Server.CustomModels
{
    public class DetailMovie
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
        public MovieView MovieDetails { get; set; }
        public IEnumerable<Streamdetails> Details { get; set; }


    }
}
