using UnityEngine;

namespace MJG_34 {
    public abstract class MoveStrategy : ScriptableObject {
        public virtual void Initialize() { }
        public abstract void Move(ref Rigidbody rb, float speed);
    }
}