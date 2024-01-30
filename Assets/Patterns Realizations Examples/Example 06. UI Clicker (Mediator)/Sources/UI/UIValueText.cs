using MonoUtils;
using Sirenix.OdinInspector;
using UnityEngine;
using Nova;
using System;

namespace Example06.UI
{
    public class UIValueText<T> : MonoBehaviour
        where T : struct, IFormattable
    {
        [SerializeField, Required] private TextBlock _valueTextBlock;

        public void SetValueText(T currentValue)
        {
            _valueTextBlock.Text = currentValue.ToString();
        }
    }
}