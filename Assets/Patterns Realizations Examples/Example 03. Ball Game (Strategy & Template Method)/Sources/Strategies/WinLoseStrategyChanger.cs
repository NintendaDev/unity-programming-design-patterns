using Example03.Accounters;
using Example03.Core;
using Example03.GameRules;
using Example03.Handlers;
using MonoUtils;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Zenject;

namespace Example03.Strategies
{
    public class WinLoseStrategyChanger : InitializedMonoBehaviour, IRestart
    {
        private IWinLoseCondition _allBallsBurstWinRule;
        private IWinLoseCondition _oneColorBallBurstWinRule;
        private Level _level;

        [Inject]
        private void Construct(BallsAccounter ballsAccounter, BurstBallsAccounter burstBallsAccounter, Level level)
        {
            _allBallsBurstWinRule = new WinLoseCondition(
                new List<ICondition> { new AllBallsBurstVictoryCondition(ballsAccounter) }
                );

            var oneColorBallsBurstLoseCondition = new OneColorBallsBurstLoseCondition(ballsAccounter, burstBallsAccounter);
            var OneColorBallsBurstVictoryCondition = new OneColorBallsBurstVictoryCondition(ballsAccounter, oneColorBallsBurstLoseCondition);

            _oneColorBallBurstWinRule = new WinLoseCondition(
                new List<ICondition> { OneColorBallsBurstVictoryCondition },
                new List<ICondition> { oneColorBallsBurstLoseCondition } 
                );

            _level = level;

            CompleteInitialization();
        }

        public void Restart()
        {
            _allBallsBurstWinRule.Restart();
            _oneColorBallBurstWinRule.Restart();
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
