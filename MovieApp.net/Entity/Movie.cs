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
        public List<Genre> Genres { get; set; }//bir filmin birden fazla türü olabilecek
        //public Genre Genre { get; set; }/*navigation property, Entity Framework Core'da iki varlık (entity) arasındaki ilişkileri tanımlamak için kullanılır.
        //                                 Örneğin, bir Movie varlığı ile Genre varlığı arasında bir ilişki varsa, bu ilişkiyi Genre navigation property ile tanımlayabilirsiniz.*/
        //public int GenreId { get; set; }//?==null demektir
        /* int? yapmamızın sebebi;
         integer türünde bir değerin başlangıç değeri eğer
        null değilse 0 dır ve eğer 0 sa ve gerekliyse zorunlu doldurmamız gereeken
        kutucuk varsa doldurmasakta 0 atanacaktır bu yüzden null yapmalıyızki
        doldurmamız gereken bir kutucuğu doldurmamışsak hata alalım.*/
    }
}
