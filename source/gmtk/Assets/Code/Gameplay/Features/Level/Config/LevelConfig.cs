using UnityEngine;

namespace Code.Gameplay.Features.Level.Config
{
    [CreateAssetMenu(menuName = "StaticData/Create Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public string Id;

        public StallsSpawnData[] StallsSpawnData;
    }
}