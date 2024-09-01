using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.net.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.net.Data
{
    public static class DataSeeding
    {
            public static void Seed(IApplicationBuilder app)
            {
            var genres = new List<Genre>()
           {
                new Genre {Name="Macera"},
                new Genre {Name="Komedi"},
                new Genre {Name="Romantik"},
                new Genre {Name="Savaş"},
                new Genre {Name="Bilim Kurgu"}
           };//tür bilgisi
            var movies = new List<Movie>()
            {
                new Movie
                {
                    Title = "Avatar",
                    Description = "Avatar filmi, 2009 yılında James Cameron tarafından yönetilen bir bilim kurgu filmidir. Film, insanlığın Pandora adında uzak" +
                    " bir gezegende yer alan değerli bir minerali elde etmeye çalışırken yerli halk olan Na'vi ile karşılaşmalarını konu alır. Jake Sully adlı " +
                    "bir eski deniz piyadesi, Na'vi halkının arasına sızmak için bir \"Avatar\" programına katılır. Ancak, zamanla Na'vi kültürünü ve doğayla olan " +
                    "derin bağlarını keşfeder, bu da onu zor bir seçimle karşı karşıya bırakır: Kendi insanlarıyla mı yoksa yeni ailesiyle mi duracak? Film, görsel " +
                    "efektleri, yenilikçi 3D teknolojisi ve çevresel mesajlarıyla büyük beğeni topladı ve sinema tarihinde önemli bir yer edindi.",
                    ImageUrl = "Avatar.jpg",
                    Genres =new List<Genre>(){ genres[0], new Genre() {Name="Yeni Tür"}, genres[1] }
                },
                new Movie
                {
                    Title = "Yüzüklerin Efendisi ",
                    Description = "The Lord of the Rings\" (Yüzüklerin Efendisi), J.R.R. Tolkien'in aynı adlı kitabından uyarlanan epik bir fantastik film serisidir." +
                    "\r\n\t Film, Orta Dünya adı verilen hayali bir evrende geçer ve Güç Yüzüğü'nün yok edilmesi için verilen büyük mücadeleyi konu alır.",
                    ImageUrl ="lord_of_the_rings.jpg",
                    Genres =new List<Genre>(){ genres[0], genres[2] }

                },
                new Movie
                {
                    Title = "Titanic",
                    Description = "Titanic\", 1997 yılında James Cameron tarafından yönetilen bir romantik dram filmidir. Film, 1912 yılında ilk seferinde batacak olan RMS" +
                    " \r\n\t Titanic adlı lüks yolcu gemisinin hikayesini anlatır. Hikaye, gemideki genç bir çiftin, Jack Dawson ve Rose DeWitt Bukater'ın (Leonardo DiCaprio" +
                    "\r\n\t ve Kate Winslet tarafından canlandırılır) aşkını ve trajik sonlarını konu alır. Jack ve Rose'un karşılaşmaları ve aşkları, Titanic'in okyanusta \r\n\t " +
                    "batışıyla dramatik bir şekilde kesişir. Film, görsel efektleri, duygusal derinliği ve büyük bütçesiyle büyük beğeni topladı ve birçok ödül kazandı",
                    ImageUrl ="Titanic.jpg",
                    Genres =new List<Genre>(){ genres[1], genres[3] }

                },
                new Movie
                {
                    Title = "Film 4",
                    Description = "açıklama 4",
                    ImageUrl = "Avatar.jpg",
                    Genres =new List<Genre>(){ genres[0], genres[1] }
                },
                new Movie
                {
                    Title = "Film 5",
                    Description = "açıklama 5",
                    ImageUrl ="lord_of_the_rings.jpg",
                    Genres =new List<Genre>(){ genres[2], genres[4] }
                },
                new Movie
                {
                    Title = "Film 6",
                    Description = "açıklama 6",
                    ImageUrl ="Titanic.jpg",
                    Genres =new List<Genre>(){ genres[1], genres[2] }
                }
            };//film bilgisi
            var users = new List<User>()
            {
                new User(){UserName="usera",Email="usera@gmail.com",Password="1234",ImageUrl="persona1,jpg"},
                new User(){UserName="userb",Email="userb@gmail.com",Password="1234",ImageUrl="persona2,jpg"},
                new User(){UserName="userc",Email="userc@gmail.com",Password="1234",ImageUrl="persona3,jpg"},
                new User(){UserName="userd",Email="userd@gmail.com",Password="1234",ImageUrl="persona4,jpg"}

            };//kullanıcı bilgileri
            var people = new List<Person>() {
                new Person()
                {
                    Name = "Personel 1",
                    Biography = "tanıtım 1",
                    User =users[0]
                },
                new Person()
                {
                    Name = "Personel 2",
                    Biography = "tanıtım 2",
                    User =users[1]
                }
            };//personel bilgileri
            var crews = new List<Crew>()
            {
                new Crew() {Movie=movies[0],Person=people[0],Job="Yönetmen"},
                new Crew() {Movie=movies[0],Person=people[1],Job="Yönetmen Yard."}
            };
            var casts = new List<Cast>()
            {
                new Cast(){Movie=movies[0], Person=people[0], Name="Oyuncu adı", Character="karakter 1" },
                new Cast(){Movie=movies[0], Person=people[1], Name="Oyuncu adı", Character="karakter 2" }

            };


            var scope = app.ApplicationServices.CreateScope();
                var context = scope.ServiceProvider.GetService<MovieContext>();

                context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Movies.Count()==0)
                {
                    context.Movies.AddRange(movies);
                }

                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }

                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }

                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }

                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }

                context.SaveChanges();
            }
            }
    }
}
/*burda mssql kullandığımız zaman bir hata aldık burda id paramaetresini biz kendimiz
gönderdiğimiz için hataya neden oldu bu yüzden bu kısımda mssql kullanıyorsak id parametrelerini silmeliyiz otomatik atar*/
 /*otomztik id ataması istemiyorsak ilgili özelliğin üzerine gelip
  [Key,DatabaseGenerated(DatabaseGeneratedOption.None)] özelliği eklersek
 bütün objelerine kendimiz id girmek zorunda kalırız artık.*/