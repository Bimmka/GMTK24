//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSavedPositionBeforeDrag;

    public static Entitas.IMatcher<GameEntity> SavedPositionBeforeDrag {
        get {
            if (_matcherSavedPositionBeforeDrag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SavedPositionBeforeDrag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSavedPositionBeforeDrag = matcher;
            }

            return _matcherSavedPositionBeforeDrag;
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

    public Code.Gameplay.Features.Selection.SavedPositionBeforeDrag savedPositionBeforeDrag { get { return (Code.Gameplay.Features.Selection.SavedPositionBeforeDrag)GetComponent(GameComponentsLookup.SavedPositionBeforeDrag); } }
    public UnityEngine.Vector3 SavedPositionBeforeDrag { get { return savedPositionBeforeDrag.Value; } }
    public bool hasSavedPositionBeforeDrag { get { return HasComponent(GameComponentsLookup.SavedPositionBeforeDrag); } }

    public GameEntity AddSavedPositionBeforeDrag(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.SavedPositionBeforeDrag;
        var component = (Code.Gameplay.Features.Selection.SavedPositionBeforeDrag)CreateComponent(index, typeof(Code.Gameplay.Features.Selection.SavedPositionBeforeDrag));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSavedPositionBeforeDrag(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.SavedPositionBeforeDrag;
        var component = (Code.Gameplay.Features.Selection.SavedPositionBeforeDrag)CreateComponent(index, typeof(Code.Gameplay.Features.Selection.SavedPositionBeforeDrag));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSavedPositionBeforeDrag() {
        RemoveComponent(GameComponentsLookup.SavedPositionBeforeDrag);
        return this;
    }
}
