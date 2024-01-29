using Example06.Attributes;

namespace Example06.UI.ExperienceVisualization
{
    public class ExperienceMediator : NotifiedValueMediator
    {
        private Experience _experience;

        public ExperienceMediator(Experience experience) : base(experience)
        {
            _experience = experience;
        }

        public void AddExperience(int delta)
        {
            _experience.AddExperience(delta);
        }
    }
}
