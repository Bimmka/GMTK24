using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Config;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.Input.Config;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, GameObject> _windowPrefabsById;
    private Dictionary<string,LevelConfig> _levelConfigsById;
    private Dictionary<RabbitType,RabbitConfig> _rabbitConfigsById;
    private InputConfig _inputConfig;
    private SelectionConfig _selectionConfig;

    public void LoadAll()
    {
      LoadWindows();
      LoadLevelConfigs();
      LoadRabbitConfigs();
      LoadInputConfig();
      LoadSelectionConfig();
    }

    public GameObject GetWindowPrefab(WindowId id) =>
      _windowPrefabsById.TryGetValue(id, out GameObject prefab)
        ? prefab
        : throw new Exception($"Prefab config for window {id} was not found");

    public LevelConfig GetLevelConfig(string id) =>
      _levelConfigsById.TryGetValue(id, out LevelConfig config)
        ? config
        : throw new Exception($"Level config with id: {id} was not found");
    
    public RabbitConfig GetRabbitConfig(RabbitType type) =>
      _rabbitConfigsById.TryGetValue(type, out RabbitConfig config)
        ? config
        : throw new Exception($"Rabbit config with type: {type} was not found");

    public InputConfig GetInputConfig() =>
      _inputConfig;
    
    public SelectionConfig GetSelectionConfig() =>
      _selectionConfig;

    private void LoadWindows()
    {
      _windowPrefabsById = Resources
        .Load<WindowsConfig>("Configs/Windows/WindowConfig")
        .WindowConfigs
        .ToDictionary(x => x.Id, x => x.Prefab);
    }

    private void LoadLevelConfigs() =>
      _levelConfigsById = Resources.LoadAll<LevelConfig>("Configs/LevelConfigs").ToDictionary(x => x.Id, x => x);

    private void LoadRabbitConfigs() =>
      _rabbitConfigsById = Resources.LoadAll<RabbitConfig>("Configs/Rabbits").ToDictionary(x => x.Type, x => x);
    
    private void LoadInputConfig() =>
      _inputConfig = Resources.Load<InputConfig>("Configs/Input/InputConfig");

    private void LoadSelectionConfig()
    {
      _selectionConfig = Resources.Load<SelectionConfig>("Configs/Selection/SelectionConfig");
    }
  }
}