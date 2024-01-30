using MonoUtils;
using UnityEngine;
using UnityEngine.AI;

namespace Example04.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : InitializedMonobehaviour
    {
        private Transform _transform;
        private NavMeshAgent _agent;

        public bool HasReachedTarget => Vector3.Distance(_agent.destination, _transform.position) < 0.01;

        public bool IsStopped => _agent.isStopped;

        public void Initialize()
        {
            _transform = transform;
            _agent = GetComponent<NavMeshAgent>();

            CompleteInitialization();
        }

        public void Move(Vector3 target)
        {
            _agent.isStopped = false;
            _agent.destination =target;
        }

        public void Stop()
        {
            _agent.isStopped = true;
            _agent.ResetPath();
        }
    }
}