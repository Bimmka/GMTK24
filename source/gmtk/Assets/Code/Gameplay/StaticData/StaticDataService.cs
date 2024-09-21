using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Foxes.Config;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.Replication;
using Code.Gameplay.Features.Rabbits.Config.UI;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.Input.Config;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.VFX.Config;
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
    private Dictionary<InfectionType, Dictionary<InfectionTargetType, InfectionConfig>> _infectionConfigsByType;
    private FoxConfig _foxConfig;
    private RabbitUIConfig _rabbitUIConfig;
    private Dictionary<VFXType, VFXContainer> _vfxByType;
    private Dictionary<SoundType, SoundContainer> _soundByType;
    private SoundMixerConfig _soundMixerConfig;

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
      LoadUIRabbitConfig();
      LoadVFXContainer();
      LoadSounds();
      LoadSoundMixerConfig();
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
      _levelConfigsById.Values.OrderBy(x => x.Index).ToList();

    public SpriteByRabbitColor GetRabbitSpriteByColor(RabbitColorType colorType)
    {
      return _rabbitUIConfig.SpritesByColor.FirstOrDefault(x => x.Color == colorType);
    }

    public RabbitConfig GetRabbitConfig(RabbitColorType type) =>
      _rabbitConfigsByColor.TryGetValue(type, out RabbitConfig config)
        ? config
        : throw new Exception($"Rabbit config with color: {type} was not found");

    public VFXContainer GetVFXContainer(VFXType type) =>
      _vfxByType.TryGetValue(type, out VFXContainer config)
        ? config
        : throw new Exception($"VFXContainer with type: {type} was not found");

    public SoundContainer GetSoundData(SoundType type) =>
      _soundByType.TryGetValue(type, out SoundContainer config)
        ? config
        : throw new Exception($"Sound container with type: {type} was not found");

    public SoundMixerConfig GetSoundMixerConfig() => _soundMixerConfig;

    public ReplicationRulesConfig GetReplicationRulesConfig() =>
      _replicationRulesConfig;

    public InputConfig GetInputConfig() =>
      _inputConfig;

    public SelectionConfig GetSelectionConfig() =>
      _selectionConfig;

    public InfectionConfig GetInfectionConfig(InfectionType infectionType, InfectionTargetType targetType)
    {
      if (_infectionConfigsByType.TryGetValue(infectionType, out Dictionary<InfectionTargetType, InfectionConfig> configs))
      {
        return configs.TryGetValue(targetType, out InfectionConfig config)
          ? config
          : throw new Exception($"Infection config with type: {infectionType} and target : {targetType} was not found");
      }
      
      throw new Exception($"Infection config with type: {infectionType} and target : {targetType} was not found");
    }

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

    private void LoadInfectionConfigs()
    {
      var infectionConfigs = Resources.LoadAll<InfectionConfig>("Configs/Infections");

      _infectionConfigsByType = new Dictionary<InfectionType, Dictionary<InfectionTargetType, InfectionConfig>>();

      foreach (InfectionConfig infectionConfig in infectionConfigs)
      {
        if (_infectionConfigsByType.TryGetValue(infectionConfig.InfectionSetup.Type, out Dictionary<InfectionTargetType, InfectionConfig> configs))
        {
          configs.TryAdd(infectionConfig.TargetType, infectionConfig);
        }
        else
        {
          _infectionConfigsByType.TryAdd(infectionConfig.InfectionSetup.Type,
            new Dictionary<InfectionTargetType, InfectionConfig>()
            {
              {
                infectionConfig.TargetType, infectionConfig
              }
            });
        }
      }
    }

    private void LoadFoxConfig() =>
      _foxConfig = Resources.Load<FoxConfig>("Configs/Foxes/FoxConfig");

    private void LoadUIRabbitConfig() =>
      _rabbitUIConfig = Resources.Load<RabbitUIConfig>("Configs/Rabbits/RabbitUIConfig");

    private void LoadVFXContainer() =>
      _vfxByType = Resources.Load<VFXContainerConfig>("Configs/VFX/VFXContainerConfig").VFXContainers.ToDictionary(x => x.Type, x=> x);

    private void LoadSounds() =>
      _soundByType = Resources.Load<SoundsConfig>("Configs/Sound/SoundsConfig").SoundContainers.ToDictionary(x => x.Type, x=> x);

    private void LoadSoundMixerConfig() =>
      _soundMixerConfig = Resources.Load<SoundMixerConfig>("Configs/Sound/SoundMixerConfig");
  }
}