using LeagueServer.Data;

namespace LeagueServer.UserGraphQl
{
    public class AddUserPayload
    {
      public User User { get; }
      public AddUserPayload(User user){
        User = user;
      }
    }
}