using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class BuildItem{
    public int Id { get; set; }
    public int BuildId { get; set; }
    public int ItemId { get; set; }
    public Build Build { get; set; } = default!;
    public Item Item { get; set; } = default!;
    
  }
}