using System.Linq;
using HotChocolate;
using LeagueServer.Data;
using LeagueServer.UserGraphQl;

namespace LeagueServer.GraphQl
{
  public class Query
  {
    public IQueryable<User> GetUsers([Service] ApplicationDbContext context) => context.Users;
    public IQueryable<User> GetUserId(int id, [Service] ApplicationDbContext context) => context.Users.Where(c => c.Id == id);
    
  }
}