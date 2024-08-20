using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class MenuDataProvider : IMenuDataProvider
    {
        public GameObject[] ObjectsToHide { get; private set; }
        public void SetObjectsToHide(GameObject[] objects)
        {
            ObjectsToHide = objects;
        }
    }
}