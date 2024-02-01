namespace Example07.UI
{
    public class ChangeDesignButton : UIButton
    {
        private ChangeDesignMediator _changeFabricMediator;

        public void Initialize(ChangeDesignMediator changeFabricMediator)
        {
            _changeFabricMediator = changeFabricMediator;
            _changeFabricMediator.Change();
            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _changeFabricMediator.Change();
        }
    }
}
