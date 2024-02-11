using Example03.Items;
using MonoUtils;
using Zenject;

namespace Example03.Accounters
{
    public class BallAccounterInitializer : InitializedMonoBehaviour
    {
        private Ball[] _allBalls;

        public BallsAccounter BallsAccounter { get; private set; }

        [Inject]
        private void Construct()
        {
           _allBalls = GetComponentsInChildren<Ball>();
            BallsAccounter = new BallsAccounter(_allBalls);

            CompleteInitialization();
        }
    }
}
