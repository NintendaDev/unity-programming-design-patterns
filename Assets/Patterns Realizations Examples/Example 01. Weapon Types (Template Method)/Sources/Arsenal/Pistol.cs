using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Arsenal
{
    public class Pistol : FiniteWeapon
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Transform _shootPoint;

        private readonly int _bulletsPerShoot = 1;

        protected override void DoAfterAwake()
        {
            Initialize(_bulletsPerShoot);
        }

        protected override void DoShootAction()
        {
            InstantiateBullet(_shootPoint);
        }
    }
}
