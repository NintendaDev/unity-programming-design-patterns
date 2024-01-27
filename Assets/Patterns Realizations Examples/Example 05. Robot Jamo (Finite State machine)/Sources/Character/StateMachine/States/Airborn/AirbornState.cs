using Example05.Characters.StateMachine.States.Configurations;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Airborn
{
    public abstract class AirbornState : MovementState
    {
        private readonly AirbornStateConfiguration _configuration;

        public AirbornState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _configuration = character.Configuration.AirbornStateConfiguration;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartAirborne();

            Data.Speed = _configuration.Speed;
        }

        public override void Exit()
        {
            base.Exit();

            View.StopAirborne();
        }

        public override void Update()
        {
            base.Update();

            Data.YVelocity -= GetGravityMultiplier() * Time.deltaTime;
        }

        protected virtual float GetGravityMultiplier()
        {
            return _configuration.BaseGravity;
        }
    }

}