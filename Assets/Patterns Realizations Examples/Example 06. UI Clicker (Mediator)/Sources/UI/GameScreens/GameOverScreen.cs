using Example06.UI.Reset;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.GameScreens
{
    public class GameOverScreen : Screen
    {
        [SerializeField, Required] private UIResetButton _resetButton;

        public UIResetButton ResetButton => _resetButton;
    }
}

