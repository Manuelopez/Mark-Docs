using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class BuildItem
  {
    public int Id { get; set; }
    [ForeignKey("Build")]
    public int BuildId { get; set; }
    [ForeignKey("Item")]
    public int ItemId { get; set; }
  }
}