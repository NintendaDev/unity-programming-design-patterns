using Example01.Arsenal;
using System;

namespace Example01.Control
{
    public interface IWeaponChangeEventer
    {
        public event Action<Weapon> WeaponChanged;
    }
}
