using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] private float _projectileLifeInSeconds;

        protected Transform _myTransform;

        public string Id => _id.Value;

        private void Start()
        {
            _myTransform = transform;
            DoStart();
            StartCoroutine(DestroyIn(_projectileLifeInSeconds));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        private void OnTriggerEnter2D(Collider2D other)
        {
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestory();
            Destroy(gameObject);
        }
        
        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }
        
        protected abstract void DoDestory();
    }
}