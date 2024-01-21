using Example03.Handler;
using Zenject;

namespace Example03.Services
{
    public class LevelService : MonoInstaller
    {
        private Level _level;

        public override void InstallBindings()
        {
            _level = new Level();
            Container.Bind<Level>().FromInstance(_level).AsSingle();
        }
    }
}