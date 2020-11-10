using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class Build
  {
    public int Id { get; set; }
    [ForeignKey("Post")]
    public int PostId { get; set; }
    public BuildType Type { get; set; }
  }
}