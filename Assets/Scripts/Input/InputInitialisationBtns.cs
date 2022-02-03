using UnityEngine;

namespace GeekSpace
{
    internal class InputInitialisationBtns : IInitialisation, IInputInitialisation
    {

        readonly private IUserInputFire _pcInputFire;

        KeyCode _left;
        KeyCode _right;
        KeyCode _up;
        KeyCode _down;

        public InputInitialisationBtns((KeyCode left, KeyCode right,KeyCode up, KeyCode down) GetKey)
        {
            _left = GetKey.left;
            _right = GetKey.right;
            _up = GetKey.up;
            _down = GetKey.down;

        }

        public void Initialization()
        {

        }

        public bool GetUp()
        {
            return (Input.GetKey(_up)) ? true : false;
        }

        public bool GetDown()
        {
            return (Input.GetKey(_down)) ? true : false;
        }

        public bool GetLeft()
        {
            return (Input.GetKey(_left)) ? true : false;
        }

        public bool GetRight()
        {
            return (Input.GetKey(_right)) ? true : false;
        }
    }
}