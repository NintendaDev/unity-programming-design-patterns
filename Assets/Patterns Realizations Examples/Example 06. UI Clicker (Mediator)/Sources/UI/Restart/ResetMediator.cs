using Example06.Core;
using System;

namespace Example06.UI.Reset
{
    public class ResetMediator
    {
        private IReset _reseter;

        public ResetMediator(IReset reseter)
        {
            _reseter = reseter;
        }

        public void Reset()
        {
            _reseter.Reset();
        }
    }
}
