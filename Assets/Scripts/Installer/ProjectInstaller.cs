using Playground.Config;
using Playground.Game;
using UnityEngine;
using Zenject;

namespace Playground
{
    public class ProjectInstaller : MonoInstaller
    {
        public BuildConfig buildConfig;
        public GameObject audioManagerPrefab;

        public override void InstallBindings()
        {
            InstallLoadingServices();
            InstallAudioManager();
            InstallUserDataService();
        }

        private void InstallUserDataService()
        {
            if (buildConfig.IsRelease)
            {
                Container.Bind<IFileIO>().To<BinaryFileIO>().AsTransient();
            }
            else
            {
                Container.Bind<IFileIO>().To<JsonFileIO>().AsTransient();
            }

            Container.Bind<UserDataService>().AsSingle();

            if (Application.isEditor)
            {
                Container.Bind<IUserDataExitHandler>().To<EditorUserDataExitHandler>().AsSingle().NonLazy();
            }
            else
            {
                Container.Bind<IUserDataExitHandler>()
                       .To<MobileUserDataExitHandler>()
                       .FromNewComponentOnNewGameObject()
                       .AsSingle()
                       .NonLazy();
            }
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
