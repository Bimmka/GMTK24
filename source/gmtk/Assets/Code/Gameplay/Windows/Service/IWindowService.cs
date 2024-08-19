using Code.Gameplay.Windows.Base;

namespace Code.Gameplay.Windows.Service
{
  public interface IWindowService
  {
    BaseWindow Open(WindowId windowId);
    void Close(WindowId windowId);
  }
}