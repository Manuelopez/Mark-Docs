using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class Post
  {
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public string Champion { get; set; } = default!;
    public LaneRole Role { get; set; }
  }

}