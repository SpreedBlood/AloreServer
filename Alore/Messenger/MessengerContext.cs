namespace Alore.Messenger
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using MySql.Data.MySqlClient;

    internal class MessengerContext : DbContext
    {
        private DbSet<MessengerFriend> MessengerFriends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnectionStringBuilder
            {
                UserID = "root",
                Port = 3307,
                Database = "alore",
                Password = "",
                Server = "localhost"
            }.ToString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MessengerFriend>(player =>
            {
                player.ToTable("messenger_friends");
                player.Property(p => p.FriendId).HasColumnName("id");

            });
            base.OnModelCreating(builder);
        }
    }
}
