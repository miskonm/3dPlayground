using Zenject;

namespace Playground
{
    public class GameSceneSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<SignalBus>().AsSingle().NonLazy();
            SignalBusInstaller.Install(Container);
            
            Container.Bind<LevelManager>().AsSingle().NonLazy();
            Container.Bind<PauseService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
