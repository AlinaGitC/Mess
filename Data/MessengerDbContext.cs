using AppServerTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AppServerTest.Data
{
    public class MessengerDbContext : DbContext
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options) { }

        public DbSet<Userr> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatType> ChatTypes { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<ChatRole> ChatRoles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.ID_UserNavigation)
                .WithMany()
                .HasForeignKey(m => m.ID_User);

            modelBuilder.Entity<Message>()
                .HasMany(m => m.Files)
                .WithOne()
                .HasForeignKey(f => f.ID_Messages);
        }
    }
}
