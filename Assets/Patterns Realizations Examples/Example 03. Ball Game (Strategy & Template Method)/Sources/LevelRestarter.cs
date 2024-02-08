using Example03.Core;
using System.Collections.Generic;

namespace Example03
{
    public class LevelRestarter
    {
        private List<IRestart> _restartObjects;

        public LevelRestarter(List<IRestart> restartObjects)
        {
            _restartObjects = restartObjects;
        }

        public void Restart()
        {
            _restartObjects.ForEach(x => x.Restart());
        }
    }
}
