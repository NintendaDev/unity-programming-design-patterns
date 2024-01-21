using Example01.Control;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example01
{
    public class ShootingBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Shooter shooter;
        [SerializeField, Required, SceneObjectsOnly] private WeaponChanger _weaponChanger;

        public void Initialize()
        {
            shooter.Initialize();
            _weaponChanger.Initialize();
        }
    }
}
