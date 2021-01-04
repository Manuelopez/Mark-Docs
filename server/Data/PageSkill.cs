using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class PageSkill{
    public int Id { get; set; }
    public int PageId { get; set; }
    public int SkillId { get; set; }
    public Page Page { get; set; } = default!;
    public Skill Skill { get; set; } = default!;
    
  }
}