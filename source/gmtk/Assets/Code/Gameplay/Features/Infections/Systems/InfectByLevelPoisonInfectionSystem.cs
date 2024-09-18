using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Infections.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Infections.Systems
{
    public class InfectByLevelPoisonInfectionSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IStatusApplier _statusApplier;
        private readonly IInfectionFactory _infectionFactory;
        private readonly IGroup<GameEntity> _infections;
        private readonly IGroup<GameEntity> _contagious;

        public InfectByLevelPoisonInfectionSystem(
            GameContext game,
            IStaticDataService staticDataService,
            IStatusApplier statusApplier,
            IInfectionFactory infectionFactory)
        {
            _staticDataService = staticDataService;
            _statusApplier = statusApplier;
            _infectionFactory = infectionFactory;
            _infections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisoningInfection,
                    GameMatcher.LevelInfection,
                    GameMatcher.InfectionUp,
                    GameMatcher.ValidInfection));

            _contagious = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CanBeInfectedByPoison,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity infection in _infections)
            {
                if (_contagious.count > 0)
                {
                    GameEntity contagious = _contagious.AsEnumerable().First();

                    var setup = _staticDataService.GetInfectionConfig(InfectionType.PoisonInfection, contagious.isRabbit ? InfectionTargetType.Rabbit : InfectionTargetType.Fox).InfectionSetup;

                    _statusApplier.ApplyStatus(new StatusSetup()
                    {
                        StatusType = StatusTypeId.Poison,
                        Duration = setup.TimeBeforeDeath,
                    }, contagious.Id);

                    _infectionFactory.CreateInfection(setup, contagious.Id);
                }
            }
        }
    }
}