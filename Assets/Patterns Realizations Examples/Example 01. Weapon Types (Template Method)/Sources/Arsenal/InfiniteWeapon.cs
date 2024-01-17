using Example01.Arsenal;

namespace Example01
{
    public class InfiniteWeapon : AbstractWeapon
    {
        public sealed override bool CanShoot()
        {
            return true;
        }

        protected override void DoAfterAwake()
        {
        }

        protected override void StartShootingBehaviour() 
        { 
        }
    }
}