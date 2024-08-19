using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class GameLevelView : MonoBehaviour
    {
        public Button ClickButton;
        public TextMeshProUGUI LevelText;
        public int Index;
        public string LevelId;
        public bool Completed;
        public bool Unlocked;
        public GameObject BlockedShadow;

        private Action<string, bool> _savedClickCallback;

        public void Initialize(int index, string levelId, bool completed, bool isUnlocked, Action<string, bool> onClick)
        {
            Index = index;
            LevelId = levelId;
            Completed = completed;
            Unlocked = isUnlocked;
            _savedClickCallback = onClick;
            
            ClickButton.onClick.AddListener(InvokeSavedCallback);

            UpdateVisual();
        }

        public void OnDestroy()
        {
            ClickButton.onClick.RemoveListener(InvokeSavedCallback);
        }

        private void UpdateVisual()
        {
            LevelText.text = $"Level {Index}";
            BlockedShadow.SetActive(Unlocked == false);
        }

        private void InvokeSavedCallback()
        {
            if (Unlocked)
                _savedClickCallback?.Invoke(LevelId, Completed);
        }
    }
}