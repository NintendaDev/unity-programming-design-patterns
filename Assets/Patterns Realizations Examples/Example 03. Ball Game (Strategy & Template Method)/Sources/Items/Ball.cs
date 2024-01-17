using Example03.Item;
using System;
using UnityEngine;

namespace Example03.Items
{
    public class Ball : MonoBehaviour, IReadOnlyBall
    {
        [SerializeField] private BallColor _color;

        public event Action<IReadOnlyBall> Bursted;

        public BallColor Color => _color;

        public void Initialize()
        {
            gameObject.SetActive(true);
        }

        public void Burst()
        {
            Bursted?.Invoke(this);
            Die();
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}