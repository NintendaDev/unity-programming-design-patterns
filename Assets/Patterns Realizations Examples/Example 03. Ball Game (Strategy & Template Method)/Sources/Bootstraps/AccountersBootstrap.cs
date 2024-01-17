using Example03.Accounters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03.Bootstraps
{
    public class AccountersBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private BallsAccounter _ballsAccounter;
        [SerializeField, Required, SceneObjectsOnly] private BurstBallsAccounter _burstBallsAccounter;

        public void Initialize()
        {
            _ballsAccounter.Initialize();
            _burstBallsAccounter.Initialize(_ballsAccounter.CurrentBalls);
        }
    }
}
