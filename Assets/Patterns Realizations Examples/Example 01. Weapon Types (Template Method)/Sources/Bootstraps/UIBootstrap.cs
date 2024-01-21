using Example01.Control;
using Example01.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private UIShootButton _uiShootButton;
        [SerializeField, Required, SceneObjectsOnly] private UIChangeWeaponButton _uiChangeWeaponButton;
        [SerializeField, Required, SceneObjectsOnly] private UIBulletsCounter _uiBulletsCounter;
        [SerializeField, Required, SceneObjectsOnly] private Shooter _shooter;
        [SerializeField, Required, SceneObjectsOnly] private WeaponChanger _weaponChanger;

        public void Initialize()
        {
            _uiShootButton.Initialize(_shooter);
            _uiChangeWeaponButton.Initialize(_weaponChanger);
            _uiBulletsCounter.Initialize(_weaponChanger);
        }
    }
}