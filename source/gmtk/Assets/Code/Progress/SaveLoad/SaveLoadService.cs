using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "PlayerProgress";
      
    private readonly IProgressProvider _progressProvider;

    public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

    public SaveLoadService(IProgressProvider progressProvider)
    {
      _progressProvider = progressProvider;
    }

    public void CreateProgress()
    {
      _progressProvider.SetProgressData(new ProgressData()
      {
        PassedLevels = new List<string>()
      });
    }

    public void SaveProgress()
    {
      PlayerPrefs.SetString(ProgressKey, _progressProvider.ProgressData.ToJson());
      PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
      _progressProvider.SetProgressData(PlayerPrefs.GetString(ProgressKey).FromJson<ProgressData>());
    }
  }
}