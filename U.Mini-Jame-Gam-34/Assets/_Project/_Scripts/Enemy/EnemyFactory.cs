using UnityEngine;

namespace MJG_34 {
    public static class EnemyFactory {
        public static Enemy Create(EnemyType enemyType, Vector3 position, Quaternion rotation) {
            return Enemy.Create
                .WithBasePrefab(enemyType.prefab)
                .WithSpeed(enemyType.speed)
                .WithDamage(enemyType.damage)
                .WithMoveStrategy(enemyType.MoveStrategy)
                .WithPosition(position)
                .WithRotation(rotation)
                .Build();
        }
    }
}