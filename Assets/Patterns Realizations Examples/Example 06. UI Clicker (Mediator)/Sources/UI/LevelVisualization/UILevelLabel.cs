namespace Example06.UI.LevelVisualization
{
    public class UILevelLabel : UIValueText<int>
    {
        private const int UILevelShift = 1;

        public void SetLevelText(int level)
        {
            SetValueText(level + UILevelShift);
        }
    }
}
