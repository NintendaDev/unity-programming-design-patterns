using UnityEngine;

namespace Example01.Control
{
    public class Shooter : MonoBehaviour
    {
        private ICurrentWeapon _currentWeapon;

        private void Awake()
        {
            _currentWeapon = GetComponent<ICurrentWeapon>();
        }

        public void Shoot()
        {
            if (_currentWeapon == null)
                throw new System.ArgumentNullException($"�� ���������������� �������� {nameof(_currentWeapon)}");

            _currentWeapon.CurrentWeapon.Shoot();
        }
    }
}