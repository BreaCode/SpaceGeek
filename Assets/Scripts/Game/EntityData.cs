using UnityEngine;

namespace GeekSpace
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Game")]
    public class EntityData : ScriptableObject
    {
        [SerializeField] public static Entity _Player = new Entity
        (PlayerParametrsManager.PLAYER_SPEED, PlayerParametrsManager.PLAYER_HEALTH, WeaponParametrsManager.DEFAULT_RELOAD_COOLDOWN);
        [SerializeField] public static Entity _Ship = new Entity
        (EnemyParametrsManager.SHIP_SPEED, EnemyParametrsManager.SHIP_HEALTH, 1);
        [SerializeField] public static Entity _Asteroid = new Entity
        (EnemyParametrsManager.ASTEROID_SPEED, EnemyParametrsManager.ASTEROID_HEALTH, 1);
    }
}
