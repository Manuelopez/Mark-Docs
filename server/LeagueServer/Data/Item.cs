using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class Item
  {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
  }
}