using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Rune{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int PrimaryPageId { get; set; }
    public int SecondaryPageId { get; set; }
    public Post Post { get; set; } = default!;
    public Page PrimaryPage { get; set; } = default!;
    public Page SecondaryPage { get; set; } = default!;
    
  }
}