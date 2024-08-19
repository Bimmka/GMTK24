//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInfectionTrayWidth;

    public static Entitas.IMatcher<GameEntity> InfectionTrayWidth {
        get {
            if (_matcherInfectionTrayWidth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InfectionTrayWidth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInfectionTrayWidth = matcher;
            }

            return _matcherInfectionTrayWidth;
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

    public Code.Gameplay.Features.Infections.InfectionTrayWidth infectionTrayWidth { get { return (Code.Gameplay.Features.Infections.InfectionTrayWidth)GetComponent(GameComponentsLookup.InfectionTrayWidth); } }
    public float InfectionTrayWidth { get { return infectionTrayWidth.Value; } }
    public bool hasInfectionTrayWidth { get { return HasComponent(GameComponentsLookup.InfectionTrayWidth); } }

    public GameEntity AddInfectionTrayWidth(float newValue) {
        var index = GameComponentsLookup.InfectionTrayWidth;
        var component = (Code.Gameplay.Features.Infections.InfectionTrayWidth)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionTrayWidth));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInfectionTrayWidth(float newValue) {
        var index = GameComponentsLookup.InfectionTrayWidth;
        var component = (Code.Gameplay.Features.Infections.InfectionTrayWidth)CreateComponent(index, typeof(Code.Gameplay.Features.Infections.InfectionTrayWidth));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInfectionTrayWidth() {
        RemoveComponent(GameComponentsLookup.InfectionTrayWidth);
        return this;
    }
}