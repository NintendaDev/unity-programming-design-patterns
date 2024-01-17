using System;
using UnityEngine;

namespace Example02.NPC
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerDetector : MonoBehaviour
    {
        private Collider _collider;

        public event Action Detected;

        public event Action Lost;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player _))
            {
                Detected?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player _))
            {
                Lost?.Invoke();
            }
        }
    }
}
