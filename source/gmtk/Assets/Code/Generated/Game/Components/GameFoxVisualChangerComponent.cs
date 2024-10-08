//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFoxVisualChanger;

    public static Entitas.IMatcher<GameEntity> FoxVisualChanger {
        get {
            if (_matcherFoxVisualChanger == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FoxVisualChanger);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFoxVisualChanger = matcher;
            }

            return _matcherFoxVisualChanger;
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

    public Code.Gameplay.Features.Foxes.FoxVisualChangerComponent foxVisualChanger { get { return (Code.Gameplay.Features.Foxes.FoxVisualChangerComponent)GetComponent(GameComponentsLookup.FoxVisualChanger); } }
    public Code.Gameplay.Features.Foxes.Behaviours.Visuals.FoxVisualChanger FoxVisualChanger { get { return foxVisualChanger.Value; } }
    public bool hasFoxVisualChanger { get { return HasComponent(GameComponentsLookup.FoxVisualChanger); } }

    public GameEntity AddFoxVisualChanger(Code.Gameplay.Features.Foxes.Behaviours.Visuals.FoxVisualChanger newValue) {
        var index = GameComponentsLookup.FoxVisualChanger;
        var component = (Code.Gameplay.Features.Foxes.FoxVisualChangerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Foxes.FoxVisualChangerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceFoxVisualChanger(Code.Gameplay.Features.Foxes.Behaviours.Visuals.FoxVisualChanger newValue) {
        var index = GameComponentsLookup.FoxVisualChanger;
        var component = (Code.Gameplay.Features.Foxes.FoxVisualChangerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Foxes.FoxVisualChangerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveFoxVisualChanger() {
        RemoveComponent(GameComponentsLookup.FoxVisualChanger);
        return this;
    }
}
