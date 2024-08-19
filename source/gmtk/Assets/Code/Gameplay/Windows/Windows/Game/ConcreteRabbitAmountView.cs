using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.UI;
using Code.Gameplay.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class ConcreteRabbitAmountView : MonoBehaviour
    {
        public Image RabbitIcon;
        public TextMeshProUGUI AmountText;
        
        private IStaticDataService _staticDataService;
        public RabbitColorType Color { get; private set; }

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void Initialize(RabbitColorType colorType, int currentAmount)
        {
            Color = colorType;
            SpriteByRabbitColor spriteByColor = _staticDataService.GetRabbitSpriteByColor(colorType);
            RabbitIcon.sprite = spriteByColor.Sprite;
            DisplayAmount(currentAmount);
        }

        public void DisplayAmount(int currentAmount)
        {
            AmountText.text = currentAmount.ToString();
        }
    }
}