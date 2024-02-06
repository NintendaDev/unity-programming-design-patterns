using UnityEngine;

namespace Example09.Spawners
{
    public class SpawnPoint<T> where T : MonoBehaviour
    {
        private T _pointObject;
        private Vector3 _position;

        public SpawnPoint(Vector3 position, T pointObject) : this(position)
        {
            _pointObject = pointObject;
        }

        public SpawnPoint(Vector3 position)
        {
            _position = position;
        }

        public bool IsEmpty => _pointObject == null;

        public Vector3 Position => _position;

        public T PointObject => _pointObject;

        public void Set(T pointObject)
        {
            _pointObject = pointObject;
        }

        public void Unset()
        {
            _pointObject = null;
        }
    }
}
