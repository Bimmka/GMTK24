namespace Code.Gameplay.Features.Rabbits
{
    public static class Extensions
    {
        public static void RemoveWaitReplicationComponent(this GameEntity entity)
        {
            entity.isWaitingForNextReplicationUp = false;
            entity.isCanBeChosenForReplication = false;
            entity.isCanStartReplication = false;
        }
        
        public static void ChangeComponentsForStartReplication(this GameEntity entity)
        {
            entity.isReplicating = true;
            entity.isMovementAvailable = false;
            entity.isWaitingForMoving = false;
            entity.isSelectable = false;
            entity.isWantToReplicate = false;
            entity.isMovingToReplicationTarget = false;
        }
    }
}