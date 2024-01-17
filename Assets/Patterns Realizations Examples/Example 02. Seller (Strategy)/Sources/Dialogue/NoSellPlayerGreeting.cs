namespace Example02.Dialogue
{
    public class NoSellPlayerGreeting : IPlayerGreeting
    {
        private string _playerGreeting = "I don't trade with minors! Grow up first and come back later";
        public string GetPlayerGreeting()
        {
            return _playerGreeting;
        }
    }
}
