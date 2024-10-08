//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskRangeAmountType;

    public static Entitas.IMatcher<GameEntity> LevelTaskRangeAmountType {
        get {
            if (_matcherLevelTaskRangeAmountType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskRangeAmountType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskRangeAmountType = matcher;
            }

            return _matcherLevelTaskRangeAmountType;
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

    static readonly Code.Gameplay.Features.LevelTasks.LevelTaskRangeAmountType levelTaskRangeAmountTypeComponent = new Code.Gameplay.Features.LevelTasks.LevelTaskRangeAmountType();

    public bool isLevelTaskRangeAmountType {
        get { return HasComponent(GameComponentsLookup.LevelTaskRangeAmountType); }
        set {
            if (value != isLevelTaskRangeAmountType) {
                var index = GameComponentsLookup.LevelTaskRangeAmountType;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelTaskRangeAmountTypeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
