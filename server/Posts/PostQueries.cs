using System.Collections.Generic;
using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

using System.Threading.Tasks;
using System.Threading;
using server.DataLoader;
using server.Data;
using Microsoft.EntityFrameworkCore;


namespace server.Posts
{
  [ExtendObjectType(Name = "Query")]
  public class PostQueries
  {
    [UseLeagueDbContext]
    public Task<List<Post>> GetPosts([ScopedService] LeagueDbContext context) => 
      context.Posts.ToListAsync();

    public Task<Post> GetPost(
      int id,
      PostByIdDataLoader dataLoader,
      CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
  }
}