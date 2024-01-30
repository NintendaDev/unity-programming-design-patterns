using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.ExperienceVisualization
{
    public class UIExperienceButton : UIButton
    {
        [SerializeField, Required, MinValue(0)] private int _addExperienceValue = 100;

        private ExperienceMediator _experienceButtonMediator;

        public void Initialize(ExperienceMediator experienceButtonMediator)
        {
            _experienceButtonMediator = experienceButtonMediator;

            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _experienceButtonMediator.AddExperience(_addExperienceValue);
        }
    }
}
