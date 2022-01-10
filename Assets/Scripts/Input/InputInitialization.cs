using UnityEngine;

namespace GeekSpace
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputFire _pcInputFire;

        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _pcInputHorizontal = new MobileInput();
                return;
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputFire = new PCInputFire();
        }

        public void Initialization()
        {
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputFire pcIinputFire) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputFire pcInputFire) result = (_pcInputHorizontal, _pcInputVertical, _pcInputFire);
            return result;
        }
    }
}