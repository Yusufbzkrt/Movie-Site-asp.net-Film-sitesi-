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
                new Genre {Name="Bilim Kurgu"},
				new Genre {Name="Korku"}
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
                    TrailerUrl="/Content/videos/Trailer.mp4",
					Genres =new List<Genre>(){ genres[0], genres[3] }
                },
                new Movie
                {
                    Title = "Yüzüklerin Efendisi ",
                    Description = "The Lord of the Rings\" (Yüzüklerin Efendisi), J.R.R. Tolkien'in aynı adlı kitabından uyarlanan epik bir fantastik film serisidir." +
                    "\r\n\t Film, Orta Dünya adı verilen hayali bir evrende geçer ve Güç Yüzüğü'nün yok edilmesi için verilen büyük mücadeleyi konu alır.",
                    ImageUrl ="lord_of_the_rings.jpg",
					TrailerUrl="/Content/videos/efendisi.mp4",
					Genres =new List<Genre>(){ genres[0], genres[3] }

                },
                new Movie
                {
                    Title = "Titanic",
                    Description = "Titanic\", 1997 yılında James Cameron tarafından yönetilen bir romantik dram filmidir. Film, 1912 yılında ilk seferinde batacak olan RMS" +
                    " \r\n\t Titanic adlı lüks yolcu gemisinin hikayesini anlatır. Hikaye, gemideki genç bir çiftin, Jack Dawson ve Rose DeWitt Bukater'ın (Leonardo DiCaprio" +
                    "\r\n\t ve Kate Winslet tarafından canlandırılır) aşkını ve trajik sonlarını konu alır. Jack ve Rose'un karşılaşmaları ve aşkları, Titanic'in okyanusta \r\n\t " +
                    "batışıyla dramatik bir şekilde kesişir. Film, görsel efektleri, duygusal derinliği ve büyük bütçesiyle büyük beğeni topladı ve birçok ödül kazandı",
                    ImageUrl ="Titanic.jpg",
					TrailerUrl="/Content/videos/Titanic.mp4",
					Genres =new List<Genre>(){ genres[0], genres[2] }

                },
                new Movie
                {
                    Title = "Gayribeyefendi Savaş Dairesi",
					Description = "Guy Ritchie'nin rejisör koltuğuna kurulduğu son filmi \"The Ministry of Ungentlemanly Warfare\", yönetmenin tarzını kısmen yansıtan ve" +
                    " bolca aksiyon vadeden tempolu bir sinema filmi olarak geçtiğimiz Nisan ayında, başta ABD olmak üzere yurt dışında gösterime girdi. 60 milyon dolarlık bütçesine" +
                    " rağmen dünya çapında 27 milyon dolar gibi bir gişe hasılatı elde eden yapım, ülkemizdeki vizyonu es geçerek, Temmuz 2024 itibariyle Amazon Prime Video platformu üzerinden" +
                    " internet seyircisi ile buluştu. Adından da anlaşılacağı üzere, pek de centilmen olmayan bir savaş biriminin hikayesini ele alan film tipik bir Guy Ritchie mottosu" +
                    " olan \"adam biçe biçe ilerleme ve ne olursa olsun görevi tamamlama\" temasını layıkıyla yerine getiriyor.",
                    ImageUrl = "Dairesi.jpg",
					TrailerUrl="/Content/videos/Dairesi.mp4",
					Genres =new List<Genre>(){ genres[0], genres[3] }
                },
                new Movie
                {
                    Title = "Deadpool ve Wolverine",
                    Description = "Deadpool ve Wolverine, büyük bir tehlikeye karşı Wolverine'i ikna ederek onunla birlikte savaşan Deadpool'un hikayesini konu ediyor. Wade Wilson’ın bir" +
                    " paralı asker olarak geçirdiği günler ve Deadpool kimliği artık geride kalmıştır. O şimdi sivil hayatta varlık göstermek için çabalar. Wade, yeni hayatına alışmaya çalışırken," +
                    " büyük bir tehlike ile karşı karşıya kalınca harekete geçmek zorunda kalır. Ancak bu tehlike ile tek başına baş etmesi zordur. Bu yüzden Wade en az kendisi kadar isteksiz olan" +
                    " Wolverine'i yardım etmesi için ikna etmeye çalışır. ",
                    ImageUrl ="Deadpool.jpeg",
					TrailerUrl="/Content/videos/Deadpool.mp4",
					Genres =new List<Genre>(){ genres[0], genres[1], genres[4] }
                },
                new Movie
                {
                    Title = "Alien: Romulus",
                    Description = "Alien: Romulus, kendilerini evrendeki en korkunç yaşam formuyla karşı karşıya bulan bir grup gencin yaşadıklarını konu ediyor. Uzay sömürgecileri Rain, Andy, Tyler," +
                    " Kay, Bjorn ve Navarro, görünüşte tamamen terk edilmiş gibi gözüken bir uzay istasyonunda bir şeyler bulma umuduyla arama yapar. Ancak onların gerçekte neler olup bittiğine dair hiçbir" +
                    " fikri yoktur. Çok geçmeden grup, dünyanın en korkutucu yaşam formu ile karşılaşacaktır. ",
                    ImageUrl ="Alien.jpg",
					TrailerUrl="/Content/videos/Alien.mp4",
					Genres =new List<Genre>(){ genres[0], genres[3], genres[5] }
                },
				new Movie
				{
					Title = "Kaptan Pengu ve Arkadaşları 4: Buzuldaki Sır",
					Description = "Kaptan Pengu ve Arkadaşları 4: Buzuldaki Sır, herkes tarafından dışlanan Tili'nin gizemli biriyle tanıştıktan sonra yaşadığı maceraları konu ediyor. Okyanus Melekleri Ormanı’nın" +
                    " genel müdürü olan Tili, ormanı bir tatil köyü haline getirir ve böylece turistleri çekmeyi başarır. Bu sırada buzda meydana gelen bir çatlak yüzünden penguenlerin evleri zarar görünce, orman" +
                    " sakinleri arasında tartışma başlar. Durumun ne olduğunu anlamak isteyen Kaptan Penguen ve arkadaşları bu amaçla kuzeye gelir. Ancak onlar geldiğinde Tili yoktur. Tüm gruplardan dışlanan Tili," +
                    " yeryüzündeki kimsenin varlığından haberi olmadığı gizemli biriyle tanışmıştır. İkili, penguenler şehriyle, ormanı yeniden kurmak için uzun bir yolculuğa çıkarlar.  ",
					ImageUrl ="Pengu.jpg",
					TrailerUrl="/Content/videos/Pengu.mp4",
					Genres =new List<Genre>(){ genres[4] }
				},
				new Movie
				{
					Title = "Cin Çukuru",
					Description = "İki genç sevgilileriyle birlikte tatil yapmak ister ancak bunun için maddi durumları yeterli değildir. Bu durum üzerine arkadaşları Süleyman, onlara birlikte kamp yapmayı teklif eder." +
                    " Yiyecekleri ve arabayı ayarlayacak olan Süleyman’ın tek isteği, kendisine de bir kız arkadaş ayarlamalarıdır. Teklifi kabul eden gençler, yaptıkları hazırlıkların ardından yola çıkarlar. Seçilen kamp yeri," +
                    " Süleyman’ın anlattığının aksine, halk arasında Cin Çukuru olarak bilinen ve geçmişten gelen karanlık bir tılsımla lanetlenmiş bir bölgedir. Çok geçmeden gençler kendilerini tuhaf olayların içerisinde bulur. " +
                    "Geçmişten gelen bir intikam hikayesi onları beklemektedir. ",
					ImageUrl ="Cin.jpg",
					TrailerUrl="/Content/videos/Cin.mp4",
					Genres =new List<Genre>(){ genres[0], genres[5] }
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
