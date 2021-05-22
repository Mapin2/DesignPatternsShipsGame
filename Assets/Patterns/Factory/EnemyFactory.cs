using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory
{
    public class EnemyFactory
    {
        private readonly EnemiesConfiguration _enemiesConfiguration;

        public EnemyFactory(EnemiesConfiguration enemiesConfiguration)
        {
            _enemiesConfiguration = enemiesConfiguration;
        }

        public void Create(string enemyId)
        {
            var enemyPrefab = _enemiesConfiguration.GetEnemyById(enemyId);
            Object.Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}