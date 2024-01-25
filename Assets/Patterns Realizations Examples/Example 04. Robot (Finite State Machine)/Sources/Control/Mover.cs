using UnityEngine;
using UnityEngine.AI;

namespace Example04.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private bool _isInitialized;

        public void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _isInitialized = true;
        }

        public void Move(Vector3 target)
        {
            _agent.destination = target;
        }

        private void ValidateInitialization()
        {
            if (_isInitialized == false)
                throw new System.Exception($"{nameof(Mover)} is not initialized");
        }
    }
}