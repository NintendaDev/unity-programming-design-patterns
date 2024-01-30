using MonoUtils;
using System;
using UnityEngine;

namespace Example02.NPC
{
    [RequireComponent(typeof(BoxCollider))]
    public class TradableDetector : InitializedMonoBehaviour
    {
        private Collider _collider;

        public event Action<ITradable> Detected;

        public event Action<ITradable> Lost;

        public void Initialize()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;

            CompleteInitialization();
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
