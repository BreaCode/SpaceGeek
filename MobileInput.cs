using System;
using UnityEngine;

namespace GeekSpace
{
    internal sealed class MobileInput : IUserInputProxy
    {
        public event Action<float> AxisOnChange;
        public void GetAxis()
        {
            Debug.Log("нажали кнопку!");
        }

        public void GetFire()
        {
            Debug.Log("нажали на кнопку выстрела.");
        }
    }
}
