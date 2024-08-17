﻿using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
  [Input] public class Input : IComponent { }
  [Input] public class AxisInput : IComponent { public Vector2 Value; }
  [Input] public class ScreenMousePosition : IComponent { public Vector2 Value; }
  [Input] public class WorldMousePosition : IComponent { public Vector2 Value; }
  [Input] public class MouseDown : IComponent {}
  [Input] public class MousePressed : IComponent {}
  [Input] public class MouseUp : IComponent {}
  [Input] public class Draging : IComponent {}
  [Input] public class LastMouseDownTime : IComponent { public float Value; }
  [Input] public class Click : IComponent { }
  [Input] public class StartMouseDownWorldPosition : IComponent { public Vector2 Value; }
  [Input] public class StartMouseDownScreenPosition : IComponent { public Vector2 Value; }
  [Input] public class ClickInterval : IComponent { public float Value; }
  [Input] public class LongTapInterval : IComponent { public float Value; }
  [Input] public class LongTap : IComponent { }
}