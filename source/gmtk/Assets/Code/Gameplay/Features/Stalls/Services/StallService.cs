using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using UnityEngine;

namespace Code.Gameplay.Features.Stalls.Services
{
    public class StallService : IStallService
    {
        private readonly IRandomService _randomService;
        private readonly Dictionary<int, GameEntity> _stallsByIndex = new Dictionary<int, GameEntity>();

        public StallService(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public void Registry(int index, GameEntity stall)
        {
            if (_stallsByIndex.TryGetValue(index, out GameEntity addedStall))
            {
                Debug.LogWarning($"Tried registry stall with index {index}. This index is already used");
                return;
            }
            
            _stallsByIndex.Add(index, stall);
        }

        public void Unregistry(int index)
        {
            _stallsByIndex.Remove(index);
        }

        public void Clear()
        {
            _stallsByIndex.Clear();
        }

        public Vector3 GetRandomPositionInStall(int index)
        {
            if (_stallsByIndex.TryGetValue(index, out GameEntity stall) == false)
                return Vector3.positiveInfinity;

            if (stall.hasWorldPosition == false)
                return Vector3.positiveInfinity;
            
            if (stall.hasStallBounds == false)
                return Vector3.positiveInfinity;

            Vector2 maxShift = stall.StallBounds / 2;

            float randomX = Random.Range(stall.WorldPosition.x - maxShift.x, stall.WorldPosition.x + maxShift.x);
            float randomY = Random.Range(stall.WorldPosition.y - maxShift.y, stall.WorldPosition.y + maxShift.y);

            return new Vector3(randomX, randomY, stall.WorldPosition.z);

        }
    }
}