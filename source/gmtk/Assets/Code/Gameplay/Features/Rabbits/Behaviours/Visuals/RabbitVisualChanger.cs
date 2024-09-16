using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Behaviours.Visuals
{
    public class RabbitVisualChanger : MonoBehaviour
    {
        public ParticleSystem LoveParticle;
        public ParticleSystem RabiesParticle;
        public ParticleSystem SickParticle;

        public void SetSick()
        {
            SickParticle.gameObject.SetActive(true);
            SickParticle.Play();
        }
        
        public void SetRabies()
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