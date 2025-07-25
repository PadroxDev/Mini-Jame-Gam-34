using System;
using Padrox.Acelab.Core;
using UnityEngine;

namespace MJG_34 {
    public class Enemy : MonoBehaviour {
        const string k_playerTag = "Player";
        
        float _speed = 3f;
        int _damage = 1;
        MoveStrategy _moveStrategy;
        Rigidbody _rb;

        public static EnemyBuilder Create => new EnemyBuilder();
        
        public void SetSpeed(float speed) {
            _speed = speed;
        }
        
        public void SetMoveStrategy(MoveStrategy moveStrategy) {
            _moveStrategy = moveStrategy;
        }

        public void SetDamage(int damage) {
            _damage = damage;
        }
        
        void Start() {
            _rb = gameObject.GetOrAdd<Rigidbody>();
            _moveStrategy.Initialize();
        }

        public void FixedUpdate() {
            _moveStrategy.Move(ref _rb, _speed);
        }

        void OnCollisionEnter(Collision other) {
            if (!other.gameObject.CompareTag(k_playerTag)) return;

            if (other.gameObject.TryGetComponent(out HealthComponent healthComponent)) {
                healthComponent.TakeDamage(_damage);
            }
            
            Destroy(gameObject);
        }
    }
}