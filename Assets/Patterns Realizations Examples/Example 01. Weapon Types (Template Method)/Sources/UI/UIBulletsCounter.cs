using Example01.Arsenal;
using Example01.Control;
using MonoUtils;
using Nova;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.UI
{
    public class UIBulletsCounter : InitializedMonobehaviour
    {
        [SerializeField, Required] private TextBlock _bulletCounterText;

        private readonly string _infiniteBulletsMessage = "Infinite";
        private WeaponChanger _weaponChanger;
        private bool _isSubscribed;

        public void Initialize(WeaponChanger weaponChanger)
        {
            _weaponChanger = weaponChanger;
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

        private void Subscribe()
        {
            if (_isSubscribed)
                return;

            _weaponChanger.WeaponChanged += OnWeaponChanged;
            _isSubscribed = true;
        }

        private void OnWeaponChanged(Weapon currentWeapon)
        {
            if (currentWeapon is FiniteWeapon lastFiniteWeapon)
                lastFiniteWeapon.MagazineChanged -= OnWeaponChamberChange;

            if (_weaponChanger.CurrentWeapon is FiniteWeapon currentFiniteWeapon)
            {
                OnWeaponChamberChange(currentFiniteWeapon.BulletsInMagazine);
                currentFiniteWeapon.MagazineChanged += OnWeaponChamberChange;
            } 
            else
            {
                _bulletCounterText.Text = _infiniteBulletsMessage;
            }
        }

        private void OnWeaponChamberChange(int bulletsCount)
        {
            _bulletCounterText.Text = bulletsCount.ToString();
        }

        private void Unsubscribe()
        {
            if (_isSubscribed == false)
                return;

            _weaponChanger.WeaponChanged -= OnWeaponChanged;
            _isSubscribed = false;
        }
    }
}
