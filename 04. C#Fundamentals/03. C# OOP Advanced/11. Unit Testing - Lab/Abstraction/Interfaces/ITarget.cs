namespace Skeleton.Abstraction.Interfaces
{
    public interface ITarget
    {
        int Health { get; }

        int GiveExperience();

        bool IsDead();

        void TakeAttack(int attackPoints);
    }
}
