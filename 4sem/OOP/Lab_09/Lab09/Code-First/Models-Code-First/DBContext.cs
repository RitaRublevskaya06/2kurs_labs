using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> People { get; set; }

        public Context() : base("DBConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка отношений
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Person)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PersonId);
        }
    }
}
