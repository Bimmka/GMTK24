using Code.Gameplay.Features.Level.Config;

namespace Code.Gameplay.Features.ConveyorBelt.Factory
{
    public interface IConveyorBeltFactory
    {
        GameEntity Create(ConveyorBeltData createData);
    }
}