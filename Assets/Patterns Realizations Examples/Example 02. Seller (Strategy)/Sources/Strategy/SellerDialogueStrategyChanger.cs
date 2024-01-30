using Example02.Attributes;
using Example02.Dialogue;
using Example02.NPC;
using MonoUtils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02.Strategy
{
    public class SellerDialogueStrategyChanger : InitializedMonoBehaviour
    {
        [ValidateInput(nameof(IsValidStrategyThresholds))]
        [SerializeField, Required, MinValue(0)] private int _noSellAgeThreshold = 8;
        [ValidateInput(nameof(IsValidStrategyThresholds))]
        [SerializeField, Required, MinValue(0)] private int _fruitSellAgeThreshold = 14;

        private Seller _seller;
        private Age _playerAge;
        private ITradableGreeting _noSellGreeting = new NoSellPlayerGreeting();
        private ITradableGreeting _fruitSellGreeting = new FruitSellPlayerGreeting();
        private ITradableGreeting _shieldSellGreeting = new ShieldSellPlayerGreeting();
        private bool _isSubscribed;

        public void Initialize(Seller seller, Player player)
        {
            _seller = seller;
            _playerAge = player.GetComponent<Age>();
            Subscribe();

            CompleteInitialization();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private bool IsValidStrategyThresholds(ref string errorMessage)
        {
            errorMessage = "No Sel Age Threshold must be less than Fruit Sell Age Threshold";
            return _noSellAgeThreshold < _fruitSellAgeThreshold;
        }

        private void Subscribe()
        {
            if (_isSubscribed)
                return;

            _playerAge.Changed += OnPlayerAgeChange;
            _isSubscribed = true;
        }

        private void OnPlayerAgeChange(int ageValue)
        {
            ITradableGreeting playerGreetin = GetPlayerGreeting(ageValue);
            _seller.SetGreeting(playerGreetin);
        }

        private ITradableGreeting GetPlayerGreeting(int playerAge)
        {
            if (playerAge < _noSellAgeThreshold)
                return _noSellGreeting;
            else if (playerAge < _fruitSellAgeThreshold)
                return _fruitSellGreeting;

            return _shieldSellGreeting;
        }

        private void Unsubscribe()
        {
            _playerAge.Changed -= OnPlayerAgeChange;
            _isSubscribed = false;
        }
    }
}
