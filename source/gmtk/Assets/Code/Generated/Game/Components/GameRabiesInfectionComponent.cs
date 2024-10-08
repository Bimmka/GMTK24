//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRabiesInfection;

    public static Entitas.IMatcher<GameEntity> RabiesInfection {
        get {
            if (_matcherRabiesInfection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RabiesInfection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRabiesInfection = matcher;
            }

            return _matcherRabiesInfection;
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

    static readonly Code.Gameplay.Features.Infections.RabiesInfection rabiesInfectionComponent = new Code.Gameplay.Features.Infections.RabiesInfection();

    public bool isRabiesInfection {
        get { return HasComponent(GameComponentsLookup.RabiesInfection); }
        set {
            if (value != isRabiesInfection) {
                var index = GameComponentsLookup.RabiesInfection;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rabiesInfectionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
