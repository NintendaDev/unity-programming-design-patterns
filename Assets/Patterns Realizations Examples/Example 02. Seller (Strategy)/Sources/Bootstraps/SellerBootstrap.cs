using Example02.Dialogue;
using Example02.NPC;
using Example02.Strategy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02
{
    public class SellerBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Seller _seller;
        [SerializeField, Required, SceneObjectsOnly] private Player _player;
        [SerializeField, Required, SceneObjectsOnly] private SellerDialogueStrategyChanger _sellerDialogueStrategy;
        [SerializeField, Required, SceneObjectsOnly] private UISeller _uiSeller;

        public void Initialize()
        {
            _seller.Initialize();
            ITradableGreeting defaultPlayerGreetingUpponDetection = new NoSellPlayerGreeting();
            _seller.SetGreeting(defaultPlayerGreetingUpponDetection);

            _sellerDialogueStrategy.Initialize(_seller, _player);

            _uiSeller.Initialize(_seller);
        }
    }
}
