namespace Example06.UI.ExperienceVisualization
{
    public class UIExperienceLabel : UIValueText<int>
    {
        private ExperienceMediator _experienceMediator;

        public void Initialize(ExperienceMediator experienceMediator)
        {
            _experienceMediator = experienceMediator;
            IsInitialized = true;
        }

        private void Start()
        {
            SetValueText(_experienceMediator.Value);
        }

        private void OnEnable()
        {
            _experienceMediator.Changed += SetValueText;
        }

        private void OnDisable()
        {
            _experienceMediator.Changed -= SetValueText;
        }
    }
}
