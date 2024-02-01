using Example07.GameResources;
using Example07.UI.Factories;
using System.Collections.Generic;

namespace Example07.UI
{
    public class ChangeFabricMediator
    {
        private Queue<ResourceViewFactory> _gemFactories;
        private Queue<ResourceViewFactory> _energyFactories;
        private ResourceCell _gemResourceCell;
        private ResourceCell _batteryResourceCell;

        public ChangeFabricMediator(ResourceCell gemResourceCell, ResourceCell batteryResourceCell,
            IEnumerable<ResourceViewFactory> gemFactories, IEnumerable<ResourceViewFactory> energyFactories)
        {
            _gemResourceCell = gemResourceCell;
            _batteryResourceCell = batteryResourceCell;
            _gemFactories = new Queue<ResourceViewFactory>(gemFactories);
            _energyFactories = new Queue<ResourceViewFactory>(energyFactories);
        }

        public void Change()
        {
            ChangeCellView(_gemResourceCell, _gemFactories);
            ChangeCellView(_batteryResourceCell, _energyFactories);
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
