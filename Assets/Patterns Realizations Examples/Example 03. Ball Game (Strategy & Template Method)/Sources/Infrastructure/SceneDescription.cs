using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Example03.Infrastructure
{
    [System.Serializable]
    public class SceneDescription
    {
        [OnValueChanged(nameof(UpdateSceneName))]
        [SerializeField] private SceneIdentificator _sceneIdentificator;

        [AssetSelector(Filter = "t:scene"), ValidateInput(nameof(IsSceneAsset)), OnValueChanged(nameof(UpdateSceneName))]
        [SerializeField, Required, AssetsOnly] private Object _scene;

        [SerializeField, ReadOnly] private string _name;
        

        private readonly string _sceneExtension = ".unity";

        public SceneIdentificator Identificator => _sceneIdentificator;

        public string Name => _name;

        private bool IsSceneAsset(Object sceneObject)
        {
#if UNITY_EDITOR
            string assetPath = AssetDatabase.GetAssetPath(sceneObject);
            return assetPath.EndsWith(_sceneExtension);
#else
            return true;
#endif
        }

        private void UpdateSceneName()
        {
            _name = _scene.name;
        }
    }
}
