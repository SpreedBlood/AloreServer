namespace Alore.Player
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using MySql.Data.MySqlClient;

    public class PlayerContext : DbContext
    {
        private DbSet<Player> Players { get; set; }

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
            builder.Entity<Player>(player =>
            {
                player.ToTable("players");
                player.Property(p => p.Id).HasColumnName("id");
                player.Property(p => p.Username).HasColumnName("username");
                player.Property(p => p.SsoTicket).HasColumnName("auth_ticket");
                player.Property(p => p.Figure).HasColumnName("figure");
                player.Property(p => p.Gender).HasColumnName("gender");
                player.Property(p => p.Motto).HasColumnName("motto");
                player.Property(p => p.Credits).HasColumnName("credits");
            });
            base.OnModelCreating(builder);
        }
    }
}
