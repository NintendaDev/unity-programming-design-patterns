using Example03.GameRules;
using Example03.Infrastructure;
using Example03.Strategies;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Handlers
{
    public class LevelLoadingDataHandler : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private WinLoseStrategyChanger _winLoseStrategyChanger;
        [SerializeField] private GameRuleType _defaultRuleType;

        private LevelLoadingData _levelLoadingData;

        [Inject]
        public void Construct([InjectOptional] LevelLoadingData levelLoadingData)
        {
            _levelLoadingData = levelLoadingData;
        }

        private void Start()
        {
            if (_levelLoadingData == null)
            {
                Debug.LogWarning($"{nameof(LevelLoadingDataHandler)}: {nameof(_levelLoadingData)} is not initialized");
                _winLoseStrategyChanger.ActivateGameRule(_defaultRuleType);

                return;
            }
                
            _winLoseStrategyChanger.ActivateGameRule(_levelLoadingData.RuleType);
        }
    }
}
