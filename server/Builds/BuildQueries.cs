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

namespace server.Builds
{
  [ExtendObjectType(Name = "Query")]
  public class BuildQueries
  {    
    [UseLeagueDbContext]
    public Task<List<Build>> GetBuilds([ScopedService] LeagueDbContext context) => 
      context.Builds.ToListAsync();
    
    public Task<Build> GetBuild(
      int id,
      BuildByIdDataLoader dataLoader,
      CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
  }
}