using System.Threading.Tasks;
using HotChocolate;
using System.Collections.Generic;
using System;
using LeagueServer.Data;
using LeagueServer.PostGraphQl;

namespace LeagueServer.GraphQl
{
  public partial class Mutation
  {
    public async Task<AddPostPayload> AddPostAsync(AddPostInput input, [Service] ApplicationDbContext context)
    {
      Post post = new Post
      {
        UserId = (int) input.UserId,
        Champion = input.Champion,
        Role = input.Role
      };

      context.Posts.Add(post);
      await context.SaveChangesAsync();

      // Builds
      foreach (var inputBuild in input.Builds)
      {
        Build build = new Build {
          PostId = post.Id,
          Type = inputBuild.Type
        };

        context.Builds.Add(build);
        await context.SaveChangesAsync();

        // Items
        foreach (var inputItems in inputBuild.Items)
        {
          Item item = new Item {
            Name = inputItems
          };

          context.Items.Add(item);
          await context.SaveChangesAsync();

          BuildItem buildItem = new BuildItem
          {
            BuildId = build.Id,
            ItemId = item.Id
          };

          context.BuildItems.Add(buildItem);
          await context.SaveChangesAsync();

        }
      }

      // Runes
      Page primary = new Page();
      Page secondary = new Page();
      context.Pages.Add(primary);
      context.Pages.Add(secondary);
      await context.SaveChangesAsync();

      Rune rune = new Rune
      {
        PostId = post.Id,
        Primary = primary.Id,
        Secondary = secondary.Id
      };

      context.Runes.Add(rune);

      // primary skill
      foreach (var inputSkill in input.Rune.Primary)
      {
        Skill skill = new Skill{
          Name = inputSkill
        };
        context.Skills.Add(skill);
        await context.SaveChangesAsync();
        
        PageSkill pageSkill = new PageSkill{
          PageId = primary.Id,
          SkillId = skill.Id
        };     

        context.PageSkills.Add(pageSkill);
        await context.SaveChangesAsync();

      }
      
      // secondary
      foreach (var inputSkill in input.Rune.Secondary)
      {
        Skill skill = new Skill{
          Name = inputSkill
        };
        context.Skills.Add(skill);
        await context.SaveChangesAsync();
        
        PageSkill pageSkill = new PageSkill{
          PageId = secondary.Id,
          SkillId = skill.Id
        };   

        context.PageSkills.Add(pageSkill);
        await context.SaveChangesAsync();       
      }
      // await context.SaveChangesAsync();
      return new AddPostPayload(post);
    }
  }
}