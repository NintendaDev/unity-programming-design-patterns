using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example06.UI.ExperienceVisualization
{
    public class UIExperienceButton : UIButton
    {
        [SerializeField, Required, MinValue(0)] private int _addExperienceValue = 100;

        private ExperienceMediator _experienceButtonMediator;

        [Inject]
        private void Construct(ExperienceMediator experienceButtonMediator)
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
