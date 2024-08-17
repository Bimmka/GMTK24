using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, GameObject> _windowPrefabsById;
    private Dictionary<string,LevelConfig> _levelConfigsById;

    public void LoadAll()
    {
      LoadWindows();
      LoadLevelConfigs();
    }

    public GameObject GetWindowPrefab(WindowId id) =>
      _windowPrefabsById.TryGetValue(id, out GameObject prefab)
        ? prefab
        : throw new Exception($"Prefab config for window {id} was not found");
    
    public LevelConfig GetLevelConfig(string id) =>
      _levelConfigsById.TryGetValue(id, out LevelConfig config)
        ? config
        : throw new Exception($"Level config with id: {id} was not found");


    private void LoadWindows()
    {
      _windowPrefabsById = Resources
        .Load<WindowsConfig>("Configs/Windows/WindowConfig")
        .WindowConfigs
        .ToDictionary(x => x.Id, x => x.Prefab);
    }

    private void LoadLevelConfigs() =>
      _levelConfigsById = Resources.LoadAll<LevelConfig>("Configs/LevelConfigs").ToDictionary(x => x.Id, x => x);
  }
}