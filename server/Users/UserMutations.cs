using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

using server.Data;

namespace server.Users
{
  [ExtendObjectType(Name = "Mutation")]
  public class UserMutations
  {
    [UseLeagueDbContext]
    public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [ScopedService] LeagueDbContext context)
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