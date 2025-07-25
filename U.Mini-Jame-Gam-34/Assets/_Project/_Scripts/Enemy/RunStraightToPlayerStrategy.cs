using Padrox.Acelab.Core;
using UnityEngine;

namespace MJG_34 {
    [CreateAssetMenu(menuName = "MJG_34/Move Strategy/Run Straight To Player", fileName = "RunStraightToPlayerStrategy")]
    public class RunStraightToPlayerStrategy : MoveStrategy {
        const string k_playerTag = "Player";
        
        [SerializeField] float _rotationSpeed;
        
        Transform _target;

        public override void Initialize() {
            _target = GameObject.FindGameObjectWithTag(k_playerTag)?.transform;
        }

        public override void Move(ref Rigidbody rb, float moveSpeed) {
            if (_target == null) return;

            Vector3 dir = (_target.position - rb.position).With(y: 0).normalized;
            rb.MovePosition(rb.position + dir * (moveSpeed * Time.fixedDeltaTime));
            
            Quaternion lookRotation = Quaternion.LookRotation(dir, rb.transform.up);
            Quaternion smoothRotation = Quaternion.Slerp(rb.rotation, lookRotation, Time.fixedDeltaTime * _rotationSpeed);
            rb.MoveRotation(smoothRotation);
        }
    }
}