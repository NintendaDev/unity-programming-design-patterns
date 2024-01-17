using System;
using UnityEngine;

namespace Example02.Control
{
    public class AbstractInputEventer
    {
        public event Action<Vector2> ClickPressed;

        protected void SendClickEvent(Vector2 screenPosition)
        {
            ClickPressed?.Invoke(screenPosition);
        }
    }
}
