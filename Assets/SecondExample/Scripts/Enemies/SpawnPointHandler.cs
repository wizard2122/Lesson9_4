using System.Collections.Generic;
using UnityEngine;

namespace SecondExample.Scripts.Enemies
{
    public class SpawnPointHandler : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;

        public Vector3 GetRandomPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        }
    }
}