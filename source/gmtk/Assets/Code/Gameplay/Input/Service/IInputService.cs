using UnityEngine;

namespace Code.Gameplay.Input.Service
{
  public interface IInputService
  {
    float GetVerticalAxis();
    float GetHorizontalAxis();
    bool HasAxisInput();

    Vector2 GetScreenMousePosition();
    Vector2 GetWorldMousePosition();
    bool GetLeftMouseButtonDown();
    bool GetLeftMouseButtonUp();
    bool GetLeftMouseButton();
  }
}