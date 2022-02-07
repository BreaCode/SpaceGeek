using UnityEngine;
namespace GeekSpace
{
    public sealed class GameStarter : MonoBehaviour
    {
        #region Fields
        private Controllers _controllers;
        [SerializeField] private GameData gameData;
        #endregion
        #region UnityMethods
        void Start()
        {
            _controllers = new Controllers();

            IGameStrategy result = gameData._GameType switch
            {
                GameType.SINGLE => new GameSinglInitialisation(_controllers, new SinglGameFactory(_controllers,gameData), gameData),
                GameType.MULTIPLAYER => new GameInitialisationMultiplayer(_controllers,new MultiplayerGameFactory(_controllers,gameData), gameData),
                _ => new GameSinglInitialisation(_controllers, new SinglGameFactory(_controllers,gameData), gameData),
            };


            _controllers.Initialization();

        }
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
        #endregion
    }
}