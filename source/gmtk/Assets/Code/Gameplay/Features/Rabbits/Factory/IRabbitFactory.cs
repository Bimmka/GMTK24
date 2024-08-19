using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Factory
{
    public interface IRabbitFactory
    {
        GameEntity Create(RabbitColorType type, Vector3 at, int stallIndex);
    }
}