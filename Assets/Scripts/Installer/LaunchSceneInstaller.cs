using Zenject;

namespace Playground
{
    public class LaunchSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameLauncher>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
