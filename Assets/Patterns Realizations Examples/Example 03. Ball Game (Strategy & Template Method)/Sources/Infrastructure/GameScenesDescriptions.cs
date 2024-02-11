using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;

namespace Example03.Infrastructure
{
    [CreateAssetMenu(fileName = "new GameScenesDescriptions", menuName = "Example03 / GameScenesDescriptions")]
    public class GameScenesDescriptions : ScriptableObject
    {
        [ValidateInput(nameof(IsUniqueSceneParameters))]
        [SerializeField] private SceneDescription[] _sceneParameters;

        public SceneDescription GetSceneDescription(SceneIdentificator sceneIdentificator)
        {
            SceneDescription sceneparameters = _sceneParameters.Where(x => x.Identificator == sceneIdentificator).FirstOrDefault();

            if (sceneparameters == null)
                throw new System.Exception("Scene parameters with the specified type were not found");

            return sceneparameters;
        }

        private bool IsUniqueSceneParameters(SceneDescription[] sceneParameters, ref string errorMessage)
        {
            errorMessage = "Scene parameters list is not unique";

            return sceneParameters.GroupBy(x => x.Identificator).Count() == _sceneParameters.Length;
        }
    }
}