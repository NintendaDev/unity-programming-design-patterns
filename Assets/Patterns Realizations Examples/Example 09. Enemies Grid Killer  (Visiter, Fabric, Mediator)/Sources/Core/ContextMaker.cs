using UnityEngine;

namespace Example09.Core
{
    public static class ContextMaker
    {
        private const string ContextName = "Context";
        private static MonoBehaviour _context;

        public static MonoBehaviour Make()
        {
            if (_context == null)
            {
                GameObject contextGameObject = new GameObject(ContextName);
                contextGameObject.AddComponent(typeof(Context));
                _context = contextGameObject.GetComponent<Context>();
            }
            
            return _context;
        }
    }
}
