using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.GameMode
{
    public class CleanupModeSwitchedMarkSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _modeHandlers;
        private readonly List<GameEntity> _buffer = new(1);

        public CleanupModeSwitchedMarkSystem(GameContext game)
        {
            _modeHandlers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ModeHandler,
                    GameMatcher.ModeSwitched));
        }

        public void Cleanup()
        {
            foreach (GameEntity modeHandler in _modeHandlers.GetEntities(_buffer))
            {
                modeHandler.isModeSwitched = false;
            }
        }
    }
}