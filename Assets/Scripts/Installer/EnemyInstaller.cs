using Playground.Game;
using Zenject;

namespace Playground
{
    public class EnemyInstaller : MonoInstaller
    {
        public EnemyPrefabContainer enemyPrefabContainer;

        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().AsSingle().WithArguments(enemyPrefabContainer);

            Container.DeclareSignal<EnemyHitSignal>();
            // Container.BindSignal<EnemyHitSignal>().ToMethod<EnemyCreator>(x => x.HandleHitSignal).FromResolve();
        }
    }
}
