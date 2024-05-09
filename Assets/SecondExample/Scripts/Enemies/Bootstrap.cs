using SecondExample.Scripts.Enemies;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        _spawner = spawner;
        _spawner.StartWork();
    }
}
