using UnityEngine;

namespace GeekSpace
{
    public sealed class GameSinglInitialisation : IGameStrategy
    {
        internal GameData gameData { get; }
        private IAbstractGameFactory _gameFactory;
        #region ClassLifeCycles
        internal GameSinglInitialisation(Controllers controllers, IAbstractGameFactory gameData)
        {
            this._gameFactory = gameData;
            GameInit();
        }

        public void GameInit()
        {
            _gameFactory.SetInput();
            _gameFactory.CreatePlayer();
            _gameFactory.CreateEnemy();

            var beyondScreenActer = new BeyondScreenActer();
        }
        #endregion
    }

}