using Playground.Game;
using UnityEngine;
using Zenject;

namespace Playground
{
    public class ProjectInstaller : MonoInstaller
    {
        public GameObject audioManagerPrefab;
        
        public override void InstallBindings()
        {
            InstallLoadingServices();
            InstallAudioManager();
        }

        private void InstallAudioManager()
        {
            Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle().NonLazy();
        }

        private void InstallLoadingServices()
        {
            Container.Bind<SceneLoader>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<LevelLoader>().AsSingle();
        }
    }
}
