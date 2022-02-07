using UnityEngine;

namespace GeekSpace
{
    internal class InputInitialisationBtnsTwo : IInitialisationTwo, IInputInitialisationTwo
    {

        readonly private IUserInputFire _pcInputFireTwo;
        private readonly GameData _gameData;

        public InputInitialisationBtnsTwo(GameData gameData)
        {
            this._gameData = gameData;
        }

        public void InitializationTwo()
        {

        }

        public bool GetUp()
        {
            return (Input.GetKey(_gameData.AltUP)) ? true : false;
        }

        public bool GetDown()
        {
            return (Input.GetKey(_gameData.AltDOWN)) ? true : false;
        }

        public bool GetLeft()
        {
            return (Input.GetKey(_gameData.AltLEFT)) ? true : false;
        }

        public bool GetRight()
        {
            return (Input.GetKey(_gameData.AltRIGHT)) ? true : false;
        }
    }
}