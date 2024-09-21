using System;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Sirenix.OdinInspector;

namespace Code.Gameplay.Features.LevelTasks.Config
{
    [Serializable]
    public class TaskGoalByRabbitColor
    {
        public RabbitColorType ColorType;
        public int MinAmount;
        
#if UNITY_EDITOR
        [HideIf(nameof(_isMaxAmountHidden))]
#endif
        public int MaxAmount;

#if UNITY_EDITOR
        private bool _isMaxAmountHidden;

        
        public void SetMaxAmountHiddenValue(bool isHidden)
        {
            _isMaxAmountHidden = isHidden;
        }
#endif
    }
}