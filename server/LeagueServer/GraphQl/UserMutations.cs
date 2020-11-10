using System.Threading.Tasks;
using LeagueServer.Data;
using LeagueServer.UserGraphQl;
using HotChocolate;

namespace LeagueServer.GraphQl
{
  public partial class Mutation
  {
    public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [Service] ApplicationDbContext context)
    {
      User user = new User
      {
        Username = input.Username,
        Password = input.Password
      };

      context.Users.Add(user);
      await context.SaveChangesAsync();

      return new AddUserPayload(user);
    }
  }
}