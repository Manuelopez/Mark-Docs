using Microsoft.EntityFrameworkCore;

namespace LeagueServer.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    {

    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //         => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leaguedb;Username=postgres;Password=hola1234");

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Post> Posts { get; set; }= default!;
    public DbSet<Comment> Comments { get; set; }= default!;
    public DbSet<Build> Builds { get; set; }= default!;
    public DbSet<BuildItem> BuildItems { get; set; }= default!;
    public DbSet<Item> Items { get; set; }= default!;
    public DbSet<Rune> Runes { get; set; }= default!;
    public DbSet<Page> Pages { get; set; }= default!;
    public DbSet<PageSkill> PageSkills { get; set; }= default!;
    public DbSet<Skill> Skills { get; set; }= default!;

  }
}