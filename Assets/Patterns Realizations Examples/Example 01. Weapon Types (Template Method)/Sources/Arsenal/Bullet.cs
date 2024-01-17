using UnityEngine;

namespace Example01.Arsenal
{
    public class Bullet : MonoBehaviour
    {
        private IBulletTemporaryProperties _temporaryProperties;
        private BulletsPool _pool;
        private bool _isInitialized;
        private Transform _transform;
        private float _lifeTime;

        public void Initialize(IBulletTemporaryProperties temporaryProperties, Vector3 startPoint, Vector3 direction, BulletsPool pool)
        {
            _transform = transform;

            _temporaryProperties = temporaryProperties;
            _transform.position = startPoint;
            _transform.forward = direction;
            _pool = pool;
            _lifeTime = 0;
            _isInitialized = true;
        }

        private void Reset()
        {
            _isInitialized = false;
        }

        private void Update()
        {
            if (_isInitialized == false)
                return;

            Move();
            UpdateTimers();

            if (_lifeTime > _temporaryProperties.MaxLifeTime)
                Die();
        }

        private void Move()
        {
            _transform.position += _transform.forward * _temporaryProperties.Speed * Time.deltaTime;
        }

        private void UpdateTimers()
        {
            _lifeTime += Time.deltaTime;
        }

        private void Die()
        {
            Reset();
            _pool.Put(this);
        }
    }
}
