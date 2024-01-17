using Example03.Accounters;
using Example03.GameRules;
using Example03.Handler;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public class WinLoseStrategyChanger : MonoBehaviour
    {
        private IWinRule _allBallsBurstWinRule;
        private IWinRule _oneColorBallBurstWinRule;
        private Level _level;

        public void Initialize(ILevelBalls levelBalls, IBurstedBalls burstedBalls, Level level)
        {
            _allBallsBurstWinRule = new AllBallsBurstWinRule(levelBalls);
            _oneColorBallBurstWinRule = new OneColorBallsBurstWinRule(levelBalls, burstedBalls);
            _level = level;
        }

        public void ActivateGameRule(GameRuleType gameRuleType)
        {
            switch(gameRuleType)
            {
                case GameRuleType.AllBallBurst:
                    SetAllBallsBurstWinRule();
                    break;

                case GameRuleType.OneColorBallsBurst:
                    SetOneColorBallBurstWinRule();
                    break;

                default:
                    SetAllBallsBurstWinRule();
                    break;
            }
        }

        [Button, DisableInEditorMode]
        private void SetAllBallsBurstWinRule()
        {
            _level.SetWinRuller(_allBallsBurstWinRule);
        }

        [Button, DisableInEditorMode]
        private void SetOneColorBallBurstWinRule()
        {
            _level.SetWinRuller(_oneColorBallBurstWinRule);
        }
    }
}
