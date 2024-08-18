using Code.Gameplay.Features.Infections.Configs;

namespace Code.Gameplay.Features.Infections.Factory
{
    public interface IInfectionFactory
    {
        GameEntity CreateInfection(InfectionSetup setup, int carrierId);
        GameEntity CreateLevelInfection(InfectionType infectionType, float interval);
    }
}