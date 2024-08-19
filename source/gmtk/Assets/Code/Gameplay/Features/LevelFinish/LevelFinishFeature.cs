using Code.Gameplay.Features.LevelFinish.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelFinish
{
    public sealed class LevelFinishFeature : Feature
    {
        public LevelFinishFeature(ISystemFactory systems)
        {
            Add(systems.Create<OpenWinWindowSystem>());
            Add(systems.Create<OpenLoseWindowSystem>());
            Add(systems.Create<MarkSignalsDestructedSystem>());
        }
    }
}