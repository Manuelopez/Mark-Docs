using System.Threading.Tasks;
using System.Threading;
using HotChocolate;
using System.Collections.Generic;
using System;
using System.Linq;
using HotChocolate.Types;
using server.Data;
using server.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace server.Posts
{
  [ExtendObjectType(Name = "Mutation")]
  public class PostMutations
  {
    [UseLeagueDbContext]
    public async Task<AddPostPayload> AddPostAsync(
      AddPostInput input,
      [ScopedService] LeagueDbContext context)
    {
      Post post = new Post{
        UserId = input.UserId,
        Champion = input.Champion,
        Role = input.Role
      };

      foreach (var inputBuild in input.Build)
      {
        Build build = new Build
        {
          Post = post,
          Type = inputBuild.Type
        };
        foreach (var inputItem in inputBuild.Items)
        {
          Item item = new Item
          {
            Name = inputItem
          };
          BuildItem buildItem = new BuildItem
          {
            Build = build,
            Item = item
          };

          context.BuildItems.Add(buildItem);
          // context.Items.Add(item);
            
        }
        post.Builds.Add(build);
      }

      foreach (var inputRune in input.Rune)
      {
        Page primary = new Page();
        Page secondary = new Page();
        Rune rune = new Rune
        {
          Post = post,
          PrimaryPage = primary,
          SecondaryPage = secondary
        };

        foreach (var inputSkill in inputRune.Primary)
        {
          Skill skill = new Skill
          {
            Name = inputSkill
          };

          PageSkill pageSkill = new PageSkill
          {
            Page = primary,
            Skill = skill
          };
          context.PageSkills.Add(pageSkill);
        }

        foreach (var inputSkill in inputRune.Secondary)
        {
          Skill skill = new Skill
          {
            Name = inputSkill
          };

          PageSkill pageSkill = new PageSkill
          {
            Page = secondary,
            Skill = skill
          };
          context.PageSkills.Add(pageSkill);
        }        
        context.Runes.Add(rune);
      }

      context.Add(post);      
      
      await context.SaveChangesAsync();

      return new AddPostPayload(post);
    }
  }
}