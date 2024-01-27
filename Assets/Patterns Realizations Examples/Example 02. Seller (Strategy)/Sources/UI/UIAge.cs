using Example02.Attributes;
using MonoUtils;
using Nova;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02
{
    public class UIAge : InitializedMonobehaviour
    {
        [SerializeField, Required] private TextBlock _ageValueText;

        private Age _age;

        public void Initialize(Age age)
        {
            _age = age;
            OnAgeChange(_age.Value);
            IsInitialized = true;
        }

        private void OnEnable()
        {
            _age.Changed += OnAgeChange;
        }

        private void OnDisable()
        {
            _age.Changed -= OnAgeChange;
        }

        private void OnAgeChange(int ageValue)
        {
            _ageValueText.Text = ageValue.ToString();
        }
    }
}
