using Example01.Arsenal;
using MonoUtils;
using UnityEngine;

namespace Example01.Control
{
    [RequireComponent(typeof(WeaponChanger))]
    public sealed class Shooter : InitializedMonoBehaviour
    {
        private IWeaponChangeEventer _weaponChangeEventer;
        private Weapon _currentWeapon;
        private bool _isSubscribed;

        public void Initialize()
        {
            _weaponChangeEventer = GetComponent<IWeaponChangeEventer>();
            Subscribe();

            CompleteInitialization();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void Shoot()
        {
            _currentWeapon.Shoot();
        }

        private void Subscribe()
        {
            if (_isSubscribed)
                return;

            _weaponChangeEventer.WeaponChanged += OnWeaponChange;
            _isSubscribed = true;
        }

        private void OnWeaponChange(Weapon changedWeapon)
        {
            _currentWeapon = changedWeapon;
        }

        private void Unsubscribe()
        {
            if (_isSubscribed == false)
                return;

            _weaponChangeEventer.WeaponChanged -= OnWeaponChange;
            _isSubscribed = false;
        }
    }
}