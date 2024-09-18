using UnityEngine;

namespace Code.Gameplay.Features.Foxes.Behaviours.Visuals
{
    public class FoxVisualChanger : SickVisualChanger
    {
        public ParticleSystem RabiesParticle;
        public ParticleSystem SickParticle;
        
        public override void SetSick()
        {
            SickParticle.gameObject.SetActive(true);
            SickParticle.Play();
        }
        
        public override void SetRabies()
        {
            RabiesParticle.gameObject.SetActive(true);
            RabiesParticle.Play();
        }
    }
}