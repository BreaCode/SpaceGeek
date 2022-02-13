using UnityEngine;

namespace GeekSpace
{
    internal class BulletPoolFactory
    {
        internal static ObjectPool BulletPoolCreate(WeaponType weaponType)
        {
            var bulletPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
            switch (weaponType)
            {
                case WeaponType.ChainGunMk1:
                    bulletPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
                    break;
                case WeaponType.LaserGunMk1:
                    bulletPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
                    break;
            }
            var root = new ParrentStruct(Vector2.zero, NameManager.POOL_ENEMY_BULLET);
            var bulletPool = new ObjectPool(bulletPrefab.gameObject, root);

            return bulletPool;
        }
    }
}
