using MonoUtils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Arsenal
{
    public abstract class Weapon : InitializedMonobehaviour
    {
        [SerializeField, Required, MinValue(0), Unit(Units.Second)] private float _shootDelay = 0.2f;
        [SerializeField, Required, InlineEditor] private BulletSettings _bulletSettings;

        private BulletsPool _bulletsPool;
        private float _shootTimer;

        private bool IsTooFastShooting => _shootTimer < _shootDelay;

        public void Initialize()
        {
            _bulletsPool = new BulletsPool(_bulletSettings.Prefab, transform);
            InitializeAdditionaly();

            CompleteInitialization();
        }

        private void Update()
        {
            UpdateTimers();
        }

        public bool CanShoot()
        {
            return IsTooFastShooting == false && IsPassedAdditionalShootingChecks();
        }

        [Button, DisableInEditorMode]
        public void Shoot()
        {
            if (CanShoot() == false)
                return;

            _shootTimer = 0;
            StartShootingBehaviour();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        protected virtual void InitializeAdditionaly()
        {
        }

        protected virtual bool IsPassedAdditionalShootingChecks()
        {
            return true;
        }

        protected virtual void StartShootingBehaviour()
        {
        }

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