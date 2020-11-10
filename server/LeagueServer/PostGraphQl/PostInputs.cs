using LeagueServer.Data;

namespace LeagueServer.PostGraphQl
{
  public record AddPostInput(
    int UserId,
    string Champion,
    LaneRole Role,
    BuildInput[] Builds,
    RuneInput Rune
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