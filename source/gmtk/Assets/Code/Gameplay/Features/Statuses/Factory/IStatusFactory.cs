namespace Code.Gameplay.Features.Statuses.Factory
{
  public interface IStatusFactory
  {
    GameEntity CreateStatus(StatusSetup setup, int targetId);
  }
}