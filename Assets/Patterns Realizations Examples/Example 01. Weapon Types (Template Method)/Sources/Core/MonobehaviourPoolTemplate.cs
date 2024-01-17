using System.Collections.Generic;
using UnityEngine;

namespace Example01.Core
{
    public class MonobehaviourPoolTemplate<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Transform _createPoint;
        private Queue<T> _pool = new Queue<T>();

        public MonobehaviourPoolTemplate(T prefab, Transform createPoint)
        {
            _prefab = prefab;
            _createPoint = createPoint;
        }

        public T Pool()
        {
            T poolObject;

            if (_pool.Count == 0)
                poolObject = InstantiateObject();
            else
                poolObject = _pool.Dequeue();

            poolObject.transform.position = _createPoint.position;
            poolObject.gameObject.SetActive(true);

            return poolObject;
        }

        public void Put(T poolObject)
        {
            if (_pool.Contains(poolObject) == false)
            {
                poolObject.gameObject.SetActive(false);
                _pool.Enqueue(poolObject);
            }
        }

        private T InstantiateObject()
        {
            return Object.Instantiate(_prefab, _createPoint.position, _createPoint.rotation, _createPoint);
        }
    }
}
