using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class RotationTransformRegistrar : EntityComponentRegistrar
    {
        public Transform Transform;
        
        public override void RegisterComponents()
        {
            Entity.AddRotationTransform(Transform);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRotationTransform)
                Entity.RemoveRotationTransform();
        }
    }
}