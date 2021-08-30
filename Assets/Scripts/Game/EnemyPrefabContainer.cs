using UnityEngine;

namespace Playground.Game
{
    [CreateAssetMenu(fileName = Tag, menuName = "Settings/Enemy/EnemyPrefabContainer")]
    public class EnemyPrefabContainer : ScriptableObject
    {
        private const string Tag = nameof(EnemyPrefabContainer);

        [SerializeField] private Enemy meleeEnemyPrefab;
        [SerializeField] private Enemy rangedEnemyPrefab;

        public Enemy EnemyPrefab(EnemyType enemyType)
        {
            return enemyType == EnemyType.Melee
                    ? meleeEnemyPrefab
                    : rangedEnemyPrefab;
        }
    }
}
