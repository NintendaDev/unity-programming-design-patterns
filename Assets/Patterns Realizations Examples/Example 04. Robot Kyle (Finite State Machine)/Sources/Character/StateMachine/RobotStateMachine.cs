using Example04.Characters.StateMachine.States;
using Example04.Characters.StateMachine.States.Randomized;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example04.Characters.StateMachine
{
    public class RobotStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;
        private List<Type> _randomStatesFilter = new List<Type>();
        private Random _random = new Random();

        public RobotStateMachine(Robot robot)
        {
            _states = new List<IState>
            {
                new WalkState(this, robot),
                new IdleState(this, robot),
                new DanceState(this, robot),
                new SitupState(this, robot)
            };

            _randomStatesFilter.Add(typeof(WalkState));

            SwitchState<WalkState>();
        }

        public void SwitchState<T>() where T : IState
        {
            IState nextState = _states.FirstOrDefault(state => state is T);

            if (nextState == null)
                throw new System.Exception($"Unknown state type {nameof(T)}");

            SwitchState(nextState);
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void SwitchRandomState()
        {
            List<IState> filteredStates = _states
                .Where(state => _randomStatesFilter.TrueForAll(filteredType => state.GetType() != filteredType)).ToList();

            int randomStateIndex = _random.Next(filteredStates.Count);

            SwitchState(filteredStates[randomStateIndex]);
        }

        private void SwitchState(IState nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;
            _currentState.Enter();
        }
    }
}