using System.Collections.Generic;
using server.Common;
using server.Data;

namespace server.Users
{
  public class UserPayloadBase : Payload
  {
    protected UserPayloadBase(User user)
    {
      User = user;
    }
    protected UserPayloadBase(IReadOnlyList<UserError> errors)
      : base(errors)
    {
    }

    public User? User { get; }
  }
}