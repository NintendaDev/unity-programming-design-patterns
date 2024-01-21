using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Arsenal
{
    public sealed class InfinitePistol : InfiniteWeapon
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Transform _shootPoint;

        protected override void StartShootingBehaviour()
        {
            InstantiateBullet(_shootPoint);
        }
    }
}