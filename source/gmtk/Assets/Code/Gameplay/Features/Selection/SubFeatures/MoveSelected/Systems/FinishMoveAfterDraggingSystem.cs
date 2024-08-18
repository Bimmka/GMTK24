﻿using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Selection.SubFeatures.MoveSelected.Systems
{
    public class FinishMoveAfterDraggingSystem : IExecuteSystem
    {
        private const float SquaredDistanceError = 0.2f;
        private readonly IGroup<GameEntity> _selected;

        public FinishMoveAfterDraggingSystem(GameContext game)
        {
            _selected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.AfterDragPosition));
        }

        public void Execute()
        {
            foreach (GameEntity selected in _selected)
            {
                if (Vector3.SqrMagnitude(selected.WorldPosition - selected.AfterDragPosition) <= SquaredDistanceError)
                {
                    selected.isMovingToAfterDragPosition = false;
                    selected.isDragFinished = true;
                }
            }
        }
    }
}