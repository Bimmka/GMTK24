using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Utils.ConveyorBelts;
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
            
            if (GUILayout.Button("Collect Conveyor Belt Data"))
            {
                CollectConveyorBeltSpawnData();
                EditorUtility.SetDirty(config);
                AssetDatabase.SaveAssets();
            }
            
            if (GUILayout.Button("Restore Level"))
            {
                RestoreLevel();
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
        
        private void CollectConveyorBeltSpawnData()
        {
            ConveyorBeltSpawnMarker[] spawnMarkers = FindObjectsOfType<ConveyorBeltSpawnMarker>();

            config.ConveyorBelts = null;
            config.ConveyorBelts = new ConveyorBeltData[spawnMarkers.Length];
            
            for (int i = 0; i < spawnMarkers.Length; i++)
            {
                config.ConveyorBelts[i] = new ConveyorBeltData()
                {
                    StartPosition = spawnMarkers[i].StartPoint.position,
                    EndPosition = spawnMarkers[i].EndPoint.position,
                    StartStallIndex = spawnMarkers[i].StartStallIndex,
                    EndStallIndex = spawnMarkers[i].EndStallIndex,
                    Speed = spawnMarkers[i].Speed,
                    View = spawnMarkers[i].View,
                    InteractionInterval = spawnMarkers[i].InteractionInterval,
                    InteractionRadius = spawnMarkers[i].InteractionRadius,
                    TargetCollectionLayerMask = spawnMarkers[i].InteractionLayerMask
                };
            }
        }

        private void RestoreLevel()
        {
            StallSpawnMarker[] stallSpawnMarkers = FindObjectsOfType<StallSpawnMarker>(true);

            foreach (StallSpawnMarker spawnMarker in stallSpawnMarkers)
            {
                spawnMarker.gameObject.SetActive(false);
            }

            int index = 0;
            foreach (StallsSpawnData spawnData in config.StallsSpawnData)
            {
                StallSpawnMarker currentMarker;
                if (stallSpawnMarkers.Length <= index)
                {
                    GameObject prefab = PrefabUtility.GetCorrespondingObjectFromSource(stallSpawnMarkers[0].gameObject);
                    GameObject spawnedObject = PrefabUtility.InstantiatePrefab(prefab, stallSpawnMarkers[0].transform.parent) as GameObject;
                    PrefabUtility.SetPropertyModifications(spawnedObject, PrefabUtility.GetPropertyModifications(prefab));
                    currentMarker = spawnedObject.GetComponent<StallSpawnMarker>();
                }
                else
                {
                    currentMarker = stallSpawnMarkers[index];
                }

                currentMarker.Bounds = spawnData.Bounds;
                currentMarker.Index = spawnData.Index;
                currentMarker.transform.position = spawnData.SpawnPosition;
                currentMarker.gameObject.SetActive(true);
                currentMarker.DisplayStallIndex();

                index++;
            }

            HoleSpawnMarker[] holeSpawnMarkers = FindObjectsOfType<HoleSpawnMarker>(true);
            
            index = 0;
            foreach (HoleSpawnMarker spawnMarker in holeSpawnMarkers)
            {
                spawnMarker.gameObject.SetActive(false);
            }
            
            foreach (PresetupHoleData spawnData in config.PresetupHoleData)
            {
                HoleSpawnMarker currentMarker;
                if (holeSpawnMarkers.Length <= index)
                {
                    GameObject prefab = PrefabUtility.GetCorrespondingObjectFromSource(holeSpawnMarkers[0].gameObject);
                    GameObject spawnedObject = PrefabUtility.InstantiatePrefab(prefab, holeSpawnMarkers[0].transform.parent) as GameObject;
                    PrefabUtility.SetPropertyModifications(spawnedObject, PrefabUtility.GetPropertyModifications(prefab));
                    currentMarker = spawnedObject.GetComponent<HoleSpawnMarker>();
                }
                else
                {
                    currentMarker = holeSpawnMarkers[index];
                }

                currentMarker.StallIndex = spawnData.StallIndex;
                currentMarker.Setup = spawnData.Setup;
                currentMarker.transform.position = spawnData.At;
                currentMarker.gameObject.SetActive(true);

                index++;
            }
            
            ConveyorBeltSpawnMarker[] conveyorSpawnMarkers = FindObjectsOfType<ConveyorBeltSpawnMarker>();
            
            index = 0;
            foreach (ConveyorBeltSpawnMarker spawnMarker in conveyorSpawnMarkers)
            {
                spawnMarker.gameObject.SetActive(false);
            }
            
            foreach (ConveyorBeltData spawnData in config.ConveyorBelts)
            {
                ConveyorBeltSpawnMarker currentMarker;
                if (conveyorSpawnMarkers.Length <= index)
                {
                    GameObject prefab = PrefabUtility.GetCorrespondingObjectFromSource(conveyorSpawnMarkers[0].gameObject);
                    GameObject spawnedObject = PrefabUtility.InstantiatePrefab(prefab, conveyorSpawnMarkers[0].transform.parent) as GameObject;
                    PrefabUtility.SetPropertyModifications(spawnedObject, PrefabUtility.GetPropertyModifications(prefab));
                    currentMarker = spawnedObject.GetComponent<ConveyorBeltSpawnMarker>();
                }
                else
                {
                    currentMarker = conveyorSpawnMarkers[index];
                }

                currentMarker.StartStallIndex = spawnData.StartStallIndex;
                currentMarker.EndStallIndex = spawnData.EndStallIndex;
                currentMarker.StartPoint.position = spawnData.StartPosition;
                currentMarker.EndPoint.position = spawnData.EndPosition;
                currentMarker.View = spawnData.View;
                currentMarker.InteractionInterval = spawnData.InteractionInterval;
                currentMarker.InteractionRadius = spawnData.InteractionRadius;
                currentMarker.InteractionLayerMask = spawnData.TargetCollectionLayerMask;
                currentMarker.gameObject.SetActive(true);

                index++;
            }
        }
    }
}