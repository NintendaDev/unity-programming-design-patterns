using Sirenix.OdinInspector;
using UnityEngine;
using Nova;
using MonoUtils;
using Example07.GameResources;

namespace Example07
{
    public class ResourceView : InitializedMonoBehaviour
    {
        [SerializeField, Required] private UIBlock2D _image;
        [SerializeField, Required] private TextBlock _counterText;

        public void Initialize(Resource resource)
        {
            SetImage(resource.Icon);
            CompleteInitialization();
        }

        public void SetResourceCounter(int currentValue)
        {
            _counterText.Text = currentValue.ToString();
        }

        private void SetImage(Sprite sprite)
        {
            _image.SetImage(sprite);
        }
    }
}
