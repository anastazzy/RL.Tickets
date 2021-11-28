using Microsoft.EntityFrameworkCore;
using RL.Tickets.Domain;

namespace RL.Tickets.DataAccess
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options): base (options)
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.TicketsAsInitiator)
                .WithOne(x => x.Initiator)
                .HasForeignKey(x => x.InitiatorId);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Project);

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Executor)
                .WithMany(x => x.TicketsAsExecutor)
                .HasForeignKey(x => x.ExecutorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, FirstName = "Даниил", Patronymic = "Петрович", SecondName = "Рылеев"},
                    new User { Id = 2, FirstName = "Максим", Patronymic = "Павлович", SecondName = "Кравцов"},
                    new User { Id = 3, FirstName = "Денис", Patronymic = "Аркадьевич", SecondName = "Возников"},
                    new User { Id = 4, FirstName = "Алексей", Patronymic = "Денисович", SecondName = "Петров"},
                });
            modelBuilder.Entity<Project>().HasData(
                new Project[]
                {
                    new Project {Id = 1, Name = "SSK-36"},
                    new Project {Id = 2, Name = "SOO-120"},
                    new Project {Id = 3, Name = "K-02"},
                });
        }

    }
}
