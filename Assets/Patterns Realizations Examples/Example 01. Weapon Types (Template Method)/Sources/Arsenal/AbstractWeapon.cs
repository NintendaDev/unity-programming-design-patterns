using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Arsenal
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField, Required, MinValue(0), Unit(Units.Second)] private float _shootDelay = 0.2f;
        [SerializeField, Required, InlineEditor] private BulletSettings _bulletSettings;

        private BulletsPool _bulletsPool;
        private float _shootTimer;

        private bool IsTooFastShooting => _shootTimer < _shootDelay;

        private void Awake()
        {
            _bulletsPool = new BulletsPool(_bulletSettings.Prefab, transform);
            DoAfterAwake();
        }

        private void Update()
        {
            UpdateTimers();
        }

        public abstract bool CanShoot();

        [Button, DisableInEditorMode]
        public void Shoot()
        {
            if (CanShoot() == false || IsTooFastShooting)
                return;

            _shootTimer = 0;
            StartShootingBehaviour();
        }

        protected abstract void DoAfterAwake();

        protected abstract void StartShootingBehaviour();

        protected void InstantiateBullet(Transform shootPoint)
        {
            Bullet bullet = _bulletsPool.Pool();
            bullet.Initialize(_bulletSettings, shootPoint.position, shootPoint.forward, _bulletsPool);
        }

        private void UpdateTimers()
        {
            _shootTimer += Time.deltaTime;
        }
    }
}