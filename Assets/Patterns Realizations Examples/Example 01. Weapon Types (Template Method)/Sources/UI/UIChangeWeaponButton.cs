using Example01.Control;

namespace Example01.UI
{
    public class UIChangeWeaponButton : UIButtonAbstract
    {
        private WeaponChanger _weaponChanger;

        public void Initialize(WeaponChanger weaponChanger)
        {
            _weaponChanger = weaponChanger;
        }

        protected override void OnButtonClick()
        {
            _weaponChanger.ChangeWeapon();
        }
    }
}
