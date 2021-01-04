using System.Collections.Generic;
using server.Common;
using server.Data;

namespace server.Users
{
  public class AddUserPayload : UserPayloadBase
  {
    public AddUserPayload(User user)
      : base(user)
    {
    }

    public AddUserPayload(IReadOnlyList<UserError> erros)
      : base(erros)
    {
    }
  }
}