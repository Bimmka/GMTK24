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

        public HandleClickSystem(InputContext input, IPhysicsService physicsService)
        {
            _physicsService = physicsService;

            _clicks = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Click,
                InputMatcher.WorldMousePosition,
                InputMatcher.ClickableLayerMask));
        }

        public void Execute()
        {
            foreach (InputEntity click in _clicks)
            {
                GameEntity result = _physicsService.Raycast(click.WorldMousePosition, Vector2.zero, click.ClickableLayerMask);

                if (result is { isRabbit: true, hasId: true, isSelectable: true })
                {
                    click
                        .AddClickedEntityId(result.Id)
                        .With(x => x.isRabbitClicked = true);
                }
                else if (result is { isFox: true, hasId: true })
                {
                    click
                        .AddClickedEntityId(result.Id)
                        .With(x => x.isFoxClicked = true);
                }
                else
                {
                    click.With(x => x.isEmptyClicked = true);
                }
            }
        }
    }
}