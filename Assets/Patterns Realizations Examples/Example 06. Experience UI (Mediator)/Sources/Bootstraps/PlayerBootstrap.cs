using Example06.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour, IReset
    {
        [SerializeField, Required] private Player _player;

        public void Initialize()
        {
            _player.Initialize();
        }

        public void Reset()
        {
            _player.Reset();
        }
    }
}
