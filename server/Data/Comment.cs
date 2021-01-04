using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace server.Data{
  public class Comment{
    public int Id { get; set; }
    public string Body { get; set; } = default!;
    public int UserId { get; set; }
    public int PostId { get; set; }
    public User User { get; set; } = default!;
    public Post Post { get; set; } = default!;



    
  }
}