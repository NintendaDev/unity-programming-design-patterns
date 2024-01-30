using UnityEngine;

namespace MonoUtils
{
    public class InitializedMonoBehaviour : MonoBehaviour
    {
        protected bool IsInitialized { get; private set; }

        private void Awake()
        {
            ValidateInitialization();
        }

        public void CompleteInitialization()
        {
            IsInitialized = true;
        }

        private void ValidateInitialization()
        {
            if (IsInitialized == false)
                throw new System.Exception($"{GetType()} is not initialized");
        }
    }
}