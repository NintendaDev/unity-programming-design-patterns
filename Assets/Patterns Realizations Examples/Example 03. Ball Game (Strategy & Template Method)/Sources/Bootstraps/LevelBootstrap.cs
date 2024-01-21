using Example03.Accounters;
using Example03.Handler;
using Example03.Strategies;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private BallAccounterInitializer _ballsAccounterInitializer;
        [SerializeField, Required, SceneObjectsOnly] private WinLoseStrategyChanger _winLoseStrategyChanger;

        private Level _level;
        private BurstBallsAccounter _burstBallAccounter;

        [Inject]
        private void Constructor(Level level)
        {
            _level = level;
        }

        public void Initialize()
        {
            _ballsAccounterInitializer.Initialize();
            _burstBallAccounter = new BurstBallsAccounter(_ballsAccounterInitializer.BallsAccounter);
            _winLoseStrategyChanger.Initialize(_ballsAccounterInitializer.BallsAccounter, _burstBallAccounter, _level);
        }
    }
}
