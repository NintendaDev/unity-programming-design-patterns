using UnityEngine;

namespace Example05.Core
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _ground = ~0;
        [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

        public bool IsTouches { get; private set; }

        private void Update()
        {
            IsTouches = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
        }
    }
}