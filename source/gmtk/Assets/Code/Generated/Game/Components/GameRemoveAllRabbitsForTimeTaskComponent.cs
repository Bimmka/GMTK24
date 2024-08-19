//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRemoveAllRabbitsForTimeTask;

    public static Entitas.IMatcher<GameEntity> RemoveAllRabbitsForTimeTask {
        get {
            if (_matcherRemoveAllRabbitsForTimeTask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RemoveAllRabbitsForTimeTask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRemoveAllRabbitsForTimeTask = matcher;
            }

            return _matcherRemoveAllRabbitsForTimeTask;
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

    static readonly Code.Gameplay.Features.LevelTasks.RemoveAllRabbitsForTimeTask removeAllRabbitsForTimeTaskComponent = new Code.Gameplay.Features.LevelTasks.RemoveAllRabbitsForTimeTask();

    public bool isRemoveAllRabbitsForTimeTask {
        get { return HasComponent(GameComponentsLookup.RemoveAllRabbitsForTimeTask); }
        set {
            if (value != isRemoveAllRabbitsForTimeTask) {
                var index = GameComponentsLookup.RemoveAllRabbitsForTimeTask;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : removeAllRabbitsForTimeTaskComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
