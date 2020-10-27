namespace CrossPlatformDesktopProject.PlayerStuff
{
    public interface IPlayerState
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void Attack();
        void ShootArrow();
        void UseBomb();
        void ThrowBoomerang();
        void FinishAction();
    }
}
