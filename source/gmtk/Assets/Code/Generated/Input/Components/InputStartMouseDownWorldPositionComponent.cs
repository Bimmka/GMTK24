//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherStartMouseDownWorldPosition;

    public static Entitas.IMatcher<InputEntity> StartMouseDownWorldPosition {
        get {
            if (_matcherStartMouseDownWorldPosition == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.StartMouseDownWorldPosition);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherStartMouseDownWorldPosition = matcher;
            }

            return _matcherStartMouseDownWorldPosition;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Code.Gameplay.Input.StartMouseDownWorldPosition startMouseDownWorldPosition { get { return (Code.Gameplay.Input.StartMouseDownWorldPosition)GetComponent(InputComponentsLookup.StartMouseDownWorldPosition); } }
    public UnityEngine.Vector2 StartMouseDownWorldPosition { get { return startMouseDownWorldPosition.Value; } }
    public bool hasStartMouseDownWorldPosition { get { return HasComponent(InputComponentsLookup.StartMouseDownWorldPosition); } }

    public InputEntity AddStartMouseDownWorldPosition(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.StartMouseDownWorldPosition;
        var component = (Code.Gameplay.Input.StartMouseDownWorldPosition)CreateComponent(index, typeof(Code.Gameplay.Input.StartMouseDownWorldPosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceStartMouseDownWorldPosition(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.StartMouseDownWorldPosition;
        var component = (Code.Gameplay.Input.StartMouseDownWorldPosition)CreateComponent(index, typeof(Code.Gameplay.Input.StartMouseDownWorldPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveStartMouseDownWorldPosition() {
        RemoveComponent(InputComponentsLookup.StartMouseDownWorldPosition);
        return this;
    }
}
