using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class EnemyFactory
    {
        private readonly DiContainer diContainer;
        private readonly EnemyPrefabContainer enemyPrefabContainer;

        public EnemyFactory(DiContainer diContainer, EnemyPrefabContainer enemyPrefabContainer)
        {
            this.diContainer = diContainer;
            this.enemyPrefabContainer = enemyPrefabContainer;
        }

        public Enemy Create(Transform transform, EnemyType enemyType)
        {
            Enemy prefab = EnemyPrefab(enemyType);

            return diContainer.InstantiatePrefabForComponent<Enemy>(prefab, transform);
        }

        private Enemy EnemyPrefab(EnemyType enemyType) => 
                enemyPrefabContainer.EnemyPrefab(enemyType);
    }
}
