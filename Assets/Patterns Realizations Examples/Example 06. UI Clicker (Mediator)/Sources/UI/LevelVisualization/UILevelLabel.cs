namespace Example06.UI.LevelVisualization
{
    public class UILevelLabel : UIValueText<int>
    {
        private const int UILevelShift = 1;
        private LevelMediator _levelMediator;

        public void Initialize(LevelMediator levelMediator)
        {
            _levelMediator = levelMediator;

            CompleteInitialization();
        }

        private void Start()
        {
            SetLevelText(_levelMediator.Value);
        }

        private void OnEnable()
        {
            _levelMediator.Changed += SetLevelText;
        }

        private void OnDisable()
        {
            _levelMediator.Changed -= SetLevelText;
        }

        public void SetLevelText(int level)
        {
            SetValueText(level + UILevelShift);
        }
    }
}
