using System.Linq;
using Code.Common.EntityIndices;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses.Factory;

namespace Code.Gameplay.Features.Statuses.Applier
{
  public class StatusApplier : IStatusApplier
  {
    private readonly IStatusFactory _statusFactory;
    private readonly GameContext _game;

    public StatusApplier(IStatusFactory statusFactory, GameContext game)
    {
      _statusFactory = statusFactory;
      _game = game;
    }

    public GameEntity ApplyStatus(StatusSetup setup, int targetId)
    {
      GameEntity status = _game.TargetStatusesOfType(setup.StatusType, targetId).FirstOrDefault();

      if (status != null)
        return status;
      
      return _statusFactory.CreateStatus(setup, targetId)
        .With(x => x.isApplied = true);
    }
  }
}