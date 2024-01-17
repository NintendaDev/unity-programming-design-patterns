using Example01.Arsenal;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Example01.Control
{
    public class WeaponChanger : MonoBehaviour, ICurrentWeapon
    {
        [RequiredListLength(1, null)]
        [SerializeField] private List<AbstractWeapon> _weapons;

        private Queue<AbstractWeapon> _weaponsQueue;

        public event Action<AbstractWeapon> Changed;

        public AbstractWeapon CurrentWeapon { get; private set; }

        private void Awake()
        {
            InitializeWeaponQueue();
            ChangeWeapon();
        }

        [Button, DisableInEditorMode]
        public void ChangeWeapon()
        {
            if (CurrentWeapon != null)
            {
                CurrentWeapon.gameObject.SetActive(false);
                _weaponsQueue.Enqueue(CurrentWeapon);
            }
                
            CurrentWeapon = _weaponsQueue.Dequeue();
            CurrentWeapon.gameObject.SetActive(true);
            Changed?.Invoke(CurrentWeapon);
        }

        private void InitializeWeaponQueue()
        {
            foreach (AbstractWeapon weapon in _weapons)
                weapon.gameObject.SetActive(false);

            _weaponsQueue = new Queue<AbstractWeapon>(_weapons);
        }
    }
}
