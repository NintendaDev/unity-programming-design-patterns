namespace Example05.UI.HealthVisualization
{
    public class IntHealthMediator : HealthMediator<int>
    {
        public IntHealthMediator(IHealth<int> health) : base(health)
        {
        }
    }
}