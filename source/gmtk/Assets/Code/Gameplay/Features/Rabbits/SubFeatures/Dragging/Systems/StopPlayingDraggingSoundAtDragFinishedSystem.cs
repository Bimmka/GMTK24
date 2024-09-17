using Code.Gameplay.Sounds.Config;
using Code.Gameplay.Sounds.Service;
using Entitas;

namespace Code.Gameplay.Features.Rabbits.SubFeatures.Dragging.Systems
{
    public class StopPlayingDraggingSoundAtDragFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rabbits;

        public StopPlayingDraggingSoundAtDragFinishedSystem(GameContext game)
        {
            _rabbits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rabbit,
                    GameMatcher.DragFinished,
                    GameMatcher.HuntSoundElement));
        }

        public void Execute()
        {
            foreach (GameEntity rabbit in _rabbits)
            {
                rabbit.HuntSoundElement?.Reset();
                rabbit.RemoveHuntSoundElement();
            }
        }
    }
}