//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInfectionRadius;

    public static Entitas.IMatcher<GameEntity> InfectionRadius {
        get {
            if (_matcherInfectionRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InfectionRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInfectionRadius = matcher;
            }

            return _matcherInfectionRadius;
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

    public Code.Gameplay.Features.Infections.InfectionRadius infectionRadius { get { return (Code.Gameplay.Features.Infections.InfectionRadius)GetComponent(GameComponentsLookup.InfectionRadius); } }
    public float InfectionRadius { get { return infectionRadius.Value; } }
    public bool hasInfectionRadius { get { return HasComponent(GameComponentsLookup.InfectionRadius); } }

    public GameEntity AddInfectionRadius(float newValue) {
        var index = GameComponentsLookup.InfectionRadius;
        var component = (Code.Gameplay.Features.Infections.InfectionRadius)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionRadius));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInfectionRadius(float newValue) {
        var index = GameComponentsLookup.InfectionRadius;
        var component = (Code.Gameplay.Features.Infections.InfectionRadius)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInfectionRadius() {
        RemoveComponent(GameComponentsLookup.InfectionRadius);
        return this;
    }
}