using Zenject;

namespace Example06.UI.Reset
{
    public class UIResetButton : UIButton
    {
        private ResetMediator _resetMediator;

        [Inject]
        private void Construct(ResetMediator resetMediator)
        {
            _resetMediator = resetMediator;

            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _resetMediator.Reset();
        }
    }
}
