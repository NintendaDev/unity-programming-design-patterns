using UnityEngine;

namespace Example03.UI
{
    public class UIScreen : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}
