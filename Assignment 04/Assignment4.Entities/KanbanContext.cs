using Microsoft.EntityFrameworkCore;
using System;
using Assignment4.Core;
namespace Assignment4.Entities
{
    public class KanbanContext : DbContext
    {
        public DbSet<Tag> Tags {get; set;}

        public DbSet<Task> Tasks {get; set;}


        public DbSet<User> Users {get; set;}

        private static string connectionString = @"
            Server=localhost,1433;
            Database=kanban;
            User Id=SA;
            Password=<MiavMiav!23>"
            ;

        //private static bool _created = false;
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(connectionString);
            }
        }
            //=> options.UseSqlServer(connectionString);
            //=> options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Task>()
                .Property(t => t.State)
                .HasConversion(
                s => s.ToString(),//parse enum to string, from model to db
                s => (State)Enum.Parse(typeof(State), s));//parse string to enum from db to model
        }

    }
}
