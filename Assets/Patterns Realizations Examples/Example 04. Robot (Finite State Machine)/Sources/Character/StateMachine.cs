using Example04.Character.States;
using System.Collections.Generic;
using System.Linq;

namespace Example04.Character
{
    public class StateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public StateMachine()
        {
            _states = new List<IState>
            {

            };

            _currentState = _states.First();
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState nextState = _states.FirstOrDefault(x => x is T);

            if (nextState == null)
                throw new System.Exception($"Unknown state type {nameof(T)}");

            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }

        private void Update() => _currentState.Update();
    }
}