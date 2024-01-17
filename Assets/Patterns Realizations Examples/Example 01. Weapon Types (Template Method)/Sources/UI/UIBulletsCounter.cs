using Example01.Arsenal;
using Example01.Control;
using Nova;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;

namespace Example01
{
    public class UIBulletsCounter : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private WeaponChanger _weaponChanger;
        [SerializeField, Required] private TextBlock _bulletCounterText;

        private readonly string _infiniteBulletsMessage = "Infinite";
        private AbstractWeapon _currentWeapon;

        private void OnEnable()
        {
            _weaponChanger.Changed += OnWeaponChanged;
        }

        private void OnDisable()
        {
            _weaponChanger.Changed -= OnWeaponChanged;
        }

        private void OnWeaponChanged(AbstractWeapon currentWeapon)
        {
            if (currentWeapon is FiniteWeapon lastFiniteWeapon)
                lastFiniteWeapon.ChamberChanged -= OnWeaponChamberChange;

            if (_weaponChanger.CurrentWeapon is FiniteWeapon currentFiniteWeapon)
            {
                OnWeaponChamberChange(currentFiniteWeapon.BulletsInChamber);
                currentFiniteWeapon.ChamberChanged += OnWeaponChamberChange;
                _currentWeapon = currentWeapon;
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
    }
}
