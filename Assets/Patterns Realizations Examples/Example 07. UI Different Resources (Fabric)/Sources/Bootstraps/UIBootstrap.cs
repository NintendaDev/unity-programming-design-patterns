using Example07.Accounters;
using Example07.GameResources;
using Example07.UI;
using Example07.UI.Factories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example07.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private ResourceCell _gemResourceCell;
        [SerializeField, Required] private ResourceCell _energyResourceCell;
        [SerializeField, Required] private PentagonGemViewFactory _pentagonGemViewFactory;
        [SerializeField, Required] private TriangleGemViewFactory _triangleGemViewFactory;

        public void Initialize(ResourceAccounter resourceAccounter)
        {
            _pentagonGemViewFactory.Initialize(resourceAccounter);
            _triangleGemViewFactory.Initialize(resourceAccounter);

            _gemResourceCell.Initialize(_pentagonGemViewFactory);
            _energyResourceCell.Initialize(_triangleGemViewFactory);

            _gemResourceCell.CreateResourceView(ResourceColor.Green);
            _energyResourceCell.CreateResourceView(ResourceColor.Red);
        }
    }
}
