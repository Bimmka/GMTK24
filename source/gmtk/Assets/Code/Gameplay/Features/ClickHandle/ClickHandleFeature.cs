using Code.Gameplay.Features.ClickHandle.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.ClickHandle
{
    public sealed class ClickHandleFeature : Feature
    {
        public ClickHandleFeature(ISystemFactory systems)
        {
            Add(systems.Create<HandleClickSystem>());
        }
    }
}