using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Entity
{
    public class Movie
    {
        public Movie() // her movie objesi olıuşturulduğunda boş bir referansta oluşturabiliriz
        {
			Genres = new List<Genre>();
		}
		public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public bool IsClassic { get; set; }
        public List<Genre> Genres { get; set; }//bir filmin birden fazla türü olabilecek

    }
}
