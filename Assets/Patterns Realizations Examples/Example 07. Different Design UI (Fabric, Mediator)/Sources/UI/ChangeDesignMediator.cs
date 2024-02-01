using Example07.GameResources;
using Example07.UI.Factories;
using System;
using System.Collections.Generic;

namespace Example07.UI
{
    public class ChangeDesignMediator : IDesignChanger, IColorChanger
    {
        private Queue<ResourceViewFactory> _gemFactories;
        private Queue<ResourceViewFactory> _energyFactories;
        private ResourceCell _gemResourceCell;
        private ResourceCell _batteryResourceCell;
        private Queue<ResourceColor> _resourceColors;

        public ChangeDesignMediator(ResourceCell gemResourceCell, ResourceCell batteryResourceCell,
            IEnumerable<ResourceViewFactory> gemFactories, IEnumerable<ResourceViewFactory> energyFactories)
        {
            _gemResourceCell = gemResourceCell;
            _batteryResourceCell = batteryResourceCell;
            _gemFactories = new Queue<ResourceViewFactory>(gemFactories);
            _energyFactories = new Queue<ResourceViewFactory>(energyFactories);

            ResourceColor[] allResourceColors = (ResourceColor[])Enum.GetValues(typeof(ResourceColor));
            _resourceColors = new Queue<ResourceColor>(allResourceColors);
        }

        public void ChangeDesign()
        {
            ChangeCellView(_gemResourceCell, _gemFactories);
            ChangeCellView(_batteryResourceCell, _energyFactories);
        }

        public void ChangeColor()
        {
            ResourceColor nextColor = _resourceColors.Dequeue();
            _gemResourceCell.CreateResourceView(nextColor);
            _batteryResourceCell.CreateResourceView(nextColor);

            _resourceColors.Enqueue(nextColor);
        }

        private void ChangeCellView(ResourceCell resourceCell, Queue<ResourceViewFactory> factories)
        {
            ChangeCellFactory(resourceCell, factories);
            resourceCell.CreateResourceView(ResourceColor.Blue);
        }

        private void ChangeCellFactory(ResourceCell resourceCell, Queue<ResourceViewFactory> factories)
        {
            ResourceViewFactory nextFactory = factories.Dequeue();
            resourceCell.Initialize(nextFactory);
            factories.Enqueue(nextFactory);
        }
    }
}
