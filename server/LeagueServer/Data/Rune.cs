using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class Rune
  {
    public int Id { get; set; }
    [ForeignKey("Post")]
    public int PostId { get; set; }
    [ForeignKey("Page")]
    public int Primary { get; set; }
    [ForeignKey("Page")]
    public int Secondary { get; set; }
  }
}