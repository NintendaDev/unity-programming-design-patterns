using MonoUtils;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example04.Core
{
    public class PointsInitializer : InitializedMonoBehaviour
    {
        [SerializeField, Required, MinValue(0)] protected float PointVisualRadius = 0.2f;
        [SerializeField, Required] private Transform _pointsParrent;

        private List<Transform> _points;

        public IReadOnlyList<Transform> Points => _points;

        public void Initialize()
        {
            TryInitializePoints();
            CompleteInitialization();
        }

        private void OnDrawGizmos()
        {
            if (TryInitializePoints() == false)
                return;

            Gizmos.color = Color.green;

            foreach (Transform point in Points)
                Gizmos.DrawSphere(point.position, PointVisualRadius);
        }

        protected bool TryInitializePoints()
        {
            if (_pointsParrent == null)
                return false;

            _points = _pointsParrent.GetComponentsInChildren<Transform>()
                .Where(x => x != _pointsParrent)
                .ToList();

            return _points != null && _points.Count > 0;
        }
    }
}
