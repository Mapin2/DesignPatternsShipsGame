using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "ShipGame/Create ProjectileId", fileName = "ProjectileId", order = 0)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}