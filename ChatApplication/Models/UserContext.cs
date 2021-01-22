using Microsoft.EntityFrameworkCore;



namespace ChatApplication.Models
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblChatDetails> TblChatDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ChatApp;Trusted_Connection=True;User Id=root;Password=root;Integrated Security=false;");
                //Configuration.GetConnectionString("SQLConnection"))
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<TblChatDetails>(entity =>
            {
                entity.HasKey(e => e.ChatId);

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.FromUserId);

                entity.Property(e => e.ChatText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ToUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                ;

            });
        }
    }
}
