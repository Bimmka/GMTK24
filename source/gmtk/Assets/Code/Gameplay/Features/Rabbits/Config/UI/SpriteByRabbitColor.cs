using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using UnityEngine;

namespace Code.Gameplay.Features.Rabbits.Config.UI
{
    [Serializable]
    public class SpriteByRabbitColor
    {
        public RabbitColorType Color;
        public Sprite Sprite;
    }
}