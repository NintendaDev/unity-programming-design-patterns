using Example07.Accounters;
using Example07.UI;
using Example07.UI.Factories;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Example07.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private ChangeDesignButton _changeDesignButton;
        [SerializeField, Required] private ChangeColorButton _changeColorButton;
        [SerializeField, Required] private ResourceCell _gemResourceCell;
        [SerializeField, Required] private ResourceCell _energyResourceCell;
        [SerializeField, Required] private PentagonGemViewFactory _pentagonGemViewFactory;
        [SerializeField, Required] private TriangleGemViewFactory _triangleGemViewFactory;
        [SerializeField, Required] private BadgeEnergyViewFactory _badgeEnergyViewFactory;
        [SerializeField, Required] private BatteryEnergyViewFactory _batteryEnergyViewFactory;

        public void Initialize(ResourceAccounter resourceAccounter)
        {
            _pentagonGemViewFactory.Initialize(resourceAccounter);
            _triangleGemViewFactory.Initialize(resourceAccounter);

            _badgeEnergyViewFactory.Initialize(resourceAccounter);
            _batteryEnergyViewFactory.Initialize(resourceAccounter);

            _gemResourceCell.Initialize(_pentagonGemViewFactory);
            _energyResourceCell.Initialize(_badgeEnergyViewFactory);

            ChangeDesignMediator changeDesignMediator = new(_gemResourceCell, _energyResourceCell,
                new List<ResourceViewFactory> { _pentagonGemViewFactory, _triangleGemViewFactory },
                new List<ResourceViewFactory> { _badgeEnergyViewFactory, _batteryEnergyViewFactory });

            _changeDesignButton.Initialize(changeDesignMediator);
            _changeColorButton.Initialize(changeDesignMediator);
        }
    }
}