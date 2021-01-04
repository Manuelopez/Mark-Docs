using System.Reflection;
using server.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace server
{
  public class UseLeagueDbContextAttribute : ObjectFieldDescriptorAttribute
  {
    public override void OnConfigure(
      IDescriptorContext context,
      IObjectFieldDescriptor descriptor,
      MemberInfo member)
      {
        descriptor.UseDbContext<LeagueDbContext>();
      }
  }
}