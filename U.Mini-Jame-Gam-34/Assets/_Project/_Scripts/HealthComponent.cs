using System;
using UnityEngine;
using UnityEngine.Events;

namespace MJG_34 {
    public class HealthComponent : MonoBehaviour {
        [SerializeField] int _maxHealth = 18;
        int _currentHealth;

        public UnityAction OnHealthChanged = delegate { };
        
        public int CurrentHealth => _currentHealth;
        public float NormalizedHealth => Mathf.Clamp01(_currentHealth / (float)_maxHealth);
        
        void Start() {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount) {
            _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);
            OnHealthChanged.Invoke();
            
            if(_currentHealth <= 0) {
                Die();
            }
        }

        void Die() {
            Debug.Log("Player died !");
        }
    }
}