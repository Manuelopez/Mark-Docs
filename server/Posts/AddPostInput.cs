using server.Data;

namespace server.Posts
{


  public record AddPostInput(
    int UserId,
    string Champion,
    LaneRole Role,
    BuildInput[] Build,
    RuneInput[] Rune
  );

  public record BuildInput(
    BuildType Type,
    string[] Items
  );

  public record RuneInput(
    string[] Primary,
    string[] Secondary
  );

}