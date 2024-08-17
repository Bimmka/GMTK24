using Code.Gameplay.Features.Level.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Stall.Factory
{
    public interface IStallsFactory
    {
        GameEntity CreateStall(StallsSpawnData spawnData, Transform parent);
    }
}