using System.Collections.Generic;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks
{
    [Game] public class LevelTask : IComponent {}
    
    
    //task type
    [Game] public class LevelTaskTypeComponent : IComponent { public LevelTaskType Value; }
    [Game] public class LevelTaskConcreteRabbitAmount : IComponent { }
    [Game] public class LevelTaskCommonRabbitAmount : IComponent { }
    [Game] public class LevelTaskRemoveAllRabbits : IComponent { }
    
    
    //time
    [Game] public class LevelTaskDurationLimitations : IComponent { public List<LevelTaskDurationLimitationType> Value; }
    [Game] public class LevelTaskWithTimeForFail : IComponent {}
    [Game] public class LevelTaskWithHoldDuration : IComponent {}

    [Game] public class TimeConditionCompleted : IComponent {}
    [Game] public class TimeConditionUncompleted : IComponent {}
    
    [Game] public class TimeDurationConditionCompleted : IComponent {}
    [Game] public class TimeDurationConditionFailed : IComponent {}
    
    [Game] public class TimeHoldConditionCompleted : IComponent {}
    [Game] public class TimeHoldConditionUncompleted : IComponent {}
    

    //amount conditions
    [Game] public class LevelTaskAmountConditionTypeComponent : IComponent { public LevelTaskAmountConditionType Value; }
    [Game] public class LevelTaskMinAmountType : IComponent { }
    [Game] public class LevelTaskRangeAmountType : IComponent { }
    
    [Game] public class LevelTaskMinRabbitAmount : IComponent { public int Value; }
    [Game] public class LevelTaskMaxRabbitAmount : IComponent { public int Value; }
    [Game] public class LevelTaskCurrentCommonAmount : IComponent { public int Value; }
    [Game] public class LevelTaskGoalForConcreteRabbits : IComponent { public List<TaskGoalByRabbitColor> Value; }
    [Game] public class LevelTaskCurrentConcreteRabbitsAmount : IComponent { public Dictionary<RabbitColorType, int> Value; }
    
    [Game] public class AmountConditionCompleted : IComponent {}
    [Game] public class AmountConditionUncompleted : IComponent {}
    
    
   
    
    [Game] public class Completed : IComponent {}
    [Game] public class Uncompleted : IComponent {}
    [Game] public class Failed : IComponent {}
    [Game] public class NoChances : IComponent {}
    
    
    
    //hold time
    [Game] public class LevelTaskTargetHoldDuration : IComponent { public float Value; }
    [Game] public class LevelTaskTargetHoldDurationTime : IComponent { public float Value; }
    [Game] public class ConditionsCompleted : IComponent {}
    [Game] public class ConditionsUncompleted : IComponent {}
    [Game] public class WaitingHoldTime : IComponent {}
    
    //task with time
    
    [Game] public class LevelTaskDurationBeforeExpired : IComponent { public float Value; }
    [Game] public class LevelTaskDurationBeforeExpiredTimeLeft : IComponent { public float Value; }
    [Game] public class LevelTaskTimeExpired : IComponent { }
}