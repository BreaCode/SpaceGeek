using UnityEngine;

namespace GeekSpace
{
    public sealed class GameSinglInitialisation : IGameStrategy
    {
        private readonly GameData _gameData;
        private IAbstractGameFactory _gameFactory;
        #region ClassLifeCycles
        internal GameSinglInitialisation(Controllers controllers, IAbstractGameFactory fabric,GameData gameData)
        {
            this._gameFactory = fabric;
            _gameData = gameData;
            GameInit();
        }

        public void GameInit()
        {
            _gameFactory.SetInput(new InputInitialisationBtns(_gameData));
            _gameFactory.CreatePlayer();
            _gameFactory.CreateEnemy();

            var beyondScreenActer = new BeyondScreenActer();
        }
        #endregion
    }

}