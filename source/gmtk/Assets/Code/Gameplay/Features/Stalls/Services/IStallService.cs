using UnityEngine;

namespace Code.Gameplay.Features.Stalls.Services
{
    public interface IStallService
    {
        void Registry(int index, GameEntity stall);
        void Unregistry(int index);
        void Clear();
        Vector3 GetRandomPositionInStall(int index);
    }
}