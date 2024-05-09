using System;
using System.Collections;
using UnityEngine;

namespace SecondExample.Scripts.Enemies
{
    public class EnemySpawner
    {
        private const string ConfigPath = "EnemySpawner/EnemySpawnerConfig";
    
        private readonly CoroutineHandler _coroutineHandler;
        private readonly EnemyFactory _enemyFactory;
        private readonly SpawnPointHandler _spawnPointHandler;
    
        private EnemySpawnerConfig _spawnerConfig;
        private Coroutine _spawn;
    
        public EnemySpawner(EnemyFactory enemyFactory, CoroutineHandler coroutineHandler, SpawnPointHandler spawnPointHandler)
        {
            _enemyFactory = enemyFactory;
            _coroutineHandler = coroutineHandler;
            _spawnPointHandler = spawnPointHandler;
            Load();
        }

        public void StartWork()
        {
            StopWork();

            _spawn = _coroutineHandler.StartCoroutine(Spawn());
        }

        private void StopWork()
        {
            if (_spawn != null) 
                _coroutineHandler.StopCoroutine(_spawn);
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPointHandler.GetRandomPoint());
                yield return new WaitForSeconds(_spawnerConfig.SpawnCooldown);
            }
        }
    
        private void Load()
        {
            _spawnerConfig = Resources.Load<EnemySpawnerConfig>(ConfigPath);
        }
    }
}
