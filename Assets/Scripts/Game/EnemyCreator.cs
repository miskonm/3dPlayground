using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class EnemyCreator : MonoBehaviour
    {
        [SerializeField] private EnemySpawnPoint[] enemySpawnPoints;

        private EnemyFactory enemyFactory;
        private SignalBus signalBus;
        
        private readonly List<Enemy> enemies = new List<Enemy>();

        public event Action<Enemy> OnEnemyCreated; 

        [Inject]
        public void Construct(EnemyFactory enemyFactory, SignalBus signalBus)
        {
            this.enemyFactory = enemyFactory;
            this.signalBus = signalBus;
        }

        private void OnEnable()
        {
            signalBus.Subscribe<EnemyHitSignal>(HandleHitSignal);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<EnemyHitSignal>(HandleHitSignal);
        }

        private void Start()
        {
            Spawn();
        }

        private void OnDestroy()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.OnHited -= PlaySound;
                enemy.OnKilled -= Enemy_OnKilled;
            }

            enemies.Clear();
        }

        public void HandleHitSignal(EnemyHitSignal enemyHitSignal)
        {
            Debug.LogError($"HandleHitSignal <{enemyHitSignal.Enemy.name}>");
        }

        private void Spawn()
        {
            if (enemySpawnPoints == null)
                return;

            foreach (EnemySpawnPoint enemySpawnPoint in enemySpawnPoints)
            {
                Enemy enemy = enemyFactory.Create(enemySpawnPoint.transform, enemySpawnPoint.EnemyType);
                // enemy.HitDelegate = PlaySound;
                // enemy.OnHit(PlaySound);
                enemy.OnHited += PlaySound;
                enemy.OnKilled += Enemy_OnKilled;
                // Enemy.OnHitedStatic += PlaySound;

                enemies.Add(enemy);
                
                OnEnemyCreated?.Invoke(enemy);
            }
        }

        private void Enemy_OnKilled(Enemy enemy)
        {
            enemy.OnHited -= PlaySound;
            enemy.OnKilled -= Enemy_OnKilled;
            enemies.Remove(enemy);
        }

        private void PlaySound()
        {
            Debug.LogError($"SOUND");
        }
    }
}
