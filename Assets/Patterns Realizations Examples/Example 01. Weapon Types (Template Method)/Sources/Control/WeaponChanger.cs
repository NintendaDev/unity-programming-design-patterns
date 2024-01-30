using Example01.Arsenal;
using MonoUtils;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Example01.Control
{
    public class WeaponChanger : InitializedMonoBehaviour, IWeaponChangeEventer
    {
        [RequiredListLength(1, null)]
        [SerializeField] private List<Weapon> _weapons;

        private Queue<Weapon> _weaponsQueue;

        public event Action<Weapon> WeaponChanged;

        public Weapon CurrentWeapon { get; private set; }

        public void Initialize()
        {
            InitializeWeaponQueue();
            ChangeWeapon();

            CompleteInitialization();
        }

        [Button, DisableInEditorMode]
        public void ChangeWeapon()
        {
            if (CurrentWeapon != null)
            {
                CurrentWeapon.Disable();
                _weaponsQueue.Enqueue(CurrentWeapon);
            }
                
            CurrentWeapon = _weaponsQueue.Dequeue();
            CurrentWeapon.Enable();
            WeaponChanged?.Invoke(CurrentWeapon);
        }

        private void InitializeWeaponQueue()
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon.Initialize();
                weapon.Disable();
            }
                
            _weaponsQueue = new Queue<Weapon>(_weapons);
        }
    }
}
