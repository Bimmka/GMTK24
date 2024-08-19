using Code.Gameplay.Features.Holes.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Holes.Factory
{
    public interface IHoleFactory
    {
        GameEntity Create(HoleSetup setup, Vector3 at, int stallIndex);
    }
}