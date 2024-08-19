//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskConcreteRabbitAmount;

    public static Entitas.IMatcher<GameEntity> LevelTaskConcreteRabbitAmount {
        get {
            if (_matcherLevelTaskConcreteRabbitAmount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskConcreteRabbitAmount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskConcreteRabbitAmount = matcher;
            }

            return _matcherLevelTaskConcreteRabbitAmount;
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

    static readonly Code.Gameplay.Features.LevelTasks.LevelTaskConcreteRabbitAmount levelTaskConcreteRabbitAmountComponent = new Code.Gameplay.Features.LevelTasks.LevelTaskConcreteRabbitAmount();

    public bool isLevelTaskConcreteRabbitAmount {
        get { return HasComponent(GameComponentsLookup.LevelTaskConcreteRabbitAmount); }
        set {
            if (value != isLevelTaskConcreteRabbitAmount) {
                var index = GameComponentsLookup.LevelTaskConcreteRabbitAmount;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelTaskConcreteRabbitAmountComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
