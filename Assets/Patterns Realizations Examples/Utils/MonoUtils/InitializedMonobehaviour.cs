using UnityEngine;

namespace MonoUtils
{
    public class InitializedMonobehaviour : MonoBehaviour
    {
        protected bool IsInitialized { get; set; }

        private void Awake()
        {
            ValidateInitialization();
        }

        private void ValidateInitialization()
        {
            if (IsInitialized == false)
                throw new System.Exception($"{GetType()} is not initialized");
        }
    }
}