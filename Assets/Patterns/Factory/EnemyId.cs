using UnityEngine;

namespace Patterns.Factory
{
    [CreateAssetMenu(menuName = "Factory/Create EnemyId", fileName = "EnemyId", order = 0)]
    public class EnemyId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}