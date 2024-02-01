using Sirenix.OdinInspector;
using UnityEngine;

namespace Example07.GameResources
{
    public abstract class Resource : ScriptableObject
    {
        [LabelWidth(40), EnumToggleButtons]
        [HorizontalGroup("ResourceData", Width = 0.75f)]
        [SerializeField, Required] private ResourceColor _color;

        [HideLabel]
        [HorizontalGroup("ResourceData")]
        [SerializeField, Required, PreviewField(100)] private Sprite _icon;

        public Sprite Icon => _icon;

        public ResourceColor ItemColor => _color;
    }
}
