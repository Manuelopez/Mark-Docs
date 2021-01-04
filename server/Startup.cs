using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using server.Data;
using server.DataLoader;
using server.Types;
using server.Users;
using server.Posts;
using server.Builds;

namespace server
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddPooledDbContextFactory<LeagueDbContext>(options => options
          .UseNpgsql(Configuration
            .GetConnectionString("LeagueDbContext")));
      services
        .AddGraphQLServer()
        .AddQueryType(d => d.Name("Query"))
          .AddType<UserQueries>()
          .AddType<PostQueries>()
          .AddType<BuildQueries>()
        .AddMutationType(d => d.Name("Mutation"))
          .AddType<UserMutations>()
          .AddType<PostMutations>()
        .AddType<UserType>()
        .AddType<PostType>()
        .AddType<BuildTypes>()
        .AddType<RuneType>()
        .AddType<PageType>()
        .EnableRelaySupport()
        .AddDataLoader<UserByIdDataLoader>()
        .AddDataLoader<PostByIdDataLoader>()
        .AddDataLoader<CommentByIdDataLoader>()
        .AddDataLoader<BuildByIdDataLoader>()
        .AddDataLoader<ItemByIdDataLoader>()
        .AddDataLoader<RuneByIdDataLoader>()
        .AddDataLoader<PageByIdDataLoader>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.UseRouting();
      
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGraphQL();
      });
    }
  }
}
