using Example04.Characters.StateMachine;
using Example04.Control;
using Example04.Core;
using MonoUtils;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Example04.Characters
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(RobotView))]
    public class Robot : InitializedMonobehaviour
    {
        [SerializeField, Required] private RobotView _view;
        [SerializeField, Required] private Vector2 _minMaxRandomStateTime = new Vector2(3, 5);

        private PatrolPointsInitializer _pointsInitializer;
        private RobotStateMachine _stateMachine;
        private Mover _mover;

        public Mover Mover => _mover;

        public RobotView View => _view;

        public IReadOnlyList<Transform> PatrolPoints => _pointsInitializer.Points;

        public Vector2 MinMaxRandomStateTime => _minMaxRandomStateTime;

        public void Initialize(PatrolPointsInitializer pointsInitializer)
        {
            _pointsInitializer = pointsInitializer;
            _pointsInitializer.Initialize();

            _mover = GetComponent<Mover>();
            _mover.Initialize();

            View.Initialize();

            _stateMachine = new RobotStateMachine(this);

            CompleteInitialization();
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}