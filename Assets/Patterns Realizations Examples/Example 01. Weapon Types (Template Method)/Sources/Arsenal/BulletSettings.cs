using Example01.Arsenal;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01
{
    [CreateAssetMenu(fileName = "new BulletSettings", menuName = "Bullet Settings")]
    public class BulletSettings : ScriptableObject, IBulletTemporaryProperties
    {
        [SerializeField, Required] private Bullet _prefab;
        [SerializeField, Required, MinValue(0)] private float _speed = 30f;
        [SerializeField, Required, MinValue(0)] private float _maxLifeTime = 5f;

        public Bullet Prefab => _prefab;

        public float Speed => _speed;

        public float MaxLifeTime => _maxLifeTime;
    }
}
