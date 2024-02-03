using System.Collections.Generic;
using UnityEngine;

namespace Example09.Core
{
    public abstract class GridMaker
    {
        public abstract List<Vector3> GetGridPoints(Vector3 gridCenter);
    }
}
