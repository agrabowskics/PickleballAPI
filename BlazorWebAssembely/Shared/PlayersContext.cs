using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BlazorWebAssembely.Shared
{
    public class PlayersContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;

        public PlayersContext(DbContextOptions<PlayersContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(player => {
                player.Property(player => player.Gender).HasConversion(
                    from => from.ToString(), to => to.ToString()[0]
                );

                player.Property(player => player.Birthday).HasConversion(
                    from => from.ToString(), to => DateOnly.FromDateTime(DateTime.Parse(to))
                );
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
