using UnityEngine;

namespace GeekSpace
{
    public interface IDynamicModel : IModel
    {
        public Vector3 Position { get; set; }
        public GameObject Object { get; set; }

        public IPool Pool { get; set; }
    }
}

