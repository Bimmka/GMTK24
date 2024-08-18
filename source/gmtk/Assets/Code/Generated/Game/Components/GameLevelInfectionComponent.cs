//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelInfection;

    public static Entitas.IMatcher<GameEntity> LevelInfection {
        get {
            if (_matcherLevelInfection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelInfection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelInfection = matcher;
            }

            return _matcherLevelInfection;
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

    static readonly Code.Gameplay.Features.Infections.LevelInfection levelInfectionComponent = new Code.Gameplay.Features.Infections.LevelInfection();

    public bool isLevelInfection {
        get { return HasComponent(GameComponentsLookup.LevelInfection); }
        set {
            if (value != isLevelInfection) {
                var index = GameComponentsLookup.LevelInfection;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelInfectionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
