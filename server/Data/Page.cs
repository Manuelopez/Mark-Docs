using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Page{
    public int Id { get; set; }
    public ICollection<PageSkill> PageSkills { get; set; } = default!;
  }
}