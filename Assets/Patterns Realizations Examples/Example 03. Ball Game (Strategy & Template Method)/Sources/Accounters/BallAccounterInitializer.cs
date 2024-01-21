using Example03.Items;
using UnityEngine;

namespace Example03.Accounters
{
    public class BallAccounterInitializer : MonoBehaviour
    {
        private bool _isInitialized;
        private Ball[] _allBalls;

        public BallsAccounter BallsAccounter { get; private set; }

        public void Initialize()
        {
            if (_isInitialized)
                Reset();
            else
                _allBalls = GetComponentsInChildren<Ball>();

            BallsAccounter = new BallsAccounter(_allBalls);
            _isInitialized = true;
        }

        private void Reset()
        {
            foreach (Ball ball in _allBalls)
                ball.gameObject.SetActive(true);
        }
    }
}
