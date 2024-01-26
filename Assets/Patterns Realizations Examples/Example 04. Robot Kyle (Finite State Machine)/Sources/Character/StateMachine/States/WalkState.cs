using Example04.Control;
using System.Collections.Generic;
using UnityEngine;

namespace Example04.Characters.StateMachine.States
{
    public class WalkState : MovementState
    {
        private Queue<Transform> _patrolPoints;
        private Mover _mover;
        private Transform _currentMovePoint;
        private bool _startMove;

        public WalkState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
            if (robot.PatrolPoints.Count == 0)
                throw new System.Exception("Robot does not have a point for movement");

            _patrolPoints = new Queue<Transform>(robot.PatrolPoints);
            _mover = robot.Mover;
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
                SwitchRandomState();
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
    }
}
