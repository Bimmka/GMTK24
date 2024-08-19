using System.Collections.Generic;
using Code.Gameplay.Windows.Base;
using Code.Gameplay.Windows.Factory;
using UnityEngine;

namespace Code.Gameplay.Windows.Service
{
  public class WindowService : IWindowService
  {
    private readonly IWindowFactory _windowFactory;

    private readonly List<BaseWindow> _openedWindows = new();

    public WindowService(IWindowFactory windowFactory) =>
      _windowFactory = windowFactory;

    public BaseWindow Open(WindowId windowId)
    {
      BaseWindow window = _windowFactory.CreateWindow(windowId);
      _openedWindows.Add(window);
      return window;
    }

    public void Close(WindowId windowId)
    {
      BaseWindow window = _openedWindows.Find(x => x.Id == windowId);
      
      _openedWindows.Remove(window);
      
      GameObject.Destroy(window.gameObject);
    }
  }
}