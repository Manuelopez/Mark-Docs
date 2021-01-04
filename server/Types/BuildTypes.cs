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
  public class BuildTypes : ObjectType<Build>
  {
    protected override void Configure(IObjectTypeDescriptor<Build> descriptor)
    {
      descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<BuildByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        
      descriptor
        .Field(b => b.BuildItems)
        .ResolveWith<BuildResolvers>(r => r.GetItemsAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()
        .Name("items");
      
    }

    private class BuildResolvers
    {
      public async Task<IEnumerable<Item>> GetItemsAsync(
        Build build,
        [ScopedService] LeagueDbContext dbContext,
        ItemByIdDataLoader itemById,
        CancellationToken cancellationToken)
      {
        int[] itemIds = await dbContext.BuildItems
          .Where(bi => bi.BuildId == build.Id)
          .Select(t => t.ItemId)
          .ToArrayAsync();
        
        return await itemById.LoadAsync(itemIds, cancellationToken);
      }

    }
  }
}
