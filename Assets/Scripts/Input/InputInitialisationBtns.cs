using UnityEngine;

namespace GeekSpace
{
    internal class InputInitialisationBtns : IInitialisation, IInputInitialisation
    {

        readonly private IUserInputFire _pcInputFire;
        private readonly GameData _gameData;

        public InputInitialisationBtns(GameData gameData)
        {
            this._gameData = gameData;
        }

        public void Initialization()
        {

        }

        public bool GetUp()
        {
            return (Input.GetKey(_gameData.UP)) ? true : false;
        }

        public bool GetDown()
        {
            return (Input.GetKey(_gameData.DOWN)) ? true : false;
        }

        public bool GetLeft()
        {
            return (Input.GetKey(_gameData.LEFT)) ? true : false;
        }

        public bool GetRight()
        {
            return (Input.GetKey(_gameData.RIGHT)) ? true : false;
        }
    }
}