using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public class GameLevelView : MonoBehaviour
    {
        public Button ClickButton;
        public TextMeshProUGUI IndexText;
        public int Index;
        public string LevelId;
        public bool Completed;
        public bool Unlocked;
        public Image[] ObjectToLock;
        public float LockedAlpha;
        public float DefaultAlpha;
        public GameObject CompleteIcon;
        public GameObject LevelText;

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
            IndexText.text = $"{Index + 1}";

            foreach (Image objectToLock in ObjectToLock)
            {
                Color color = objectToLock.color;
                color.a = Unlocked ? DefaultAlpha : LockedAlpha;
                objectToLock.color = color;
            }

            ClickButton.enabled = Unlocked;
            
            CompleteIcon.SetActive(Completed);
            LevelText.SetActive(Completed == false);
        }

        private void InvokeSavedCallback()
        {
            if (Unlocked)
                _savedClickCallback?.Invoke(LevelId, Completed);
        }
    }
}