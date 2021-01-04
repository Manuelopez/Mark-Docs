using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Resolvers;

using server.Data;
using server.DataLoader;

namespace server.Types
{
  public class RuneType : ObjectType<Rune>
  {
    protected override void Configure(IObjectTypeDescriptor<Rune> descriptor)
    {
      descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<RuneByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        
      descriptor
        .Field(r => r.PrimaryPage)
        .ResolveWith<RuneResolvers>(r => r.GetPrimaryPageAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()     
        .Name("PrimaryPage");

       descriptor
        .Field(r => r.SecondaryPage)
        .ResolveWith<RuneResolvers>(r => r.GetSecondaryPageAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()     
        .Name("SecondaryPage");
    }

    private class RuneResolvers
    {
      public async Task<IEnumerable<Page>> GetPrimaryPageAsync(
        Rune rune,
        [ScopedService] LeagueDbContext dbContext,
        PageByIdDataLoader pageById,
        CancellationToken cancellationToken)
      {
        int[] pageIds = await dbContext.Pages
          .Where(r => r.Id == rune.PrimaryPageId)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await pageById.LoadAsync(pageIds, cancellationToken);
      }

      public async Task<IEnumerable<Page>> GetSecondaryPageAsync(
        Rune rune,
        [ScopedService] LeagueDbContext dbContext,
        PageByIdDataLoader pageById,
        CancellationToken cancellationToken)
      {
        int[] pageIds = await dbContext.Pages
          .Where(r => r.Id == rune.SecondaryPageId)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await pageById.LoadAsync(pageIds, cancellationToken);
      }
    } 
  }
}
