using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.UI;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows.Windows.HomeScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class RabbitTaskGoalPartViewInGame : MonoBehaviour
    {
        public Image RabbitIcon;
        public GameObject RabbitIconParent;
        public GameObject CommonRabbitIconParent;
        public GameObject KillCommonRabbitIconParent;

        public TextMeshProUGUI LeftAmountText;
        public TextMeshProUGUI RightAmountText;
        public TextMeshProUGUI Description;
        
        private IStaticDataService _staticDataService;
        public RabbitColorType Color { get; private set; }

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void InitializeAsConcreteWithRangeAmount(RabbitColorType colorType, int minValue, int maxValue)
        {
            Color = colorType;
            SpriteByRabbitColor spriteByColor = _staticDataService.GetRabbitSpriteByColor(colorType);
            RabbitIcon.sprite = spriteByColor.Sprite;
            RabbitIconParent.SetActive(true);
            LeftAmountText.text = $"{minValue} < ";
            RightAmountText.text = $" < {maxValue}";
            
            LeftAmountText.gameObject.SetActive(true);
            RightAmountText.gameObject.SetActive(true);
        }

        public void InitializeAsConcreteWithMinAmount(RabbitColorType colorType, int minValue)
        {
            Color = colorType;
            SpriteByRabbitColor spriteByColor = _staticDataService.GetRabbitSpriteByColor(colorType);
            RabbitIcon.sprite = spriteByColor.Sprite;
            RabbitIconParent.SetActive(true);
            RightAmountText.text = $" > {minValue}";
            RightAmountText.gameObject.SetActive(true);
        }

        public void InitializeAsCommonWithRangeAmount(int minValue, int maxValue)
        {
            CommonRabbitIconParent.SetActive(true);
            LeftAmountText.text = $"{minValue} < ";
            RightAmountText.text = $" < {maxValue}";
            
            LeftAmountText.gameObject.SetActive(true);
            RightAmountText.gameObject.SetActive(true);
        }

        public void InitializeAsCommonWithMinAmount(int minValue)
        {
            CommonRabbitIconParent.SetActive(true);
            RightAmountText.text = $" > {minValue}";
            RightAmountText.gameObject.SetActive(true);
        }

        public void InitializeAsKillAll()
        {
            CommonRabbitIconParent.SetActive(true);
            KillCommonRabbitIconParent.SetActive(true);
        }

        public void DisplayDescription(string levelId)
        {
            Description.gameObject.SetActive(true);
            Description.text = _staticDataService.GetLevelConfig(levelId).TaskConfig.TaskType.Localize();
        }
    }
}