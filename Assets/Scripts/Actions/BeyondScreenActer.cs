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

        ~BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen -= GoingBeyondScreen;
        }
    }
}

