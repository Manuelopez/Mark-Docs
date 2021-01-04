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
  public class PostType : ObjectType<Post>
  {
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
      descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<PostByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        

      descriptor
        .Field(p => p.Builds)
        .ResolveWith<PostResolvers>(r => r.GetBuildsAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()
        .Name("builds");
      
      descriptor
        .Field(p => p.Runes)
        .ResolveWith<PostResolvers>(r => r.GetRunesAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()     
        .Name("runes");
    }

    private class PostResolvers
    {
      public async Task<IEnumerable<Build>> GetBuildsAsync(
        Post post,
        [ScopedService] LeagueDbContext dbContext,
        BuildByIdDataLoader buildById,
        CancellationToken cancellationToken)
      {
        int[] buildIds = await dbContext.Builds
          .Where(b => b.PostId == post.Id)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await buildById.LoadAsync(buildIds, cancellationToken);
      }

      public async Task<IEnumerable<Rune>> GetRunesAsync(
        Post post,
        [ScopedService] LeagueDbContext dbContext,
        RuneByIdDataLoader runeById,
        CancellationToken cancellationToken)
      {
        int[] runesIds = await dbContext.Runes
          .Where(r => r.PostId == post.Id)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await runeById.LoadAsync(runesIds, cancellationToken);
      }
    }
  }
}
