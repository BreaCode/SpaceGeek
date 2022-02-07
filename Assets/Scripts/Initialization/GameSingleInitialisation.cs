using UnityEngine;

namespace GeekSpace
{
    public sealed class GameSinglInitialisation : IGameStrategy
    {
        private IAbstractGameFactory _gameFactory;
        #region ClassLifeCycles
        internal GameSinglInitialisation( IAbstractGameFactory fabric)
        {
            this._gameFactory = fabric;
            GameInit();
        }

        public void GameInit()
        {
            _gameFactory.SetInput(new InputInitializatioAxis());
            _gameFactory.CreatePlayer();
            _gameFactory.CreateEnemy();

            var beyondScreenActer = new BeyondScreenActer();
        }
        #endregion
    }

}