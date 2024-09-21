using System.Collections.Generic;
using Code.Gameplay.Features.Foxes.Config;
using Code.Gameplay.Features.Infections.Configs;
using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.Replication;
using Code.Gameplay.Features.Rabbits.Config.UI;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.Input.Config;
using Code.Gameplay.Sounds.Config;
using Code.Gameplay.VFX.Config;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Base;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    GameObject GetWindowPrefab(WindowId id);
    LevelConfig GetLevelConfig(string id);
    RabbitConfig GetRabbitConfig(RabbitColorType type);
    ReplicationRulesConfig GetReplicationRulesConfig();
    InputConfig GetInputConfig();
    SelectionConfig GetSelectionConfig();
    InfectionConfig GetInfectionConfig(InfectionType infectionType, InfectionTargetType targetType);
    FoxConfig GetFoxConfig();
    List<LevelConfig> GetLevelConfigs();
    SpriteByRabbitColor GetRabbitSpriteByColor(RabbitColorType colorType);
    VFXContainer GetVFXContainer(VFXType type);
    SoundContainer GetSoundData(SoundType type);
    SoundMixerConfig GetSoundMixerConfig();
  }
}