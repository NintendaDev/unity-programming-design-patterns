using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.GameScreens
{
    public class Screen : MonoBehaviour
    {
        [Button, DisableInEditorMode]
        public void Enable()
        {
            if (gameObject.activeSelf == false)
                gameObject.SetActive(true);
        }

        [Button, DisableInEditorMode]
        public void Disable()
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }
}