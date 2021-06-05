using System;
using System.Collections.Generic;
using Ships.Weapons.Projectiles;
using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "ShipGame/Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
    public class ProjectilesConfiguration : ScriptableObject
    {
       
        [SerializeField] private Projectile[] _projectilePrefabs;
        private Dictionary<string, Projectile> _idToProjectilePrefab;

        private void Awake()
        {
            _idToProjectilePrefab = new Dictionary<string, Projectile>();
            foreach (var projectile in _projectilePrefabs)
                _idToProjectilePrefab.Add(projectile.Id, projectile);
        }

        public Projectile GetProjectileById(string id)
        {
            if (!_idToProjectilePrefab.TryGetValue(id, out var projectile))
                throw new Exception("Projectile {id} not found");
            
            return projectile;
        }
    }
}