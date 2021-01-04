using System.Collections.Generic;
using server.Common;
using server.Data;

namespace server.Posts
{
  public class AddPostPayload : PostPayloadBase
  {
    public AddPostPayload(Post post)
      : base(post)
    {
    }

    public AddPostPayload(IReadOnlyList<UserError> erros)
      : base(erros)
    {
    }
  }
}