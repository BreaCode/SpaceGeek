using System;

namespace GeekSpace
{
    public interface IUserInputFire
    {
        event Action<float> AxisOnChange;
        void GetFire();
    }
}