//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherConditionsUncompleted;

    public static Entitas.IMatcher<GameEntity> ConditionsUncompleted {
        get {
            if (_matcherConditionsUncompleted == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ConditionsUncompleted);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherConditionsUncompleted = matcher;
            }

            return _matcherConditionsUncompleted;
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

    static readonly Code.Gameplay.Features.LevelTasks.ConditionsUncompleted conditionsUncompletedComponent = new Code.Gameplay.Features.LevelTasks.ConditionsUncompleted();

    public bool isConditionsUncompleted {
        get { return HasComponent(GameComponentsLookup.ConditionsUncompleted); }
        set {
            if (value != isConditionsUncompleted) {
                var index = GameComponentsLookup.ConditionsUncompleted;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : conditionsUncompletedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
