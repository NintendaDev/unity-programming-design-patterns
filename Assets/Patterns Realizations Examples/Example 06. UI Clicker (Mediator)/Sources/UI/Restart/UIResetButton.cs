namespace Example06.UI.Reset
{
    public class UIResetButton : UIButton
    {
        private ResetMediator _resetMediator;

        public void Initialize(ResetMediator resetMediator)
        {
            _resetMediator = resetMediator;
            IsInitialized = true;
        }

        protected override void OnButtonClick()
        {
            _resetMediator.Reset();
        }
    }
}
