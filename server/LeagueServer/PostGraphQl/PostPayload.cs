using LeagueServer.Data;

namespace LeagueServer.PostGraphQl
{
    public class AddPostPayload
    {
      public Post Post { get; }
      public AddPostPayload(Post post){
        Post = post;
      }
    }
}