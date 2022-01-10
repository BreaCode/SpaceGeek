using UnityEngine;
namespace GeekSpace
{
    public sealed class GameStarter : MonoBehaviour
    {
        #region Fields
        private Controllers _controllers;

        #endregion
        #region UnityMethods
        void Start()
        {
            _controllers = new Controllers();
            new GameInitialisation(_controllers);
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