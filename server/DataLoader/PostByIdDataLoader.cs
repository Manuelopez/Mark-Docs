using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using server.Data;
using GreenDonut;
using HotChocolate.DataLoader;

namespace server.DataLoader
{
  public class PostByIdDataLoader : BatchDataLoader<int, Post>
  {
    private readonly IDbContextFactory<LeagueDbContext> _dbContextFactory;
    
    public PostByIdDataLoader(
      IBatchScheduler batchScheduler,
      IDbContextFactory<LeagueDbContext> dbContextFactory)
      : base(batchScheduler)
    {
      _dbContextFactory = dbContextFactory ??
        throw new ArgumentNullException(nameof(dbContextFactory));
    }
    
    protected override async Task<IReadOnlyDictionary<int, Post>> LoadBatchAsync(
      IReadOnlyList<int> keys,
      CancellationToken cancellationToken)
    {
      await using LeagueDbContext dbContext = 
        _dbContextFactory.CreateDbContext();

      return await dbContext.Posts
        .Where(p => keys.Contains(p.Id))
        .ToDictionaryAsync(t => t.Id, cancellationToken);

    }
  }
}