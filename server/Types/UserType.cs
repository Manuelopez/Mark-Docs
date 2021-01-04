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
  public class UserType : ObjectType<User>
  {
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
      descriptor
        .ImplementsNode()
        .IdField(t => t.Id)
        .ResolveNode((ctx, id) => ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        
      descriptor
        .Field(u => u.Posts)
        .ResolveWith<UserResolvers>(r => r.GetPostsAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()
        .Name("posts");

      descriptor
        .Field(u => u.Comments)
        .ResolveWith<UserResolvers>(r => r.GetCommentsAsync(default!, default!, default!, default))
        .UseDbContext<LeagueDbContext>()
        .Name("comments");
      
    }

    private class UserResolvers
    {
      public async Task<IEnumerable<Post>> GetPostsAsync(
        User user,
        [ScopedService] LeagueDbContext dbContext,
        PostByIdDataLoader postById,
        CancellationToken cancellationToken)
      {
        int[] postIds = await dbContext.Posts
          .Where(p => p.UserId == user.Id)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await postById.LoadAsync(postIds, cancellationToken);
      }

      public async Task<IEnumerable<Comment>> GetCommentsAsync(
        User user,
        [ScopedService] LeagueDbContext dbContext,
        CommentByIdDataLoader commentById,
        CancellationToken cancellationToken)
      {
        int[] commentsIds = await dbContext.Comments
          .Where(c => c.UserId == user.Id)
          .Select(r => r.Id)
          .ToArrayAsync();
        
        return await commentById.LoadAsync(commentsIds, cancellationToken);
      }


    }
  }
}
