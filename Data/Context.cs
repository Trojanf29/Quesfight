using Microsoft.EntityFrameworkCore;
using QuesFight.Data.QuestionData;

namespace QuesFight.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Message> Messages { get; set; } = null!;

        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionGenre> Genres { get; set; } = null!;
        public DbSet<QuesCollection> QuesCollections { get; set; } = null!;
        public DbSet<LearnRecord> LearnRecords { get; set; } = null!;
        public DbSet<MatchRecord> MatchRecords { get; set; } = null!;



        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Collection_Question>().HasKey(cq => new { cq.QuestionId, cq.CollectionId });
            modelBuilder.Entity<Collection_Question>()
                .HasOne(cq => cq.Question)
                .WithMany(q => q.Collection_Questions)
                .HasForeignKey(cq => cq.QuestionId);
            modelBuilder.Entity<Collection_Question>()
                .HasOne(cq => cq.QuesCollection)
                .WithMany(c => c.Collection_Questions)
                .HasForeignKey(cq => cq.CollectionId);
        }
    }
}