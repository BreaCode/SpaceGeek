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
            newPosition = model.Position;
            if (newPosition.y <= ScreenBordersManager.LEFT_SIDE || newPosition.y >= ScreenBordersManager.RIGHT_SIDE)
            {
                newPosition.y *= -1;
            }
            else if (newPosition.x <= ScreenBordersManager.DOWN_SIDE || newPosition.x >= ScreenBordersManager.UPPER_SIDE)
            {
                newPosition.x *= -1;
            }
            model.Position = newPosition;
        }

        ~BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen -= GoingBeyondScreen;
        }
    }
}

