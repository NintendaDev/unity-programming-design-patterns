using System;
using UnityEngine;

namespace Example02.Control
{
    public class AbstractInputEventer
    {
        public event Action<Vector3> MovePressed;

        protected void SenMoveEvent(Vector3 destination)
        {
            MovePressed?.Invoke(destination);
        }
    }
}
