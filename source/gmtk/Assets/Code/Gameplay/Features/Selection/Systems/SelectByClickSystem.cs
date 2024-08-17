using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.Systems
{
    public class SelectByClickSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<InputEntity> _clicks;
        private readonly IGroup<GameEntity> _selections;

        public SelectByClickSystem(InputContext input, GameContext game, IPhysicsService physicsService)
        {
            _game = game;
            _physicsService = physicsService;
            _clicks = input.GetGroup(InputMatcher.AllOf(InputMatcher.Click));
            _selections = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SelectedEntities,
                    GameMatcher.SelectionLayerMask));
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
                        foreach (int entityId in selection.SelectedEntities)
                        {
                            GameEntity selectedEntity = _game.GetEntityWithId(entityId);
                            selectedEntity.isSelected = false;
                        }

                        selection.SelectedEntities.Clear();
                    }
                    else if (result.isSelectable && selection.SelectedEntities.Contains(result.Id) == false)
                    {
                        selection.SelectedEntities.Add(result.Id);
                        selection.isHasSelections = true;
                        result.isSelected = true;
                    }
                }
            }
        }
    }
}