//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWaitingHunt;

    public static Entitas.IMatcher<GameEntity> WaitingHunt {
        get {
            if (_matcherWaitingHunt == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WaitingHunt);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWaitingHunt = matcher;
            }

            return _matcherWaitingHunt;
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

    static readonly Code.Gameplay.Features.Foxes.WaitingHunt waitingHuntComponent = new Code.Gameplay.Features.Foxes.WaitingHunt();

    public bool isWaitingHunt {
        get { return HasComponent(GameComponentsLookup.WaitingHunt); }
        set {
            if (value != isWaitingHunt) {
                var index = GameComponentsLookup.WaitingHunt;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : waitingHuntComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
