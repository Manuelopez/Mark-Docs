using Microsoft.EntityFrameworkCore;

namespace server.Data
{
  public class LeagueDbContext : DbContext
  {
    public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<Comment> Comments { get; set; } = default!;
    public DbSet<Build> Builds { get; set; } = default!;
    public DbSet<BuildItem> BuildItems { get; set; } = default!;
    public DbSet<Item> Items { get; set; } = default!;
    public DbSet<Rune> Runes { get; set; } = default!;
    public DbSet<Page> Pages { get; set; } = default!;
    public DbSet<PageSkill> PageSkills { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;
  }
}