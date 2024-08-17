//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovingPhase;

    public static Entitas.IMatcher<GameEntity> MovingPhase {
        get {
            if (_matcherMovingPhase == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovingPhase);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovingPhase = matcher;
            }

            return _matcherMovingPhase;
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

    static readonly Code.Gameplay.Features.Rabbits.MovingPhase movingPhaseComponent = new Code.Gameplay.Features.Rabbits.MovingPhase();

    public bool isMovingPhase {
        get { return HasComponent(GameComponentsLookup.MovingPhase); }
        set {
            if (value != isMovingPhase) {
                var index = GameComponentsLookup.MovingPhase;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : movingPhaseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
