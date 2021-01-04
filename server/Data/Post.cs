using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Post{
    public int Id { get; set; }
    public string Champion { get; set; } = default!;
    public LaneRole Role { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<Comment> Comments { get; set; } = default!;
    public ICollection<Build> Builds { get; set; } = default!;
    public ICollection<Rune> Runes { get; set; } = default!;



  }
}