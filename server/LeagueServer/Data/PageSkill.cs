using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class PageSkill
  {
    public int Id { get; set; }
    [ForeignKey("Page")]
    public int PageId { get; set; }
    [ForeignKey("Skill")]
    public int SkillId { get; set; }
  }
}