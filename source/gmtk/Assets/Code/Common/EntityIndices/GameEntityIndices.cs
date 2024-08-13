using Zenject;

namespace Code.Common.EntityIndices
{
  public class GameEntityIndices : IInitializable
  {
    private readonly GameContext _game;


    public GameEntityIndices(GameContext game)
    {
      _game = game;
    }

    public void Initialize()
    {

    }

    public static class ContextIndicesExtensions
    {

    }
  }
}