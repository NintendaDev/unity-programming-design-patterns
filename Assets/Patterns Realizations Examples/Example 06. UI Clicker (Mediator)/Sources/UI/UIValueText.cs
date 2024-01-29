using MonoUtils;
using Sirenix.OdinInspector;
using UnityEngine;
using Nova;
using System;

namespace Example06
{
    public class UIValueText<T> : InitializedMonobehaviour
        where T : struct, IFormattable
    {
        [SerializeField, Required] private TextBlock _valueTextBlock;

        protected void SetValueText(T value)
        {
            _valueTextBlock.Text = value.ToString();
        }
    }
}
