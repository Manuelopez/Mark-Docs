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
  public class PageByIdDataLoader : BatchDataLoader<int, Page>
  {
    private readonly IDbContextFactory<LeagueDbContext> _dbContextFactory;

    public PageByIdDataLoader(
      IBatchScheduler batchScheduler,
      IDbContextFactory<LeagueDbContext> dbContextFactory)
      : base(batchScheduler)
    {
      _dbContextFactory = dbContextFactory ??
        throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Page>> LoadBatchAsync(
      IReadOnlyList<int> keys,
      CancellationToken cancellationToken)
    {
      await using LeagueDbContext dbContext = 
        _dbContextFactory.CreateDbContext();

      return await dbContext.Pages
        .Where(p => keys.Contains(p.Id))
        .ToDictionaryAsync(t => t.Id, cancellationToken);
    }

  }
}