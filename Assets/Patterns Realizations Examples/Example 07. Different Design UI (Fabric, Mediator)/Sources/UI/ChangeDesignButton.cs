namespace Example07.UI
{
    public class ChangeDesignButton : UIButton
    {
        private IDesignChanger _designChanger;

        public void Initialize(IDesignChanger designChanger)
        {
            _designChanger = designChanger;
            _designChanger.ChangeDesign();
            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _designChanger.ChangeDesign();
        }
    }
}
