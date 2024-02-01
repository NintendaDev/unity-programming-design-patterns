using Sirenix.OdinInspector;
using UnityEngine;
using Nova;
using Example07.GameResources;

namespace Example07
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField, Required] private UIBlock2D _image;
        [SerializeField, Required] private TextBlock _counterText;

        private bool _isInitialized;

        public void Initialize(Resource resource)
        {
            SetImage(resource.Icon);
            _isInitialized = true;
        }

        public void SetResourceCounter(int currentValue)
        {
            if (_isInitialized == false)
                throw new System.Exception($"{GetType()} is not initialized");

            _counterText.Text = currentValue.ToString();
        }

        public void ResetScale()
        {
            transform.localScale = Vector3.one;
        }

        private void SetImage(Sprite sprite)
        {
            _image.SetImage(sprite);
        }
    }
}
