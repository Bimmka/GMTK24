//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSelectedEntities;

    public static Entitas.IMatcher<GameEntity> SelectedEntities {
        get {
            if (_matcherSelectedEntities == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SelectedEntities);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSelectedEntities = matcher;
            }

            return _matcherSelectedEntities;
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

    public Code.Gameplay.Features.Selection.SelectedEntities selectedEntities { get { return (Code.Gameplay.Features.Selection.SelectedEntities)GetComponent(GameComponentsLookup.SelectedEntities); } }
    public System.Collections.Generic.List<int> SelectedEntities { get { return selectedEntities.Value; } }
    public bool hasSelectedEntities { get { return HasComponent(GameComponentsLookup.SelectedEntities); } }

    public GameEntity AddSelectedEntities(System.Collections.Generic.List<int> newValue) {
        var index = GameComponentsLookup.SelectedEntities;
        var component = (Code.Gameplay.Features.Selection.SelectedEntities)CreateComponent(index, typeof(Code.Gameplay.Features.Selection.SelectedEntities));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSelectedEntities(System.Collections.Generic.List<int> newValue) {
        var index = GameComponentsLookup.SelectedEntities;
        var component = (Code.Gameplay.Features.Selection.SelectedEntities)CreateComponent(index, typeof(Code.Gameplay.Features.Selection.SelectedEntities));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSelectedEntities() {
        RemoveComponent(GameComponentsLookup.SelectedEntities);
        return this;
    }
}
