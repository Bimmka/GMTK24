using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Utils.Holes;
using Code.Gameplay.Utils.Stalls;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Code.Editor.CustomEditors
{
    [CustomEditor(typeof(LevelConfig))]
    public class LevelConfigEditor : OdinEditor
    {
        private LevelConfig config;

        protected override void OnEnable()
        {
            base.OnEnable();
            config = (LevelConfig)target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Collect Stall Data"))
            {
                CollectStallsSpawnData();
                EditorUtility.SetDirty(config);
                AssetDatabase.SaveAssets();
            }
            
            if (GUILayout.Button("Collect Holes Data"))
            {
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
                    SpawnPosition = spawnMarkers[i].transform.position
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
                    StallIndex = spawnMarkers[i].StallIndex,
                    At = spawnMarkers[i].transform.position,
                    Setup = spawnMarkers[i].Setup
                };
            }
        }
    }
}