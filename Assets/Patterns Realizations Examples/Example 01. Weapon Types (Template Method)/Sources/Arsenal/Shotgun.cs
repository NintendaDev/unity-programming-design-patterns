using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Arsenal
{
    public class Shotgun : FiniteWeapon
    {
        [RequiredListLength(1, null)]
        [SerializeField, ChildGameObjectsOnly] private Transform[] _shootPoints;

        protected override void InitializeAdditionaly()
        {
            Initialize(_shootPoints.Length);
        }

        protected override void DoShootAction()
        {
            foreach (Transform shootPoint in _shootPoints)
                InstantiateBullet(shootPoint);
        }
    }
}