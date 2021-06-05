using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        
        public string Id => _id.Value;
    }
}