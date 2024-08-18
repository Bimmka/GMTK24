using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Input.Config;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    private readonly IStaticDataService _staticDataService;

    public InitializeInputSystem(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }
    
    public void Initialize()
    {
      InputConfig config = _staticDataService.GetInputConfig();
      
      CreateInputEntity.Empty()
        .AddLastMouseDownTime(0f)
        .AddClickInterval(config.IntervalForClick)
        .AddLongTapInterval(config.IntervalForLongTap)
        .With(x => x.isInput = true);
    }
  }
}