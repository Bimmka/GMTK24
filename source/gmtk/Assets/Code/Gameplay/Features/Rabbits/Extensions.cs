namespace Code.Gameplay.Features.Rabbits
{
    public static class Extensions
    {
        public static void RemoveWaitReplicationComponent(this GameEntity entity)
        {
            entity.isWaitingForNextReplicationUp = false;
            entity.isCanBeChosenForReplication = false;
            entity.isReplicationUp = false;
        }
    }
}