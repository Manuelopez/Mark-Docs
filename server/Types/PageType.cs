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
  public class PageType : ObjectType<Page>
  {
    protected override void Configure(IObjectTypeDescriptor<Page> descriptor)
    {
      descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<PageByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        
      descriptor
        .Field(p => p.PageSkills)
        .ResolveWith<PageResolvers>(r => r.GetSkillsAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()
        .Name("skills");
      
    }

    private class PageResolvers
    {
      public async Task<IEnumerable<Skill>> GetSkillsAsync(
        Page page,
        [ScopedService] LeagueDbContext dbContext,
        SkillByIdDataLoader skillById,
        CancellationToken cancellationToken)
      {
        int[] skillIds = await dbContext.PageSkills
          .Where(p => p.PageId == page.Id)
          .Select(r => r.SkillId)
          .ToArrayAsync();
        
        return await skillById.LoadAsync(skillIds, cancellationToken);
      }
    }
  }
}
