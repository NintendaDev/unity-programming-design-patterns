using System;
using UnityEngine;

namespace Example04.Characters
{
    [RequireComponent(typeof(Animator))]
    public class RobotView : MonoBehaviour
    {
        private readonly string _isWalkingParameterName = "IsWalking";
        private readonly string _isDanceParameterName = "IsDance";
        private readonly string _isSitupParameterName = "IsSitup";
        private readonly string _isIdleParameterName = "IsIdle";
        private readonly string _isMovementParameterName = "IsMovement";
        private readonly string _isRandomizeParameterName = "IsRandomize";
        private readonly string _walkAnimationName = "walking";
        private readonly string _situpAnimationName = "situp";
        private readonly string _danceAnimationName = "dance";
        private readonly string _idleAnimationName = "idle";
        private int _isWalkingParameterHash;
        private int _isDanceParameterHash;
        private int _isSitupParameterHash;
        private int _isIdleParameterHash;
        private int _isMovementParameterHash;
        private int _isRandomizeParameterHash;
        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();

            _isWalkingParameterHash = Animator.StringToHash(_isWalkingParameterName);
            _isDanceParameterHash = Animator.StringToHash(_isDanceParameterName);
            _isSitupParameterHash = Animator.StringToHash(_isSitupParameterName);
            _isIdleParameterHash = Animator.StringToHash(_isIdleParameterName);
            _isMovementParameterHash = Animator.StringToHash(_isMovementParameterName);
            _isRandomizeParameterHash = Animator.StringToHash(_isRandomizeParameterName);

            StopMoving();
            StopRandomize();
            StopIdle();
            StopWalk();
            StopDance();
            StopSitup();
        }

        public void StartMoving() => _animator.SetBool(_isMovementParameterHash, true);

        public void StopMoving() => _animator.SetBool(_isMovementParameterHash, false);

        public void StartRandomize() => _animator.SetBool(_isRandomizeParameterHash, true);

        public void StopRandomize() => _animator.SetBool(_isRandomizeParameterHash, false);

        public void StartIdle() => _animator.SetBool(_isIdleParameterHash, true);

        public void StopIdle() => _animator.SetBool(_isIdleParameterHash, false);

        public void StartWalk() => _animator.SetBool(_isWalkingParameterHash, true);

        public void StopWalk() => _animator.SetBool(_isWalkingParameterHash, false);

        public void StartDance() => _animator.SetBool(_isDanceParameterHash, true);

        public void StopDance() => _animator.SetBool(_isDanceParameterHash, false);

        public void StartSitup() => _animator.SetBool(_isSitupParameterHash, true);

        public void StopSitup() => _animator.SetBool(_isSitupParameterHash, false);

        public bool IsPlayingWalkAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimationName);
        }

        public bool IsPlayingSitupAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_situpAnimationName);
        }

        public bool IsPlayingDanceAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_danceAnimationName);
        }

        public bool IsPlayingIdleAnimation()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_idleAnimationName);
        }
    }
}
