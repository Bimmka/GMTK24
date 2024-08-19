using System;
using Code.Gameplay.Windows.Base;
using UnityEngine;

namespace Code.Gameplay.Windows.Configs
{
  [Serializable]
  public class WindowConfig
  {
    public WindowId Id;
    public GameObject Prefab;
  }
}