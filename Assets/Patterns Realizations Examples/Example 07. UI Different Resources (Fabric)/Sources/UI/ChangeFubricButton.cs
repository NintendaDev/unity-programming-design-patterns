namespace Example07.UI
{
    public class ChangeFubricButton : UIButton
    {
        private ChangeFabricMediator _changeFabricMediator;

        public void Initialize(ChangeFabricMediator changeFabricMediator)
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
