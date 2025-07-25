using UnityEngine;

namespace MJG_34 {
    [CreateAssetMenu(menuName = "MJG_34/EnemyType", fileName = "New Enemy Type")]
    public class EnemyType : ScriptableObject {
        public Enemy prefab;
        public float speed = 3f;
        public int damage = 1;
        public MoveStrategy MoveStrategy;
    }
}