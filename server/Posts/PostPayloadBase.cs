using System.Collections.Generic;
using server.Common;
using server.Data;

namespace server.Posts
{
  public class PostPayloadBase : Payload
  {
    protected PostPayloadBase(Post post)
    {
      Post = post;
    }
    protected PostPayloadBase(IReadOnlyList<UserError> errors)
      : base(errors)
    {
    }

    public Post? Post { get; }
  }
}