using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Factory
{
    public interface IFoxFactory
    {
        GameEntity Create(Vector3 at, int stallIndex);
    }
}