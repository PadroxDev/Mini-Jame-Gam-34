using System;
using System.Collections;
using System.Collections.Generic;
using RengeGames.HealthBars;
using UnityEngine;

namespace MJG_34
{
    public class PlayerHealthHUD : MonoBehaviour {
        [SerializeField] HealthComponent _playerHealth;

        void Start() => UpdateHealth();

        void OnEnable() => _playerHealth.OnHealthChanged += UpdateHealth;
        void OnDisable() => _playerHealth.OnHealthChanged -= UpdateHealth;

        void UpdateHealth() {
            StatusBarsManager.SetPercent("Player", "Health", _playerHealth.NormalizedHealth);
        }
    }
}
