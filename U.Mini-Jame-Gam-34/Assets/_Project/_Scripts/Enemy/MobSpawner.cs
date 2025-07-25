using Padrox.Acelab.Core;
using Padrox.Acelab.Timers;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace MJG_34
{
    public class MobSpawner : MonoBehaviour {
        [SerializeField] float _spawnCooldown = 4f;
        [SerializeField] float _spawnCooldownVariation = 0.3f;
        [SerializeField] float _spawnMinRadius = 8f;
        [SerializeField] float _spawnMaxRadius = 12f;
        [SerializeField] EnemyType[] _enemyTypes;
        
        FrequencyRandomizedTimer _timer;

        void Start() {
            _timer = new FrequencyRandomizedTimer(_spawnCooldown, _spawnCooldownVariation);
            _timer.OnTick += SpawnMob;
            _timer.Start();
        }

        void SpawnMob() {
            EnemyType type = _enemyTypes[Random.Range(0, _enemyTypes.Length)];
            Vector3 position = Vector3.zero.RandomPointInAnnulus(_spawnMinRadius, _spawnMaxRadius);
            var enemy = EnemyFactory.Create(type, position, Quaternion.identity);
            _timer.Start();
        }

        void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Vector3 pos = transform.position.Add(y: 0.2f);
            Gizmos.DrawLine(pos + Vector3.right * _spawnMinRadius, pos + Vector3.right * _spawnMaxRadius);
            Gizmos.DrawLine(pos + Vector3.left * _spawnMinRadius, pos + Vector3.left * _spawnMaxRadius);
            Gizmos.DrawLine(pos + Vector3.forward * _spawnMinRadius, pos + Vector3.forward * _spawnMaxRadius);
            Gizmos.DrawLine(pos + Vector3.back * _spawnMinRadius, pos + Vector3.back * _spawnMaxRadius);
            
            Gizmos.DrawLine(pos + (Vector3.right + Vector3.forward).normalized * _spawnMinRadius, pos + (Vector3.right + Vector3.forward).normalized * _spawnMaxRadius);
            Gizmos.DrawLine(pos + (Vector3.right + Vector3.back).normalized * _spawnMinRadius, pos + (Vector3.right + Vector3.back).normalized * _spawnMaxRadius);
            Gizmos.DrawLine(pos + (Vector3.left + Vector3.forward).normalized * _spawnMinRadius, pos + (Vector3.left + Vector3.forward).normalized * _spawnMaxRadius);
            Gizmos.DrawLine(pos + (Vector3.left + Vector3.back).normalized * _spawnMinRadius, pos + (Vector3.left + Vector3.back).normalized * _spawnMaxRadius);
        }
    }
}
