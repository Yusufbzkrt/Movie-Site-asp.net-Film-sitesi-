using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }//bir türün birden fazla filmi olabilecek
    }
}
