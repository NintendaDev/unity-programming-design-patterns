using Example02.NPC;
using Nova;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02
{
    public class UISeller : MonoBehaviour
    {
        [SerializeField, Required] private TextBlock _sellerNameText;
        [SerializeField, Required] private TextBlock _sellerDialogueText;

        private Seller _seller;

        public void Initialize(Seller seller)
        {
            _seller = seller;
            SetSekkerNameText();
            SetGreetingText(_seller.DefaultGreeting);
        }

        private void OnEnable()
        {
            _seller.TradableGreeted += OnPlayerGreeting;
        }
        private void OnDisable()
        {
            _seller.TradableGreeted -= OnPlayerGreeting;
        }

        private void SetSekkerNameText()
        {
            _sellerNameText.Text = _seller.Name;
        }

        private void SetGreetingText(string greeting)
        {
            _sellerDialogueText.Text = greeting;
        }

        private void OnPlayerGreeting(string greeting)
        {
            SetGreetingText(greeting);
        }
    }
}
