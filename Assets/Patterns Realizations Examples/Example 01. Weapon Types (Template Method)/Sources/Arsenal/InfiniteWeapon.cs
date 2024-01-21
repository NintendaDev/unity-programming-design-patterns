using Example01.Arsenal;

namespace Example01
{
    public class InfiniteWeapon : Weapon
    {
        protected sealed override bool IsPassedAdditionalShootingChecks()
        {
            return true;
        }
    }
}