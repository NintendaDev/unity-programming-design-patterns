using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Configurations
{
    [CreateAssetMenu(fileName = "new RectangleGridConfig", menuName = "Example09 / Configurations / RectangleGridConfig")]
    public class RectangleGridConfig : ScriptableObject
    {
        [field: SerializeField, Required, MinValue(0)] public float Width { get; private set; } = 10;

        [field: SerializeField, Required, MinValue(0)] public float Height { get; private set; } = 10;

        [field: SerializeField, Required, MinValue(0)] public float Step { get; private set; } = 2;
    }
}
