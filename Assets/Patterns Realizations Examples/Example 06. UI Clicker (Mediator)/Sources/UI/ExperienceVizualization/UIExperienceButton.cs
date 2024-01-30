using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.ExperienceVisualization
{
    public class UIExperienceButton : UIButton
    {
        [SerializeField, Required, MinValue(0)] private int _addExperienceValue = 100;

        private ExperienceMediator _experienceMediator;

        public void Initialize(ExperienceMediator experienceMediator)
        {
            _experienceMediator = experienceMediator;

            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _experienceMediator.AddExperience(_addExperienceValue);
        }
    }
}
