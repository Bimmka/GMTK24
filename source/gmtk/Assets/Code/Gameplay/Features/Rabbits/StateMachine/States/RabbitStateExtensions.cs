namespace Code.Gameplay.Features.Rabbits.StateMachine.States
{
    public static class RabbitStateExtensions
    {
        public static void ChangeStateToIdle(this GameEntity rabbit)
        {
            rabbit.isIdleState = true;
            rabbit.isStupidMoveState = false;
            rabbit.isAngryState = false;
            rabbit.isReplicationState = false;
            rabbit.isDeadState = false;
            rabbit.isDraggingState = false;
        }
        
        public static void ChangeStateToStupidMove(this GameEntity rabbit)
        {
            rabbit.isIdleState = false;
            rabbit.isStupidMoveState = true;
            rabbit.isAngryState = false;
            rabbit.isReplicationState = false;
            rabbit.isDeadState = false;
            rabbit.isDraggingState = false;
        }
        
        public static void ChangeStateToAngry(this GameEntity rabbit)
        {
            rabbit.isIdleState = false;
            rabbit.isStupidMoveState = false;
            rabbit.isAngryState = true;
            rabbit.isReplicationState = false;
            rabbit.isDeadState = false;
            rabbit.isDraggingState = false;
        }
        
        public static void ChangeStateToReplication(this GameEntity rabbit)
        {
            rabbit.isIdleState = false;
            rabbit.isStupidMoveState = false;
            rabbit.isAngryState = false;
            rabbit.isReplicationState = true;
            rabbit.isDeadState = false;
            rabbit.isDraggingState = false;
        }
        
        public static void ChangeStateToDead(this GameEntity rabbit)
        {
            rabbit.isIdleState = false;
            rabbit.isStupidMoveState = false;
            rabbit.isAngryState = false;
            rabbit.isReplicationState = false;
            rabbit.isDeadState = true;
            rabbit.isDraggingState = false;
        }
        
        public static void ChangeStateToDragging(this GameEntity rabbit)
        {
            rabbit.isIdleState = false;
            rabbit.isStupidMoveState = false;
            rabbit.isAngryState = false;
            rabbit.isReplicationState = false;
            rabbit.isDeadState = false;
            rabbit.isDraggingState = true;
        }
    }
}