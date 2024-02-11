using Example03.Core;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example03
{
    public class LevelRestarter : MonoBehaviour
    {
        private List<IRestart> _restartObjects;

        [Inject]
        private void Construct(List<IRestart> restartObjects)
        {
            _restartObjects = restartObjects;
        }

        private void Start()
        {
            Restart();
        }

        [Button, DisableInEditorMode]
        public void Restart()
        {
            foreach (IRestart restartedObject in _restartObjects)
                restartedObject.Restart();
        }
    }
}
