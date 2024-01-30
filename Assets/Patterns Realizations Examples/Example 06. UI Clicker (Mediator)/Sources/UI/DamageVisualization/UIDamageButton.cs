using UnityEngine;
using Sirenix.OdinInspector;

namespace Example06.UI.DamageVisualization
{
    public class UIDamageButton : UIButton
    {
        [SerializeField, Required, MinValue(0)] private int _damage = 10;

        private DamageMediator _damageMediator;

        public void Initialize(DamageMediator damageMediator)
        {
            _damageMediator = damageMediator;

            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _damageMediator.TakeDamage(_damage);
        }
    }
}
