using UnityEngine;

namespace MJG_34 {
    public class EnemyBuilder {
        Enemy _prefab;
        MoveStrategy _moveStrategy;
        float _speed = 3f;
        int _damage = 1;
        Vector3 _position = Vector3.zero;
        Quaternion _rotation = Quaternion.identity;
        static Transform _parent;

        static Transform Parent {
            get {
                if (_parent == null) {
                    _parent = new GameObject("Enemies").transform;
                }
                return _parent;
            }
        }

        public EnemyBuilder WithBasePrefab(Enemy prefab) {
            _prefab = prefab;
            return this;
        }
        
        public EnemyBuilder WithSpeed(float speed) {
            _speed = speed;
            return this;
        }

        public EnemyBuilder WithDamage(int damage) {
            _damage = damage;
            return this;
        }

        public EnemyBuilder WithMoveStrategy(MoveStrategy moveStrategy) {
            _moveStrategy = moveStrategy;
            return this;
        }
        
        public EnemyBuilder WithPosition(Vector3 position) {
            _position = position;
            return this;
        }
        
        public EnemyBuilder WithRotation(Quaternion rotation) {
            _rotation = rotation;
            return this;
        }
        
        public Enemy Build() {
            Enemy enemy = Object.Instantiate(_prefab, _position, _rotation, Parent);
            enemy.SetSpeed(_speed);
            enemy.SetDamage(_damage);
            enemy.SetMoveStrategy(_moveStrategy);
            return enemy;
        }
    }
}