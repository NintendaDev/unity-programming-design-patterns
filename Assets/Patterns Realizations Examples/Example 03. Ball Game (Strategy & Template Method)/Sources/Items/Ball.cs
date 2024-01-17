using Example03.Item;
using System;
using UnityEngine;

namespace Example03.Items
{
    public abstract class Ball : MonoBehaviour, IReadOnlyBall
    {
        public event Action<IReadOnlyBall> Bursted;

        public BallColor Color { get; private set; }

        public virtual void Initialize()
        {
            Color = GetInitializedBallColor();
            gameObject.SetActive(true);
        }

        public void Burst()
        {
            Bursted?.Invoke(this);
            Die();
        }

        protected abstract BallColor GetInitializedBallColor();

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
