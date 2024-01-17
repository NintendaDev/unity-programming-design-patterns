using Example01.Control;

namespace Example01.UI
{
    public class UIShootButton : UIButtonAbstract
    {
        private Shooter _shooter;

        public void Initialize(Shooter shooter)
        {
            _shooter = shooter;
        }

        protected override void OnButtonClick()
        {
            _shooter.Shoot();
        }
    }
}