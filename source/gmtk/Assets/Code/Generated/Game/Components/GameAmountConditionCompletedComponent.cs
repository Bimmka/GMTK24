//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAmountConditionCompleted;

    public static Entitas.IMatcher<GameEntity> AmountConditionCompleted {
        get {
            if (_matcherAmountConditionCompleted == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AmountConditionCompleted);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAmountConditionCompleted = matcher;
            }

            return _matcherAmountConditionCompleted;
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

    static readonly Code.Gameplay.Features.LevelTasks.AmountConditionCompleted amountConditionCompletedComponent = new Code.Gameplay.Features.LevelTasks.AmountConditionCompleted();

    public bool isAmountConditionCompleted {
        get { return HasComponent(GameComponentsLookup.AmountConditionCompleted); }
        set {
            if (value != isAmountConditionCompleted) {
                var index = GameComponentsLookup.AmountConditionCompleted;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : amountConditionCompletedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}