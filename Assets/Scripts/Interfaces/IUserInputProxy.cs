using System;

namespace GeekSpace
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis(string axis);
    }
}