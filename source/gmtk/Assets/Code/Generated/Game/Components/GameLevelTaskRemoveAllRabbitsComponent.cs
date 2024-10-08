//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelTaskRemoveAllRabbits;

    public static Entitas.IMatcher<GameEntity> LevelTaskRemoveAllRabbits {
        get {
            if (_matcherLevelTaskRemoveAllRabbits == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTaskRemoveAllRabbits);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTaskRemoveAllRabbits = matcher;
            }

            return _matcherLevelTaskRemoveAllRabbits;
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

    static readonly Code.Gameplay.Features.LevelTasks.LevelTaskRemoveAllRabbits levelTaskRemoveAllRabbitsComponent = new Code.Gameplay.Features.LevelTasks.LevelTaskRemoveAllRabbits();

    public bool isLevelTaskRemoveAllRabbits {
        get { return HasComponent(GameComponentsLookup.LevelTaskRemoveAllRabbits); }
        set {
            if (value != isLevelTaskRemoveAllRabbits) {
                var index = GameComponentsLookup.LevelTaskRemoveAllRabbits;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelTaskRemoveAllRabbitsComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
