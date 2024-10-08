//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameTaskStatusPanel;

    public static Entitas.IMatcher<GameEntity> GameTaskStatusPanel {
        get {
            if (_matcherGameTaskStatusPanel == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameTaskStatusPanel);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameTaskStatusPanel = matcher;
            }

            return _matcherGameTaskStatusPanel;
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

    public Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent gameTaskStatusPanel { get { return (Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent)GetComponent(GameComponentsLookup.GameTaskStatusPanel); } }
    public Code.Gameplay.Windows.Windows.Game.GameTaskStatusPanel GameTaskStatusPanel { get { return gameTaskStatusPanel.Value; } }
    public bool hasGameTaskStatusPanel { get { return HasComponent(GameComponentsLookup.GameTaskStatusPanel); } }

    public GameEntity AddGameTaskStatusPanel(Code.Gameplay.Windows.Windows.Game.GameTaskStatusPanel newValue) {
        var index = GameComponentsLookup.GameTaskStatusPanel;
        var component = (Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceGameTaskStatusPanel(Code.Gameplay.Windows.Windows.Game.GameTaskStatusPanel newValue) {
        var index = GameComponentsLookup.GameTaskStatusPanel;
        var component = (Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent)CreateComponent(index, typeof(Code.Gameplay.Features.LevelTasks.GameTaskStatusPanelComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveGameTaskStatusPanel() {
        RemoveComponent(GameComponentsLookup.GameTaskStatusPanel);
        return this;
    }
}
