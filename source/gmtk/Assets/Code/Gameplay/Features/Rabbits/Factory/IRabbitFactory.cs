using Code.Gameplay.Features.Rabbits.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Factory
{
    public interface IRabbitFactory
    {
        GameEntity Create(RabbitType type, Vector3 at, int stallIndex);
    }
}