using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Foxes.Config;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.Replication;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.Input.Config;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, GameObject> _windowPrefabsById;
    private Dictionary<string,LevelConfig> _levelConfigsById;
    private Dictionary<RabbitColorType,RabbitConfig> _rabbitConfigsByColor;
    private InputConfig _inputConfig;
    private SelectionConfig _selectionConfig;
    private ReplicationRulesConfig _replicationRulesConfig;
    private Dictionary<InfectionType,InfectionConfig> _infectionConfigsByType;
    private FoxConfig _foxConfig;

    public void LoadAll()
    {
      LoadWindows();
      LoadLevelConfigs();
      LoadRabbitConfigs();
      LoadInputConfig();
      LoadSelectionConfig();
      LoadReplicationRulesConfig();
      LoadInfectionConfigs();
      LoadFoxConfig();
    }

    
    public GameObject GetWindowPrefab(WindowId id) =>
      _windowPrefabsById.TryGetValue(id, out GameObject prefab)
        ? prefab
        : throw new Exception($"Prefab config for window {id} was not found");

    public LevelConfig GetLevelConfig(string id) =>
      _levelConfigsById.TryGetValue(id, out LevelConfig config)
        ? config
        : throw new Exception($"Level config with id: {id} was not found");
    
    public List<LevelConfig> GetLevelConfigs() =>
      _levelConfigsById.Values.ToList();
      
    public RabbitConfig GetRabbitConfig(RabbitColorType type) =>
      _rabbitConfigsByColor.TryGetValue(type, out RabbitConfig config)
        ? config
        : throw new Exception($"Rabbit config with color: {type} was not found");

    public ReplicationRulesConfig GetReplicationRulesConfig() =>
      _replicationRulesConfig;

    public InputConfig GetInputConfig() =>
      _inputConfig;

    public SelectionConfig GetSelectionConfig() =>
      _selectionConfig;

    public InfectionConfig GetInfectionConfig(InfectionType infectionType) =>
      _infectionConfigsByType.TryGetValue(infectionType, out InfectionConfig config)
        ? config
        : throw new Exception($"Infection config with type: {infectionType} was not found");

    public FoxConfig GetFoxConfig() =>
      _foxConfig;

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
      _rabbitConfigsByColor = Resources.LoadAll<RabbitConfig>("Configs/Rabbits").ToDictionary(x => x.ColorType, x => x);

    private void LoadReplicationRulesConfig()
    {
      _replicationRulesConfig = Resources.Load<ReplicationRulesConfig>("Configs/ReplicationRules/ReplicationRulesConfig");
    }

    private void LoadInputConfig() =>
      _inputConfig = Resources.Load<InputConfig>("Configs/Input/InputConfig");

    private void LoadSelectionConfig() =>
      _selectionConfig = Resources.Load<SelectionConfig>("Configs/Selection/SelectionConfig");

    private void LoadInfectionConfigs() =>
      _infectionConfigsByType = Resources.LoadAll<InfectionConfig>("Configs/Infections").ToDictionary(x => x.InfectionSetup.Type, x => x);
    
    private void LoadFoxConfig() =>
      _foxConfig = Resources.Load<FoxConfig>("Configs/Foxes/FoxConfig");
  }
}