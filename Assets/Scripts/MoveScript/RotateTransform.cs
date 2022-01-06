using UnityEngine;

namespace GeekSpace
{
    internal class RotateTransform : IRotateble
    {
        Quaternion rotationZ;

        public void Rotate(Transform transform)
        {
            rotationZ = Quaternion.AngleAxis(1, new Vector3(0, 0, 1));
            transform.rotation *= rotationZ;
        }
    }
}
