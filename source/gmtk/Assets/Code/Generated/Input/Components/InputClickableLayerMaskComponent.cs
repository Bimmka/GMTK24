//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherClickableLayerMask;

    public static Entitas.IMatcher<InputEntity> ClickableLayerMask {
        get {
            if (_matcherClickableLayerMask == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ClickableLayerMask);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherClickableLayerMask = matcher;
            }

            return _matcherClickableLayerMask;
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

    public Code.Gameplay.Input.ClickableLayerMask clickableLayerMask { get { return (Code.Gameplay.Input.ClickableLayerMask)GetComponent(InputComponentsLookup.ClickableLayerMask); } }
    public UnityEngine.LayerMask ClickableLayerMask { get { return clickableLayerMask.Value; } }
    public bool hasClickableLayerMask { get { return HasComponent(InputComponentsLookup.ClickableLayerMask); } }

    public InputEntity AddClickableLayerMask(UnityEngine.LayerMask newValue) {
        var index = InputComponentsLookup.ClickableLayerMask;
        var component = (Code.Gameplay.Input.ClickableLayerMask)CreateComponent(index, typeof(Code.Gameplay.Input.ClickableLayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceClickableLayerMask(UnityEngine.LayerMask newValue) {
        var index = InputComponentsLookup.ClickableLayerMask;
        var component = (Code.Gameplay.Input.ClickableLayerMask)CreateComponent(index, typeof(Code.Gameplay.Input.ClickableLayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveClickableLayerMask() {
        RemoveComponent(InputComponentsLookup.ClickableLayerMask);
        return this;
    }
}
