using Example04.Characters.StateMachine;
using Example04.Control;
using Example04.Core;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Example04.Characters
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(RobotView))]
    public class Robot : MonoBehaviour
    {
        [SerializeField, Required] private PatrolPointsInitializer _pointsInitializer;
        [SerializeField, Required] private Vector2 _minMaxRandomStateTime = new Vector2(3, 5);

        private RobotStateMachine _stateMachine;
        private Mover _mover;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _pointsInitializer.Initialize();

            _mover = GetComponent<Mover>();
            _mover.Initialize();

            View = GetComponent<RobotView>();
            View.Initialize();

            _stateMachine = new RobotStateMachine(this);
        }

        public Mover Mover => _mover;

        public RobotView View { get; private set; }

        public IReadOnlyList<Transform> PatrolPoints => _pointsInitializer.Points;

        public Vector2 MinMaxRandomStateTime => _minMaxRandomStateTime;

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}