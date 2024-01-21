using Example01.Arsenal;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example01
{
    public class FiniteWeapon : Weapon
    {
        [SerializeField, Required, MinValue(0)] private int _bulletsInMagazine = 30;

        private const int MinBulletsPerShoot = 1;
        private int _bulletsPerShoot;
        private bool _isInitializedBulletsPerShoot;

        public event Action<int> MagazineChanged;

        public int BulletsInMagazine => _bulletsInMagazine;

        protected void Initialize(int bulletsPerShoot)
        {
            if (bulletsPerShoot < MinBulletsPerShoot)
                throw new Exception($"Minimum bullets per shot: {MinBulletsPerShoot}");

            _bulletsPerShoot = bulletsPerShoot;
            _isInitializedBulletsPerShoot = true;
        }

        protected sealed override bool IsPassedAdditionalShootingChecks()
        {
            return _bulletsInMagazine > 0 && _bulletsInMagazine >= _bulletsPerShoot;
        }

        protected sealed override void StartShootingBehaviour()
        {
            if (_isInitializedBulletsPerShoot == false)
                throw new Exception("The number of bullets in the magazine is not initialized");

            if (_bulletsInMagazine < 0)
                throw new Exception("No bullets in the magazine");

            if (_bulletsInMagazine < _bulletsPerShoot)
                throw new Exception("Not enough bullets for a shot");

            DoShootAction();

            _bulletsInMagazine -= _bulletsPerShoot;
            MagazineChanged?.Invoke(_bulletsInMagazine);
        }

        protected virtual void DoShootAction() 
        { 
        }
    }
}
