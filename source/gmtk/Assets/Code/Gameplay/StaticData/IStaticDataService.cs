using Code.Gameplay.Features.Level.Config;
using Code.Gameplay.Features.Rabbits.Config;
using Code.Gameplay.Features.Rabbits.Config.Rabbits;
using Code.Gameplay.Features.Rabbits.Config.Replication;
using Code.Gameplay.Features.Selection.Config;
using Code.Gameplay.Input.Config;
using Code.Gameplay.Windows;
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
  }
}