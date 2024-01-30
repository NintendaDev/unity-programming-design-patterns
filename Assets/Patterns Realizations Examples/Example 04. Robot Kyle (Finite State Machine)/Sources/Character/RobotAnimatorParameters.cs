using UnityEngine;

namespace Example04.Characters
{
    public class RobotAnimatorParameters
    {
        private readonly string _isWalkingParameterName = "IsWalking";
        private readonly string _isDanceParameterName = "IsDance";
        private readonly string _isSitupParameterName = "IsSitup";
        private readonly string _isIdleParameterName = "IsIdle";
        private readonly string _isMovementParameterName = "IsMovement";
        private readonly string _isActionParameterName = "IsAction";
        private readonly string _walkAnimationName = "walking";
        private readonly string _situpAnimationName = "situp";
        private readonly string _danceAnimationName = "dance";
        private readonly string _idleAnimationName = "idle";

        public RobotAnimatorParameters()
        {
            IsWalkingParameterHash = Animator.StringToHash(_isWalkingParameterName);
            IsDanceParameterHash = Animator.StringToHash(_isDanceParameterName);
            IsSitupParameterHash = Animator.StringToHash(_isSitupParameterName);
            IsIdleParameterHash = Animator.StringToHash(_isIdleParameterName);
            IsMovementParameterHash = Animator.StringToHash(_isMovementParameterName);
            IsActionParameterHash = Animator.StringToHash(_isActionParameterName);
        }

        public int IsWalkingParameterHash { get; }

        public int IsDanceParameterHash { get; }

        public int IsSitupParameterHash { get; }

        public int IsIdleParameterHash { get; }

        public int IsMovementParameterHash { get; }

        public int IsActionParameterHash { get; }

        public string WalkAnimationName => _walkAnimationName;

        public string SitupAnimationName => _situpAnimationName;

        public string DanceAnimationName => _danceAnimationName;

        public string IdleAnimationName => _idleAnimationName;
    }
}
