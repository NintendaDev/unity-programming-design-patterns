using Example03.Core;
using Example03.Items;
using MonoUtils;
using Zenject;

namespace Example03.Accounters
{
    public class BallAccounterInitializer : InitializedMonoBehaviour, IRestart
    {
        private Ball[] _allBalls;

        public BallsAccounter BallsAccounter { get; private set; }

        [Inject]
        private void Construct()
        {
            if (IsInitialized)
                Restart();
            else
                _allBalls = GetComponentsInChildren<Ball>();

            BallsAccounter = new BallsAccounter(_allBalls);

            CompleteInitialization();
        }

        public void Restart()
        {
            if (_allBalls == null)
                return;

            foreach (Ball ball in _allBalls)
                ball.gameObject.SetActive(true);
        }
    }
}
