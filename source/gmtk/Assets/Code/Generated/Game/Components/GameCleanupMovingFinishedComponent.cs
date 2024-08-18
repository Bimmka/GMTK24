//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCleanupMovingFinished;

    public static Entitas.IMatcher<GameEntity> CleanupMovingFinished {
        get {
            if (_matcherCleanupMovingFinished == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CleanupMovingFinished);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCleanupMovingFinished = matcher;
            }

            return _matcherCleanupMovingFinished;
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

    static readonly Code.Gameplay.Features.Rabbits.CleanupMovingFinished cleanupMovingFinishedComponent = new Code.Gameplay.Features.Rabbits.CleanupMovingFinished();

    public bool isCleanupMovingFinished {
        get { return HasComponent(GameComponentsLookup.CleanupMovingFinished); }
        set {
            if (value != isCleanupMovingFinished) {
                var index = GameComponentsLookup.CleanupMovingFinished;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : cleanupMovingFinishedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}