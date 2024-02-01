using Example07.GameResources;
using Example07.UI.Factories;
using MonoUtils;
using UnityEngine;

namespace Example07.UI
{
    public class ResourceCell : InitializedMonoBehaviour
    {
        private ResourceViewFactory _resourceViewFactory;
        private Transform _transform;
        private ResourceView _currentView;

        public void Initialize(ResourceViewFactory resourceViewFactory)
        {
            _resourceViewFactory = resourceViewFactory;
            _transform = transform;

            ClearChildrenObjects();

            CompleteInitialization();
        }

        public void CreateResourceView(ResourceColor color)
        {
            if (_currentView != null)
                Destroy(_currentView);

            _currentView = _resourceViewFactory.Get(color);
            _currentView.transform.parent = _transform;
            _currentView.ResetScale();
        } 

        private void ClearChildrenObjects()
        {
            for (int i = 0; i < _transform.childCount; i++)
                Destroy(_transform.GetChild(i).gameObject);
        }
    }
}
