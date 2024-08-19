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
        public TextMeshProUGUI MinAmountText;
        public TextMeshProUGUI MaxAmountText;
        
        private IStaticDataService _staticDataService;
        public RabbitColorType Color { get; private set; }

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void Initialize(RabbitColorType colorType, LevelTaskAmountConditionType amountCondition, int currentAmount, int minAmount, int maxAmount)
        {
            InitializeInternal(colorType);
            DisplayAmount(amountCondition, currentAmount, minAmount, maxAmount);
        }
        
        public void Initialize(RabbitColorType colorType, int currentAmount)
        {
            InitializeInternal(colorType);
            MinAmountText.enabled = false;
            MaxAmountText.enabled = false;
            DisplayOnlyCurrentAmount(currentAmount);
        }
        
        public void DisplayAmount(LevelTaskAmountConditionType amountCondition, int currentAmount, int minAmount, int maxAmount)
        {
            MinAmountText.text = minAmount.ToString();
            MaxAmountText.text = maxAmount.ToString();
            AmountText.text = currentAmount.ToString();
        }

        public void DisplayOnlyCurrentAmount(int currentAmount)
        {
            AmountText.text = currentAmount.ToString();
        }

        private void InitializeInternal(RabbitColorType colorType)
        {
            Color = colorType;
            SpriteByRabbitColor spriteByColor = _staticDataService.GetRabbitSpriteByColor(colorType);
            RabbitIcon.sprite = spriteByColor.Sprite;
        }
    }
}