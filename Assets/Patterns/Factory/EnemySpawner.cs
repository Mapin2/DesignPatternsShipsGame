using System;
using UnityEngine;

namespace Patterns.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyId _enemyId1;
        [SerializeField] private EnemyId _enemyId2;

        [SerializeField] private EnemiesConfiguration _enemiesConfiguration;
        private EnemyFactory _enemyFactory;

        private void Awake()
        {
            _enemyFactory = new EnemyFactory(Instantiate(_enemiesConfiguration));
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                _enemyFactory.Create(_enemyId1.Value);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                _enemyFactory.Create(_enemyId2.Value);
            }
        }
    }
}
