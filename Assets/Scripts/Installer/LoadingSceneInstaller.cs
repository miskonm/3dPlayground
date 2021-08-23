using Zenject;

namespace Playground
{
    public class LoadingSceneInstaller : MonoInstaller
    {
        public LoadingService loadingServicePrefab;
        
        public override void InstallBindings()
        {
            Container
                   .Bind<LoadingService>()
                   .FromComponentInNewPrefab(loadingServicePrefab)
                   .AsSingle().NonLazy();
        }
    }
}
