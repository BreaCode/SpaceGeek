using UnityEngine;

namespace GeekSpace
{
    internal sealed class InputInitialization : IInitialization
    {
        readonly private IUserInputProxy _pcInputHorizontal;
        readonly private IUserInputProxy _pcInputHorizontalTwo;
        readonly private IUserInputProxy _pcInputVertical;
        readonly private IUserInputFire _pcInputFire;

        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _pcInputHorizontal = new MobileInput();
                _pcInputHorizontalTwo = new MobileInput();
                return;
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputHorizontalTwo = new PCInputHorizontalTwo();
            _pcInputVertical = new PCInputVertical();
            _pcInputFire = new PCInputFire();
        }

        public void Initialization()
        {
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputHorizontalTwo, IUserInputProxy inputVertical, IUserInputFire pcIinputFire) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputHorizontalTwo, IUserInputProxy inputVertical, IUserInputFire pcInputFire) result = (_pcInputHorizontal, _pcInputHorizontalTwo, _pcInputVertical, _pcInputFire);
            return result;
        }
    }
}