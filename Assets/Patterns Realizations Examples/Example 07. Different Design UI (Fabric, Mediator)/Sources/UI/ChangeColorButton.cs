namespace Example07.UI
{
    public class ChangeColorButton : UIButton
    {
        private IColorChanger _colorChanger;

        public void Initialize(IColorChanger colorChanger)
        {
            _colorChanger = colorChanger;
            _colorChanger.ChangeColor();

            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _colorChanger.ChangeColor();
        }
    }
}
