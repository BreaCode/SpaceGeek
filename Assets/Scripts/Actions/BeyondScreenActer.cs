using UnityEngine;

namespace GeekSpace
{
    internal sealed class BeyondScreenActer
    {
     

        internal BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen += GoingBeyondScreen;
        }

        private void GoingBeyondScreen(IDynamicModel model)
        {
            if (model is EnemyModel || model is BulletModel)
            {
                model.Pool.Push(model.Object);
            }
            else if (model is PlayerModel)
            {
                Vector3 newPosition = new Vector3();
                newPosition = model.Object.transform.position;
                if (newPosition.x <= ScreenBordersManager.LEFT_SIDE || newPosition.x >= ScreenBordersManager.RIGHT_SIDE)
                {
                    newPosition.x *= -1;
                }
                else if (newPosition.y <= ScreenBordersManager.DOWN_SIDE || newPosition.y >= ScreenBordersManager.UPPER_SIDE)
                {
                    newPosition.y *= -1;
                }
                model.Object.transform.position = newPosition;
            }
            else
            {
                Debug.Log("Model Error");
            }

        }

        ~BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen -= GoingBeyondScreen;
        }
    }
}

