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
    private const string MainSoundVolumeSaveKey = "MainSound";
    private const string SoundsVolumeSaveKey = "Sound";
    private const string EffectsVolumeSaveKey = "Effects";
      
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
    
    public void SaveAudioPreferences(SavedAudioPreferences savedAudioPreferences)
    {
      PlayerPrefs.SetFloat(MainSoundVolumeSaveKey, savedAudioPreferences.MainSoundVolume);
      PlayerPrefs.SetFloat(SoundsVolumeSaveKey, savedAudioPreferences.SoundsVolume);
      PlayerPrefs.SetFloat(EffectsVolumeSaveKey, savedAudioPreferences.EffectsVolume);
      PlayerPrefs.Save();
    }

    public SavedAudioPreferences LoadAudioPreferences()
    {
      return new SavedAudioPreferences()
      {
        MainSoundVolume = PlayerPrefs.GetFloat(MainSoundVolumeSaveKey, 0.5f),
        SoundsVolume = PlayerPrefs.GetFloat(SoundsVolumeSaveKey, 0.5f),
        EffectsVolume = PlayerPrefs.GetFloat(EffectsVolumeSaveKey, 0.5f),
      };
    }
  }
}