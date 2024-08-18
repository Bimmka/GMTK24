//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRabbitStateMachine;

    public static Entitas.IMatcher<GameEntity> RabbitStateMachine {
        get {
            if (_matcherRabbitStateMachine == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RabbitStateMachine);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRabbitStateMachine = matcher;
            }

            return _matcherRabbitStateMachine;
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

    public Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent rabbitStateMachine { get { return (Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent)GetComponent(GameComponentsLookup.RabbitStateMachine); } }
    public Code.Gameplay.Features.Rabbits.StateMachine.Base.RabbitStateMachine RabbitStateMachine { get { return rabbitStateMachine.Value; } }
    public bool hasRabbitStateMachine { get { return HasComponent(GameComponentsLookup.RabbitStateMachine); } }

    public GameEntity AddRabbitStateMachine(Code.Gameplay.Features.Rabbits.StateMachine.Base.RabbitStateMachine newValue) {
        var index = GameComponentsLookup.RabbitStateMachine;
        var component = (Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRabbitStateMachine(Code.Gameplay.Features.Rabbits.StateMachine.Base.RabbitStateMachine newValue) {
        var index = GameComponentsLookup.RabbitStateMachine;
        var component = (Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Rabbits.RabbitStateMachineComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRabbitStateMachine() {
        RemoveComponent(GameComponentsLookup.RabbitStateMachine);
        return this;
    }
}