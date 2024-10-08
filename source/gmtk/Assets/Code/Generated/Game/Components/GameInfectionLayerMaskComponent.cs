//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInfectionLayerMask;

    public static Entitas.IMatcher<GameEntity> InfectionLayerMask {
        get {
            if (_matcherInfectionLayerMask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InfectionLayerMask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInfectionLayerMask = matcher;
            }

            return _matcherInfectionLayerMask;
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
public partial class GameEntity {

    public Code.Gameplay.Features.Infections.InfectionLayerMask infectionLayerMask { get { return (Code.Gameplay.Features.Infections.InfectionLayerMask)GetComponent(GameComponentsLookup.InfectionLayerMask); } }
    public UnityEngine.LayerMask InfectionLayerMask { get { return infectionLayerMask.Value; } }
    public bool hasInfectionLayerMask { get { return HasComponent(GameComponentsLookup.InfectionLayerMask); } }

    public GameEntity AddInfectionLayerMask(UnityEngine.LayerMask newValue) {
        var index = GameComponentsLookup.InfectionLayerMask;
        var component = (Code.Gameplay.Features.Infections.InfectionLayerMask)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionLayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInfectionLayerMask(UnityEngine.LayerMask newValue) {
        var index = GameComponentsLookup.InfectionLayerMask;
        var component = (Code.Gameplay.Features.Infections.InfectionLayerMask)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionLayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInfectionLayerMask() {
        RemoveComponent(GameComponentsLookup.InfectionLayerMask);
        return this;
    }
}
