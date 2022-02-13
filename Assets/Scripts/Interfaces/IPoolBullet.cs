using UnityEngine;

namespace GeekSpace
{
    public interface IPoolBullet 
    {
        public GameObject Pop(Vector3 position, Quaternion quaternion);
        public void Push(GameObject go);
    }
}
