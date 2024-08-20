using Code.Gameplay.Features.LevelTasks.Config;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public static class Extensions
    {
        public static string FinishIn(this float value) =>
            $"Finish in: {value:#} sec";

        public static string HoldAmount(this float value) =>
            $"Hold amount for {value:#} sec";

        public static string Localize(this LevelTaskType taskType)
        {
            switch (taskType)
            {
                case LevelTaskType.ConcreteRabbitAmount:
                    return "Breed";
                case LevelTaskType.CommonRabbitAmount:
                    return "Breed";
                case LevelTaskType.RemoveAllRabbits:
                    return "Feed the foxes";
            }
            
            return "";
        }
    }
}