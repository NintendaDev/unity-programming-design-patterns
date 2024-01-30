using MonoUtils;
using UnityEngine;
using UnityEngine.AI;

namespace Example02.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : InitializedMonoBehaviour
    {
        private NavMeshAgent _agent;

        public void Initalize()
        {
            _agent = GetComponent<NavMeshAgent>();

            CompleteInitialization();
        }

        public void Move(Vector3 target)
        {
            _agent.destination = target;
        }
    }
}
