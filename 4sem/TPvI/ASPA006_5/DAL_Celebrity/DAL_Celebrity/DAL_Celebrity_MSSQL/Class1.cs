using DAL_Celebrity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace DAL_Celebrity_MSSQL
{
    public interface IRepository : DAL_Celebrity.IRepository<Celebrity, Lifeevent> { }

    public class Celebrity // Знаменитость
    {
        public Celebrity()
        {
            this.FullName = string.Empty;
            this.Nationality = string.Empty;
        }

        public int Id { get; set; } // Id Знаменитости
        public string FullName { get; set; } // полное имя Знаменитости
        public string Nationality { get; set; } // гражданство Знаменитости (2 символа ISO)
        public string? ReqPhotoPath { get; set; } // request path Фотографии

        public virtual bool Update(Celebrity celebrity)
        {
            if (celebrity == null) return false;
            try
            {
                this.FullName = celebrity.FullName;
                this.Nationality = celebrity.Nationality;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }

    public class Lifeevent // Событие в жизни знаменитости
    {
        public Lifeevent()
        {
            this.Description = string.Empty;
        }
        public int Id { get; set; } // Id События
        public int CelebrityId { get; set; } // Id Знаменитости
        public DateTime? Date { get; set; } // дата События (nullable)
        public string Description { get; set; } // описание События
        public string? ReqPhotoPath { get; set; } // request path Фотографии

        public virtual bool Update(Lifeevent lifeevent)
        {
            if (lifeevent == null) return false;
            try
            {
                this.Description = lifeevent.Description;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
    public class Repository : IRepository
    {
        private readonly Context context;

        public Repository()
        {
            this.context = new Context();
        }

        public Repository(string connectionString)
        {
            this.context = new Context(connectionString);
        }

        public static IRepository Create()
        {
            return new Repository();
        }

        public static IRepository Create(string connectionString)
        {
            return new Repository(connectionString);
        }

        // Методы для работы с Celebrity
        public List<Celebrity> GetAllCelebrities()
        {
            return this.context.Celebrities.ToList<Celebrity>();
        }

        public Celebrity? GetCelebrityById(int id)
        {
            return this.context.Celebrities.FirstOrDefault(x => x.Id == id);
        }

        public bool AddCelebrity(Celebrity celebrity)
        {
            try
            {
                this.context.Celebrities.Add(celebrity);
                this.context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DelCelebrity(int id)
        {
            try {
                Celebrity? el = this.context.Celebrities.Find(id);
                if (el == null) return false;
                this.context.Celebrities.Remove(el);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdCelebrity(int id, Celebrity celebrity)
        {
            try {
                Celebrity? el = this.context.Celebrities.Find(id);
                if (el == null) return false;
                el.FullName = celebrity.FullName;
                el.Nationality = celebrity.Nationality;
                el.ReqPhotoPath = celebrity.ReqPhotoPath;
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
            
            
        }

        public List<Lifeevent> GetAllLifeevents()
        {
            return this.context.Lifeevents.ToList<Lifeevent>();
        }

        public Lifeevent? GetLifeeventById(int id)
        {
            return this.context.Lifeevents.FirstOrDefault(x => x.Id == id);
        }

        public bool AddLifeevent(Lifeevent lifeEvent)
        {
            try
            {
                //lifeEvent.Id = this.context.Lifeevents.OrderBy(x => x.Id).LastOrDefault().Id + 1;
                if (lifeEvent == null) return false;
                this.context.Lifeevents.Add(lifeEvent);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DelLifeevent(int id)
        {
            try
            {
                Lifeevent? el = this.context.Lifeevents.Find(id);
                if (el == null) return false;
                this.context.Lifeevents.Remove(el);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdLifeevent(int id, Lifeevent lifeEvent)
        {
            try
            {
                Lifeevent? el = this.context.Lifeevents.Find(id);
                if (el == null) return false;
                el.CelebrityId = lifeEvent.CelebrityId;
                el.Date = lifeEvent.Date;
                el.Description = lifeEvent.Description;
                el.ReqPhotoPath = lifeEvent.ReqPhotoPath;
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Комбинированные методы
        public List<Lifeevent> GetLifeeventsByCelebrityId(int celebrityId)
        {
            if (celebrityId <= 0)
                throw new ArgumentException("Неверный id", nameof(celebrityId));
            return this.context.Lifeevents
                .Where(x => x.CelebrityId == celebrityId)
                .ToList();
        }

        public Celebrity? GetCelebrityByLifeeventId(int lifeEventId)
        {
            if (lifeEventId <= 0)
                throw new ArgumentException("Неверный id", nameof(lifeEventId));

            var lifeEvent = this.context.Lifeevents
                .FirstOrDefault(le => le.Id == lifeEventId);

            if (lifeEvent == null || lifeEvent.CelebrityId <= 0)
                return null;

            return this.context.Celebrities
                .FirstOrDefault(c => c.Id == lifeEvent.CelebrityId);
        }

        public int GetCelebrityIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым", nameof(name));

            var celebrity = this.context.Celebrities
                .FirstOrDefault(c => c.FullName.Contains(name));
            return celebrity?.Id ?? -1;
        }

        public void Dispose()
        {
            // реализация освобождения ресурсов
        }
    }
    public class Context : DbContext
    {
        public string? ConnectionString { get; private set; } = null;
        private string _ConnectionString;

        public Context(string connString) : base()
        {
            this._ConnectionString = connString;
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }

        public Context() : base()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }

        public DbSet<Celebrity> Celebrities { get; set; }
        public DbSet<Lifeevent> Lifeevents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this._ConnectionString is null)
                this._ConnectionString = @"Data Source=...";

            optionsBuilder.UseSqlServer(this._ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Celebrity>().ToTable("Celebrities")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Celebrity>()
                .Property(p => p.Id).IsRequired();

            modelBuilder.Entity<Celebrity>()
                .Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Celebrity>()
                .Property(p => p.Nationality)
                .IsRequired()
                .HasMaxLength(2);

            modelBuilder.Entity<Celebrity>()
                .Property(p => p.ReqPhotoPath)
                .HasMaxLength(200);

            modelBuilder.Entity<Lifeevent>().ToTable("Lifeevents")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Lifeevent>()
                .Property(p => p.Id).IsRequired();

            modelBuilder.Entity<Lifeevent>()
                .Property(p => p.CelebrityId).IsRequired();

            modelBuilder.Entity<Lifeevent>()
                .Property(p => p.Date);

            modelBuilder.Entity<Lifeevent>()
                .Property(p => p.Description)
                .HasMaxLength(256);

            modelBuilder.Entity<Lifeevent>()
                .Property(p => p.ReqPhotoPath)
                .HasMaxLength(256);

            base.OnModelCreating(modelBuilder);
        }
    }
    public class Init
    {
        private static string connString = @"Server=user;Database=Life Events of  Celebrities;Trusted_Connection=True;User Id=sa;Password=sa;TrustServerCertificate=True;";
        private static string puri(string filename) => $"{filename}";
        public Init() { }

        public Init(string conn)
        {
            connString = conn;
        }

        public void Execute(bool delete = true, bool create = true)
        {
            using var context = new Context(connString);

            if (delete)
                context.Database.EnsureDeleted();

            if (create)
                context.Database.EnsureCreated();

            {
                //1
                Celebrity c = new Celebrity() { FullName = "Noam Chomsky", Nationality = "US", ReqPhotoPath = puri("Chomsky.jpg") };
                Lifeevent l1 = new Lifeevent() { CelebrityId = 1, Date = new DateTime(1928, 12, 7), Description = "Дата рождения", ReqPhotoPath = null };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 1,
                    Date = new DateTime(1955, 1, 1),
                    Description = "Издание книги \"Логическая структура лингвистической теории\"",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            { //2
                Celebrity c = new Celebrity() { FullName = "Tim Berners-Lee", Nationality = "UK", ReqPhotoPath = puri("Berners-Lee.jpg") };
                Lifeevent l1 = new Lifeevent() { CelebrityId = 2, Date = new DateTime(1955, 6, 8), Description = "Дата рождения", ReqPhotoPath = null };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 2,
                    Date = new DateTime(1989, 3, 12),
                    Description = "В CERN предложил \"Гипертекстовый проект\"",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }
            {
                // 3. Edgar Codd (реляционные БД)
                Celebrity c = new Celebrity() { FullName = "Edgar Codd", Nationality = "US", ReqPhotoPath = puri("Codd.jpg") };
                Lifeevent l1 = new Lifeevent() { CelebrityId = 3, Date = new DateTime(1923, 8, 23), Description = "Дата рождения", ReqPhotoPath = null };
                Lifeevent l2 = new Lifeevent() { CelebrityId = 3, Date = new DateTime(2003, 4, 18), Description = "Дата смерти", ReqPhotoPath = null };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            {
                // 4. Donald Knuth (искусство программирования)
                Celebrity c = new Celebrity() { FullName = "Donald Knuth", Nationality = "US", ReqPhotoPath = puri("Knuth.jpg") };
                Lifeevent l1 = new Lifeevent() { CelebrityId = 4, Date = new DateTime(1938, 1, 10), Description = "Дата рождения", ReqPhotoPath = null };
                Lifeevent l2 = new Lifeevent() { CelebrityId = 4, Date = new DateTime(1974, 1, 1), Description = "Премия Тьюринга", ReqPhotoPath = null };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            {
                // 5. Linus Torvalds (создатель Linux)
                Celebrity c = new Celebrity() { FullName = "Linus Torvalds", Nationality = "FI", ReqPhotoPath = puri("Torvalds.jpg") };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 5,
                    Date = new DateTime(1969, 12, 28),
                    Description = "Дата рождения. Финляндия.",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 5,
                    Date = new DateTime(1991, 9, 17),
                    Description = "Выложил исходный код Linux (версии 0.01)",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            {
                // 6. John von Neumann (архитектор компьютеров)
                Celebrity c = new Celebrity() { FullName = "John von Neumann", Nationality = "US", ReqPhotoPath = puri("Neumann.jpg") };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 6,
                    Date = new DateTime(1903, 12, 28),
                    Description = "Дата рождения. Венгрия",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 6,
                    Date = new DateTime(1957, 2, 8),
                    Description = "Дата смерти",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            { //7
              // Edsger Dijkstra (алгоритмы)
                Celebrity c = new Celebrity() { FullName = "Edsger Dijkstra", Nationality = "NL", ReqPhotoPath = puri("Dijkstra.jpg") };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 7,
                    Date = new DateTime(1930, 12, 28),
                    Description = "Дата рождения",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 7,
                    Date = new DateTime(2002, 8, 6),
                    Description = "Дата смерти",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            { //8
              // Ada Lovelace (первый программист)
                Celebrity c = new Celebrity() { FullName = "Ada Lovelace", Nationality = "UK", ReqPhotoPath = puri("Lovelace.jpg") };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 8,
                    Date = new DateTime(1815, 12, 10),  // Исправлена дата рождения
                    Description = "Дата рождения",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 8,
                    Date = new DateTime(1852, 11, 27),  // Исправлена дата смерти
                    Description = "Дата смерти",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }
            {
                // 9. Charles Babbage (отец вычислительной техники)
                Celebrity c = new Celebrity()
                {
                    FullName = "Charles Babbage",
                    Nationality = "UK",
                    ReqPhotoPath = puri("Babbage.jpg")
                };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 9,
                    Date = new DateTime(1791, 12, 26),
                    Description = "Дата рождения",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 9,
                    Date = new DateTime(1871, 10, 18),
                    Description = "Дата смерти",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            {
                // 10. Andrew Tanenbaum (создатель MINIX)
                Celebrity c = new Celebrity()
                {
                    FullName = "Andrew Tanenbaum",
                    Nationality = "NL",
                    ReqPhotoPath = puri("Tanenbaum.jpg")
                };
                Lifeevent l1 = new Lifeevent()
                {
                    CelebrityId = 10,
                    Date = new DateTime(1944, 3, 16),
                    Description = "Дата рождения",
                    ReqPhotoPath = null
                };
                Lifeevent l2 = new Lifeevent()
                {
                    CelebrityId = 10,
                    Date = new DateTime(1987, 1, 1),
                    Description = "Создал MINIX - бесплатную Unix-подобную систему",
                    ReqPhotoPath = null
                };
                context.Celebrities.Add(c);
                context.Lifeevents.Add(l1);
                context.Lifeevents.Add(l2);
            }

            context.SaveChanges();


        } 
    }
}
