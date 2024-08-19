using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Utils.Holes;
using Code.Gameplay.Utils.Stalls;
using UnityEditor;
using UnityEngine;

namespace Code.Editor.CustomEditors
{
    [CustomEditor(typeof(LevelConfig))]
    public class LevelConfigEditor : UnityEditor.Editor
    {
        private LevelConfig config;

        void OnEnable()
        {
            config = (LevelConfig)target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Collect Data"))
            {
                CollectStallsSpawnData();
                CollectHolesSpawnData();
                EditorUtility.SetDirty(config);
                AssetDatabase.SaveAssets();
            }
        }

        private void CollectStallsSpawnData()
        {
            StallSpawnMarker[] spawnMarkers = FindObjectsOfType<StallSpawnMarker>();

            config.StallsSpawnData = null;
            config.StallsSpawnData = new StallsSpawnData[spawnMarkers.Length];
            
            for (int i = 0; i < spawnMarkers.Length; i++)
            {
                config.StallsSpawnData[i] = new StallsSpawnData()
                {
                    Bounds = spawnMarkers[i].Bounds,
                    Index = spawnMarkers[i].Index,
                    SpawnPosition = spawnMarkers[i].transform.position,
                    View = spawnMarkers[i].View
                };
            }
        }
        
        private void CollectHolesSpawnData()
        {
            HoleSpawnMarker[] spawnMarkers = FindObjectsOfType<HoleSpawnMarker>();

            config.PresetupHoleData = null;
            config.PresetupHoleData = new PresetupHoleData[spawnMarkers.Length];
            
            for (int i = 0; i < spawnMarkers.Length; i++)
            {
                config.PresetupHoleData[i] = new PresetupHoleData()
                {
                    StallIndex = spawnMarkers[i].Index,
                    At = spawnMarkers[i].transform.position,
                    Setup = spawnMarkers[i].Setup
                };
            }
        }
    }
}