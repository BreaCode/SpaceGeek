using UnityEngine;

namespace GeekSpace
{
    public interface IPoolEnemy
    {
        public GameObject Pop(Vector3 position, Quaternion quaternion);
        public void Push(GameObject go);
    }
}
