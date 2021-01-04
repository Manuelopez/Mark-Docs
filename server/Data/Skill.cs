using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Skill{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<PageSkill> PageSkills { get; set; } = default!;
    
  }
}