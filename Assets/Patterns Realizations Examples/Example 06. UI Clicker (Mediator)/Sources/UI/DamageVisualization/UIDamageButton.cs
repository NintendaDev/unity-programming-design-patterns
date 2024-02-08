using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

namespace Example06.UI.DamageVisualization
{
    public class UIDamageButton : UIButton
    {
        [SerializeField, Required, MinValue(0)] private int _damage = 10;

        private DamageMediator _damageMediator;

        [Inject]
        private void Construct(DamageMediator damageMediator)
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
