using Entitas;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Windows.Windows.Game
{
    public class RabbitAmountDisplayTemp : MonoBehaviour
    {
        public TextMeshProUGUI AmountText;

        private GameContext _game;
        private IGroup<GameEntity> _stalls;

        [Inject]
        private void Construct(GameContext game)
        {
            _game = game;
        }

        private void Start()
        {
            _stalls = _game.GetGroup(GameMatcher.StallIndex);
        }

        private void Update()
        {
            AmountText.text = "";
            foreach (GameEntity stall in _stalls)
            {
                AmountText.text += $"Stall {stall.StallIndex} - Amount {stall.RabbitsAmount} /";
            }
        }
    }
}