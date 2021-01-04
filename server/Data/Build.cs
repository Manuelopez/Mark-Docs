using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Build{
    public int Id { get; set; }
    public BuildType Type { get; set; } = default!;
    public int PostId { get; set; }
    public Post Post { get; set; } = default!;
    public ICollection<BuildItem> BuildItems { get; set; } = default!;
  }
}