using SecondExample.Scripts.Enemies;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private SpawnPointHandler _spawnPointHandlerPrefab;
        
        public override void InstallBindings()
        {
            BindSpawnPointHandler();
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<EnemySpawner>().AsSingle();
        }
        
        private void BindSpawnPointHandler()
        {
            SpawnPointHandler spawnPointHandler = Container.InstantiatePrefabForComponent<SpawnPointHandler>(_spawnPointHandlerPrefab);
            Container.Bind<SpawnPointHandler>().FromInstance(spawnPointHandler).AsSingle();
        }
    }
}
