using System.Collections.Generic;
using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Resolvers;
using HotChocolate.Types.Relay;

using System.Threading.Tasks;
using System.Threading;
using server.DataLoader;
using server.Data;
using Microsoft.EntityFrameworkCore;

namespace server.Users
{

  [ExtendObjectType(Name = "Query")]
  public class UserQueries
  {

    [UseLeagueDbContext]
    public Task<List<User>> GetUsers([ScopedService] LeagueDbContext context) => 
      context.Users.ToListAsync();
    
    public Task<User> GetUser(
      int id,
      UserByIdDataLoader dataLoader,
      CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
  }
  
}