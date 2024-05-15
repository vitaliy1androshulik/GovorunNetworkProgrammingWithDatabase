using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Helpers;

namespace Server
{
    public class AnswerDbContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=AnswersDB;
                                        Integrated Security=True;
                                        Connect Timeout=5;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedAnswers();
        }
    }
}
