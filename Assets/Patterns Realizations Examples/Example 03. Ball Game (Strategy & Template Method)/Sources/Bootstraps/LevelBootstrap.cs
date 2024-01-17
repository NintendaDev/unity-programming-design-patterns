using Example03.Accounters;
using Example03.Handler;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Level _level;
        [SerializeField, Required, SceneObjectsOnly] private BallsAccounter _ballsAccounter;
        [SerializeField, Required, SceneObjectsOnly] private BurstBallsAccounter _burstBallsAccounter;
        [SerializeField, Required, SceneObjectsOnly] private WinLoseStrategyChanger _winLoseStrategyChanger;

        public void Initialize()
        {
            _level.Initialize(_burstBallsAccounter);
            _winLoseStrategyChanger.Initialize(_ballsAccounter, _burstBallsAccounter, _level);
        }
    }
}
