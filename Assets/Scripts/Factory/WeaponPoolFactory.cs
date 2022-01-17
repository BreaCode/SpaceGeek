using UnityEngine;

namespace GeekSpace
{
    internal class WeaponPoolFactory
    {
        internal static ObjectPool WeaponPoolCreate(WeaponType weaponType)
        {
            var weaponPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
            switch (weaponType)
            {
                case WeaponType.ChainGunMk1:
                    weaponPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
                    break;
                case WeaponType.LaserGunMk1:
                    weaponPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));
                    break;
            }


            var poolRoot = new Vector3(0, 0, 0);
            var weaponPool = new ObjectPool(weaponPrefab.gameObject, poolRoot);

            return weaponPool;
        }
    }
}
