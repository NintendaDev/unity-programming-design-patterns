using Example01.Arsenal;
using UnityEngine;

namespace Example01.Control
{
    [RequireComponent(typeof(WeaponChanger))]
    public class Shooter : MonoBehaviour
    {
        private IWeaponChangeEventer _weaponChangeEventer;
        private Weapon _currentWeapon;
        private bool _isSubscribed;

        public void Initialize()
        {
            _weaponChangeEventer = GetComponent<IWeaponChangeEventer>();
            Subscribe();
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