using Example01.Arsenal;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example01
{
    public class FiniteWeapon : AbstractWeapon
    {
        [SerializeField, Required, MinValue(0)] private int _bulletsInChamber = 30;

        private const int MinBulletsPerShoot = 1;
        private int _bulletsPerShoot;
        private bool _isInitialized;

        public event Action<int> ChamberChanged;

        public int BulletsInChamber => _bulletsInChamber;

        protected bool IsInitialized => _isInitialized;

        public void Initialize(int bulletsPerShoot)
        {
            if (bulletsPerShoot < MinBulletsPerShoot)
                throw new System.Exception($"Минимум пуль за выстрел: {MinBulletsPerShoot}");

            _bulletsPerShoot = bulletsPerShoot;
            _isInitialized = true;
        }

        public sealed override bool CanShoot()
        {
            return _bulletsInChamber > 0 && _bulletsInChamber >= _bulletsPerShoot;
        }

        protected override void DoAfterAwake()
        {
        }

        protected sealed override void StartShootingBehaviour()
        {
            if (_bulletsInChamber < 0)
                throw new System.Exception("Отсутствуют пули в обойме");

            if (_bulletsInChamber < _bulletsPerShoot)
                throw new System.Exception("не хватает пуль для выстрела");

            DoShootAction();
            _bulletsInChamber -= _bulletsPerShoot;
            ChamberChanged?.Invoke(_bulletsInChamber);
        }

        protected virtual void DoShootAction() 
        { 
        }
    }
}
