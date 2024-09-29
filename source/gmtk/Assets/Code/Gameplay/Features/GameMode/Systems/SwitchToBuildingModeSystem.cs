using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.GameMode
{
    public class SwitchToBuildingModeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _modeHandlers;
        private readonly IGroup<InputEntity> _inputs;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public SwitchToBuildingModeSystem(GameContext game, InputContext input)
        {
            _modeHandlers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ModeHandler,
                    GameMatcher.GameplayMode)
                .NoneOf(GameMatcher.ModeSwitched));

            _inputs = input.GetGroup(InputMatcher.ModeSwitch);
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity modeHandler in _modeHandlers.GetEntities(_buffer))
                {
                    modeHandler.isGameplayMode = false;
                    modeHandler.isBuildingMode = true;
                    modeHandler.isModeSwitched = true;
                }
            }
        }
    }
}