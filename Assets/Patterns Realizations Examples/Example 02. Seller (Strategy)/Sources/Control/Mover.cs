using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Example02.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3 target)
        {
            _agent.destination = target;
        }
    }
}
