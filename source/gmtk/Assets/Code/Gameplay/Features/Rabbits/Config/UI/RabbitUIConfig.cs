using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Config.UI
{
    [CreateAssetMenu(menuName = "StaticData/Rabbits Config/Create UI Rabbit Config")]
    public class RabbitUIConfig : ScriptableObject
    {
        public SpriteByRabbitColor[] SpritesByColor;
    }
}