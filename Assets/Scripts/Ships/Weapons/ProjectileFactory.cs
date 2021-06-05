using UnityEngine;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;

        public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
        {
            _projectilesConfiguration = projectilesConfiguration;
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation)
        {
            var prefab = _projectilesConfiguration.GetProjectileById(id);
            return Object.Instantiate(prefab, position, rotation);
        }
    }
}