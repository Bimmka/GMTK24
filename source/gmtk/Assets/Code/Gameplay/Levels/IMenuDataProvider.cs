using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface IMenuDataProvider
    {
        public GameObject[] ObjectsToHide { get; }

        void SetObjectsToHide(GameObject[] objects);
    }
}