using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LeagueServer.Data
{
  public class User
  {
    public int Id { get; set; } 
    [Required]
    public string Username { get; set; }= default!;
    [Required]
    public string Password { get; set; }= default!;
    public string? Bio { get; set; }
  }
}