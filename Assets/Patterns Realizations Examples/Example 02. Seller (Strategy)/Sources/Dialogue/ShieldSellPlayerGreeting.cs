
namespace Example02.Dialogue
{
    public class ShieldSellPlayerGreeting : IPlayerGreeting
    {
        private string _playerGreeting = "Now that you're all grown up, I can sell you excellent armor!";

        public string GetPlayerGreeting()
        {
            return _playerGreeting;
        }
    }
}
