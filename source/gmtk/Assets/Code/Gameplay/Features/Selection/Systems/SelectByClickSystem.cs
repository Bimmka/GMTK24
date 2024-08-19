using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class SelectByClickSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<InputEntity> _clicks;
        private readonly IGroup<GameEntity> _selections;

        public SelectByClickSystem(InputContext input, GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _clicks = input.GetGroup(InputMatcher.AllOf(InputMatcher.Click));
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EntitiesForSelectionQueue,
                    GameMatcher.SelectionLayerMask)
                .NoneOf(GameMatcher.Dragging));
        }

        public void Execute()
        {
            foreach (InputEntity click in _clicks)
            {
                foreach (GameEntity selection in _selections)
                {
                    GameEntity result = _physicsService.Raycast(click.WorldMousePosition, Vector2.zero, selection.SelectionLayerMask);

                    if (result == null)
                    {
                        selection.isUnselectSelectedEntities = true;
                    }
                    else if (result.isSelectable)
                    {
                        selection.EntitiesForSelectionQueue.Enqueue(result.Id);
                        result.isSelected = true;
                    }
                }
            }
        }
    }
}