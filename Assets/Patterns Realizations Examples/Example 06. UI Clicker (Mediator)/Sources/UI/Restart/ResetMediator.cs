using Example06.Core;
using System.Collections.Generic;

namespace Example06.UI.Reset
{
    public class ResetMediator
    {
        private List<IReset> _resetObjects;

        public ResetMediator(List<IReset> resetObjects)
        {
            _resetObjects = resetObjects;
        }

        public void Reset()
        {
            _resetObjects.ForEach(x => x.Reset());
        }
    }
}
