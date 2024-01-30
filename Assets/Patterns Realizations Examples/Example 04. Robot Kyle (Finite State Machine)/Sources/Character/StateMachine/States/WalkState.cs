using Example04.Characters.StateMachine.States.Action;
using Example04.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Example04.Characters.StateMachine.States
{
    public class WalkState : MovementState
    {
        private Queue<Transform> _patrolPoints;
        private Mover _mover;
        private MethodInfo _switchStateMethod;
        private List<Type> _actionStatesTypes;
        private Transform _currentMovePoint;
        private bool _startMove;
        private System.Random _random = new();

        public WalkState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
            if (robot.PatrolPoints.Count == 0)
                throw new Exception("Robot does not have a point for movement");

            _patrolPoints = new Queue<Transform>(robot.PatrolPoints);
            _mover = robot.Mover;

            Type objectType = GetType();
            _switchStateMethod = objectType.GetMethod(nameof(SwitchState), BindingFlags.NonPublic | BindingFlags.Instance);

            if (_switchStateMethod == null)
                throw new Exception($"Failed to get {nameof(SwitchState)} method through reflection");

            _actionStatesTypes = new List<Type>
            {
                typeof(IdleState),
                typeof(DanceState),
                typeof(SitupState),
            };
        }

        public override void Enter()
        {
            base.Enter();
            View.StartWalk();
        }

        public override void Exit()
        {
            base.Exit();
            StopMove();
            View.StopWalk();
        }

        public override void Update()
        {
            base.Update();

            if (_startMove == false && View.IsPlayingWalkAnimation())
                Move();

            if (_startMove && _mover.HasReachedTarget)
                SwitchRandomActionState();
        }

        private void Move()
        {
            ChangeMovePoint();
            Move(_currentMovePoint.position);
        }

        private void ChangeMovePoint()
        {
            if (_currentMovePoint != null)
                _patrolPoints.Enqueue(_currentMovePoint);

            _currentMovePoint = _patrolPoints.Dequeue();
        }

        protected void Move(Vector3 target)
        {
            _mover.Move(target);
            _startMove = true;
        }

        protected void StopMove()
        {
            _mover.Stop();
            _startMove = false;
        }

        private void SwitchRandomActionState()
        {
            int randomStateIndex = _random.Next(_actionStatesTypes.Count());
            Type nextActionStateType =_actionStatesTypes.ElementAt(randomStateIndex);
            MethodInfo switchStateGeneric = _switchStateMethod.MakeGenericMethod(nextActionStateType);
            switchStateGeneric.Invoke(this, null);
        }
    }
}