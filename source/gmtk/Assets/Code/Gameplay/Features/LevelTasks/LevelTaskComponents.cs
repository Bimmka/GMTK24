using System.Collections.Generic;
using Code.Gameplay.Features.LevelTasks.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Entitas;

namespace Code.Gameplay.Features.LevelTasks
{
    [Game] public class LevelTask : IComponent {}
    [Game] public class LevelTaskForTime : IComponent {}
    [Game] public class LevelTaskHoldDurationTask : IComponent {}
    [Game] public class MinConcreteRabbitsAmountTaskType : IComponent {}
    [Game] public class LevelTaskTypeComponent : IComponent { public LevelTaskType Value; }
    [Game] public class ConditionsCompleted : IComponent {}
    [Game] public class ConditionsUncompleted : IComponent {}
    [Game] public class WaitingHoldTime : IComponent {}
    [Game] public class Completed : IComponent {}
    [Game] public class Uncompleted : IComponent {}
    [Game] public class Failed : IComponent {}
    [Game] public class MinConcreteRabbitAmountTask : IComponent {} //
    [Game] public class MinSumRabbitAmountTask : IComponent {} //
    [Game] public class HoldAmountForPeriodOfTimeTask : IComponent {} //
    [Game] public class RemoveAllRabbitsForTimeTask : IComponent {}
    [Game] public class MinRabbitsAmountForTimeTask : IComponent {}
    
    
    
    [Game] public class LevelTaskHoldDuration : IComponent { public float Value; }
    [Game] public class LevelTaskHoldDurationTime : IComponent { public float Value; }
    
    [Game] public class LevelTaskDuration : IComponent { public float Value; }
    [Game] public class LevelTaskDurationTimeLeft : IComponent { public float Value; }
    [Game] public class LevelTaskTimeExpired : IComponent { }

    [Game] public class MinRabbitAmount : IComponent { public int Value; }
    [Game] public class MaxRabbitAmount : IComponent { public int Value; }
    [Game] public class CurrentAmount : IComponent { public int Value; }
    [Game] public class RabbitColorsForTask : IComponent { public List<RabbitColorType> Value; }
}