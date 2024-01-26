using UnityEngine;
using Sirenix.OdinInspector;
using Example05.Characters.StateMachine.States.Configurations;

namespace Example05.Characters
{
    [CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField, Required] private GroundedStateConfiurationg _groundedStateConfiguration;
        [SerializeField, Required] private AirbornStateConfiguration _airbornStateConfiguration;

        public GroundedStateConfiurationg GroundedStateConfiguration => _groundedStateConfiguration;

        public AirbornStateConfiguration AirbornStateConfiguration => _airbornStateConfiguration;
    }
}
