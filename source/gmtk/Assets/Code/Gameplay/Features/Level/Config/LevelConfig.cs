using Code.Gameplay.Features.LevelTasks.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Config
{
    [CreateAssetMenu(menuName = "StaticData/Create Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public string Id;

        public GameObject LevelPrefab;

        public LevelTaskConfig TaskConfig;

        public StallsSpawnData[] StallsSpawnData;
        public PresetupRabbitData[] PresetupRabbits;
        public InfectionForLevelData[] Infections;
        public PresetupFoxesData[] PresetupFoxesData;
        public PresetupHoleData[] PresetupHoleData;

        [TextArea(0,10)]
        public string Hint;
    }
}