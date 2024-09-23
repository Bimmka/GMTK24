using Code.Common.Extensions;
using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.ClickHandle.Systems
{
    public class HandleClickSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _selections;
        private readonly IGroup<InputEntity> _clicks;

        public HandleClickSystem(InputContext input, GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;

            _clicks = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Click,
                InputMatcher.WorldMousePosition,
                InputMatcher.ClickableLayerMask));

            _selections = game.GetGroup(GameMatcher.AllOf(GameMatcher.Selection));
        }

        public void Execute()
        {
            foreach (InputEntity click in _clicks)
            {
                GameEntity result = _physicsService.Raycast(click.WorldMousePosition, Vector2.zero, click.ClickableLayerMask);

                foreach (GameEntity selection in _selections)
                {
                    if (result == null)
                    {
                        click.With(x => x.isEmptyClicked = true);
                    }
                    else if (selection.isHasSelections && result.isConveyorBelt)
                    {
                        click
                            .AddClickedEntityId(result.Id)
                            .With(x => x.isConveyorBeltClicked = true);
                    }
                    else if (selection.isHasSelections)
                    {
                        click.With(x => x.isEmptyClicked = true);
                    }
                    else if (result is { isRabbit: true, hasId: true, isSelectable: true })
                    {
                        click
                            .AddClickedEntityId(result.Id)
                            .With(x => x.isRabbitClicked = true);
                    }
                    else if (result is { isFox: true, hasId: true, isAlive: true })
                    {
                        click
                            .AddClickedEntityId(result.Id)
                            .With(x => x.isFoxClicked = true);
                    }
                }
            }
        }
    }
}