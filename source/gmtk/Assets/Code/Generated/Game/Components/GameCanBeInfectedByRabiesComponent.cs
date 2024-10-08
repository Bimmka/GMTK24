//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCanBeInfectedByRabies;

    public static Entitas.IMatcher<GameEntity> CanBeInfectedByRabies {
        get {
            if (_matcherCanBeInfectedByRabies == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CanBeInfectedByRabies);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCanBeInfectedByRabies = matcher;
            }

            return _matcherCanBeInfectedByRabies;
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

    static readonly Code.Gameplay.Features.Infections.CanBeInfectedByRabies canBeInfectedByRabiesComponent = new Code.Gameplay.Features.Infections.CanBeInfectedByRabies();

    public bool isCanBeInfectedByRabies {
        get { return HasComponent(GameComponentsLookup.CanBeInfectedByRabies); }
        set {
            if (value != isCanBeInfectedByRabies) {
                var index = GameComponentsLookup.CanBeInfectedByRabies;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : canBeInfectedByRabiesComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
