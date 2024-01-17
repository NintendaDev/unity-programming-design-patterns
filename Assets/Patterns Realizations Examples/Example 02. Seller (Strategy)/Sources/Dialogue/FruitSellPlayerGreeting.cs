namespace Example02.Dialogue
{
    public class FruitSellPlayerGreeting : IPlayerGreeting
    {
        private string _playerGreeting = "You are already big enough for me to sell you a couple of fruits. " +
            "But to sell armor, you still need to grow a bit more!";

        public string GetPlayerGreeting()
        {
            return _playerGreeting;
        }
    }
}
