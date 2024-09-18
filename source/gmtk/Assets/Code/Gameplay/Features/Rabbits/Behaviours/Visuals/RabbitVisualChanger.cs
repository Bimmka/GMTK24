using Code.Gameplay.Features.Foxes.Behaviours.Visuals;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Visuals
{
    public class RabbitVisualChanger : SickVisualChanger
    {
        public ParticleSystem LoveParticle;
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

        public void SetLove()
        {
            LoveParticle.gameObject.SetActive(true);
            LoveParticle.Play();
        }

        public void RemoveLove()
        {
            LoveParticle.Stop();
            LoveParticle.gameObject.SetActive(false);
        }
    }
}