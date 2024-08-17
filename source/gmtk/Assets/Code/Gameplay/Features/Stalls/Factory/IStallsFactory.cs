using Code.Gameplay.Features.Level.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Stalls.Factory
{
    public interface IStallsFactory
    {
        GameEntity CreateStall(StallsSpawnData spawnData, Transform parent);
    }
}