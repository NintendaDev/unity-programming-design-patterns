using Example03.Items;
using MonoUtils;

namespace Example03.Accounters
{
    public class BallAccounterInitializer : InitializedMonobehaviour
    {
        private Ball[] _allBalls;

        public BallsAccounter BallsAccounter { get; private set; }

        public void Initialize()
        {
            if (IsInitialized)
                Reset();
            else
                _allBalls = GetComponentsInChildren<Ball>();

            BallsAccounter = new BallsAccounter(_allBalls);

            CompleteInitialization();
        }

        private void Reset()
        {
            foreach (Ball ball in _allBalls)
                ball.gameObject.SetActive(true);
        }
    }
}
