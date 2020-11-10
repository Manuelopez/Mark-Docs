using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class Comment
  {
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Post")]
    public int PostId { get; set; }
    [ForeignKey("User")]
    public int? ReplyTo { get; set; }
    public string body { get; set; } = default!;
  }
}