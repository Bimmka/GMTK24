//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWaitingHoldTime;

    public static Entitas.IMatcher<GameEntity> WaitingHoldTime {
        get {
            if (_matcherWaitingHoldTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WaitingHoldTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWaitingHoldTime = matcher;
            }

            return _matcherWaitingHoldTime;
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

    static readonly Code.Gameplay.Features.LevelTasks.WaitingHoldTime waitingHoldTimeComponent = new Code.Gameplay.Features.LevelTasks.WaitingHoldTime();

    public bool isWaitingHoldTime {
        get { return HasComponent(GameComponentsLookup.WaitingHoldTime); }
        set {
            if (value != isWaitingHoldTime) {
                var index = GameComponentsLookup.WaitingHoldTime;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : waitingHoldTimeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
