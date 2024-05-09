using UnityEngine;

namespace SecondExample.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "EnemySpawnerConfigs/Config")]
    public class EnemySpawnerConfig: ScriptableObject
    {
        [SerializeField] private float _spawnCooldown;

        public float SpawnCooldown => _spawnCooldown;
    }
}
