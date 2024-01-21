using System;
using UnityEngine;

namespace Example02.NPC
{
    [RequireComponent(typeof(BoxCollider))]
    public class TradableDetector : MonoBehaviour
    {
        private Collider _collider;

        public event Action<ITradable> Detected;

        public event Action<ITradable> Lost;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITradable tradableSubject))
            {
                Detected?.Invoke(tradableSubject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITradable tradableSubject))
            {
                Lost?.Invoke(tradableSubject);
            }
        }
    }
}
