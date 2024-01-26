using Example05.Core;
using UnityEngine;
using Example05.Characters.StateMachine;
using Sirenix.OdinInspector;

namespace Example05.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField, Required] private CharacterConfiguration _configuration;
        [SerializeField, Required] private CharacterView _view;
        [SerializeField, Required] private GroundChecker _groundChecker;

        private PlayerInput _input;
        private CharacterStateMachine _stateMachine;
        private CharacterController _characterController;

        public PlayerInput Input => _input;

        public CharacterController Controller => _characterController;

        public CharacterConfiguration Configuration => _configuration;

        public CharacterView View => _view;

        public GroundChecker GroundChecker => _groundChecker;

        public void Initialize()
        {
            _view.Initialize();
            _characterController = GetComponent<CharacterController>();
            _input = new PlayerInput();
            _stateMachine = new CharacterStateMachine(this);
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }
    }
}
