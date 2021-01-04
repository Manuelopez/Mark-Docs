using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class User{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;

    public ICollection<Post> Posts { get; set; } = default!;

    public ICollection<Comment> Comments { get; set; } = default!;

  }
}