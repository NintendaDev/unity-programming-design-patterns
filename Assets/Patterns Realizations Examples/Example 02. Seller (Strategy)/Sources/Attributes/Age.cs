using Example02.Core;
using MonoUtils;
using Sirenix.OdinInspector;
using Specifications;
using System;
using UnityEngine;

namespace Example02.Attributes
{
    public class Age : InitializedMonobehaviour
    {
        [SerializeField, Required, MinValue(0)] private int _startValue = 1;

        private ISpecification<int> _ageSpecification = new IntGreatOrEqualZeroSpecification();
        private IntCounterBehaviour _ageCounter;

        public event Action<int> Changed;

        public int Value => _ageCounter.Value;

        public void Initialize()
        {
            _ageCounter = new IntCounterBehaviour(_startValue, _ageSpecification);
            Changed?.Invoke(Value);
            IsInitialized = true;
        }

        public void Increase(int value)
        {
            _ageCounter.Increase(value);
            Changed?.Invoke(Value);
        }
    }
}