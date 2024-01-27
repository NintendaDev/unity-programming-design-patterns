using UnityEngine;

namespace Example04.Core
{
    public class PatrolPointsInitializer : PointsInitializer
    {
        private void OnDrawGizmos()
        {
            if (TryInitializePoints() == false)
                return;

            Gizmos.color = Color.yellow;

            for (int x = 0; x < Points.Count; x++)
                Gizmos.DrawLine(Points[x].position, Points[GetNextPointIndex(x)].position);

            Gizmos.color = Color.green;

            foreach (Transform point in Points)
                Gizmos.DrawSphere(point.position, PointVisualRadius);
        }

        private int GetNextPointIndex(int currentIndex)
        {
            if (currentIndex < Points.Count - 1)
                return currentIndex + 1;

            return 0;
        }
    }
}