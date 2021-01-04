using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Item{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<BuildItem> BuildItems { get; set; } = default!;
    
  }
}