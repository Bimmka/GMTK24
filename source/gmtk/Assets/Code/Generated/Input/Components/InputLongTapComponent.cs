//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherLongTap;

    public static Entitas.IMatcher<InputEntity> LongTap {
        get {
            if (_matcherLongTap == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.LongTap);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherLongTap = matcher;
            }

            return _matcherLongTap;
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

    static readonly Code.Gameplay.Input.LongTap longTapComponent = new Code.Gameplay.Input.LongTap();

    public bool isLongTap {
        get { return HasComponent(InputComponentsLookup.LongTap); }
        set {
            if (value != isLongTap) {
                var index = InputComponentsLookup.LongTap;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : longTapComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
