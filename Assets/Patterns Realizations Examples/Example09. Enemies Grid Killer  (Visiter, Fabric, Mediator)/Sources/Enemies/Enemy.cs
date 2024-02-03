using System;
using UnityEngine;

namespace Example09.Enemies
{
    public abstract class Enemy: MonoBehaviour
    {
        public event Action<Enemy> Died;

        public void MoveTo(Vector3 position)
        {
            transform.position = position;
        }

        public void SetParrent(Transform parent)
        {
            transform.parent = parent;
        }

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
