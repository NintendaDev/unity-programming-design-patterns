using MonoUtils;
using UnityEngine;

namespace Example04.Characters
{
    [RequireComponent(typeof(Animator))]
    public class RobotView : InitializedMonobehaviour
    {
        private RobotAnimatorParameters _animatorParameters = new();
        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();

            StopMoving();
            StopAction();
            StopIdle();
            StopWalk();
            StopDance();
            StopSitup();

            CompleteInitialization();
        }

        public void StartMoving() => _animator.SetBool(_animatorParameters.IsMovementParameterHash, true);

        public void StopMoving() => _animator.SetBool(_animatorParameters.IsMovementParameterHash, false);

        public void StartAction() => _animator.SetBool(_animatorParameters.IsActionParameterHash, true);

        public void StopAction() => _animator.SetBool(_animatorParameters.IsActionParameterHash, false);

        public void StartIdle() => _animator.SetBool(_animatorParameters.IsIdleParameterHash, true);

        public void StopIdle() => _animator.SetBool(_animatorParameters.IsIdleParameterHash, false);

        public void StartWalk() => _animator.SetBool(_animatorParameters.IsWalkingParameterHash, true);

        public void StopWalk() => _animator.SetBool(_animatorParameters.IsWalkingParameterHash, false);

        public void StartDance() => _animator.SetBool(_animatorParameters.IsDanceParameterHash, true);

        public void StopDance() => _animator.SetBool(_animatorParameters.IsDanceParameterHash, false);

        public void StartSitup() => _animator.SetBool(_animatorParameters.IsSitupParameterHash, true);

        public void StopSitup() => _animator.SetBool(_animatorParameters.IsSitupParameterHash, false);

        public bool IsPlayingWalkAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_animatorParameters.WalkAnimationName);
        }

        public bool IsPlayingSitupAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_animatorParameters.SitupAnimationName);
        }

        public bool IsPlayingDanceAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_animatorParameters.DanceAnimationName);
        }

        public bool IsPlayingIdleAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_animatorParameters.IdleAnimationName);
        }
    }
}
