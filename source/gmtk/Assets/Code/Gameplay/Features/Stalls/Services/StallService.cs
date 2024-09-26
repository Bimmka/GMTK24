using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using UnityEngine;

namespace Code.Gameplay.Features.Stalls.Services
{
    public class StallService : IStallService
    {
        private const float BoarderShift = 0.5f;
        
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

            Vector2 maxShift = (stall.StallBounds / 2) - Vector2.one * BoarderShift;

            float randomX = _randomService.Range(stall.WorldPosition.x - maxShift.x, stall.WorldPosition.x + maxShift.x);
            float randomY = _randomService.Range(stall.WorldPosition.y - maxShift.y, stall.WorldPosition.y + maxShift.y);

            return new Vector3(randomX, randomY, stall.WorldPosition.z);
        }

        public int GetStallIndex(Vector2 worldPosition)
        {
            foreach ((int index, GameEntity stall) in _stallsByIndex)
            {
                if (stall.hasWorldPosition == false)
                    continue;
                
                if (stall.hasStallBounds == false)
                    continue;

                Vector2 halfStallBounds = stall.StallBounds / 2;
                if (IsInBounds(worldPosition, stall, halfStallBounds))
                    return index;
            }

            return -1;
        }

        public Vector3 GetRandomPositionInStall(int index, Vector3 at, float maxGap)
        {
            if (_stallsByIndex.TryGetValue(index, out GameEntity stall) == false)
                return Vector3.positiveInfinity;

            if (stall.hasWorldPosition == false)
                return Vector3.positiveInfinity;
            
            if (stall.hasStallBounds == false)
                return Vector3.positiveInfinity;

            Vector2 maxShift = new Vector2(maxGap, maxGap);
            Vector2 halfBounds = stall.StallBounds / 2;

            float randomX = _randomService.Range(stall.WorldPosition.x - maxShift.x, stall.WorldPosition.x + maxShift.x);
            float randomY = _randomService.Range(stall.WorldPosition.y - maxShift.y, stall.WorldPosition.y + maxShift.y);

            randomX = Mathf.Min(randomX, stall.WorldPosition.x + halfBounds.x - BoarderShift);
            randomX = Mathf.Max(randomX, stall.WorldPosition.x - halfBounds.x - BoarderShift);
            
            randomY = Mathf.Min(randomY, stall.WorldPosition.y + halfBounds.y - BoarderShift);
            randomY = Mathf.Max(randomY, stall.WorldPosition.y - halfBounds.y - BoarderShift);

            return new Vector3(randomX, randomY, stall.WorldPosition.z);
        }

        public int GetNearestStallIndexFromPosition(Vector3 position)
        {
            float minDistance = float.MaxValue;
            int currentIndex = 0;
            foreach ((int index, GameEntity stall) in _stallsByIndex)
            {
                Vector2 halfStallBounds = stall.StallBounds / 2;
                Vector2 leftUpCorner = new Vector2(stall.WorldPosition.x - halfStallBounds.x, stall.WorldPosition.y + halfStallBounds.y);
                Vector2 leftDownCorner = new Vector2(stall.WorldPosition.x - halfStallBounds.x, stall.WorldPosition.y - halfStallBounds.y);
                Vector2 rightUpCorner = new Vector2(stall.WorldPosition.x + halfStallBounds.x, stall.WorldPosition.y + halfStallBounds.y);
                Vector2 rightDownCorner = new Vector2(stall.WorldPosition.x + halfStallBounds.x, stall.WorldPosition.y - halfStallBounds.y);

                float calculatedDistance = Vector2.Distance(position, leftUpCorner);

                if (calculatedDistance < minDistance)
                {
                    minDistance = calculatedDistance;
                    currentIndex = index;
                }
                
                calculatedDistance = Vector2.Distance(position, leftDownCorner);

                if (calculatedDistance < minDistance)
                {
                    minDistance = calculatedDistance;
                    currentIndex = index;
                }
                
                calculatedDistance = Vector2.Distance(position, rightUpCorner);

                if (calculatedDistance < minDistance)
                {
                    minDistance = calculatedDistance;
                    currentIndex = index;
                }
                
                calculatedDistance = Vector2.Distance(position, rightDownCorner);

                if (calculatedDistance < minDistance)
                {
                    minDistance = calculatedDistance;
                    currentIndex = index;
                }
            }

            return currentIndex;
        }

        private bool IsInBounds(Vector2 worldPosition, GameEntity stall, Vector2 halfStallBounds)
        {
            return worldPosition.x >= (stall.WorldPosition.x - halfStallBounds.x)
                   && worldPosition.x <= (stall.WorldPosition.x + halfStallBounds.x)
                   && worldPosition.y <= stall.WorldPosition.y + halfStallBounds.y
                   && worldPosition.y >= stall.WorldPosition.y - halfStallBounds.y;
        }
    }
}