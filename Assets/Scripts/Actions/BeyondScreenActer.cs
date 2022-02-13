using UnityEngine;

namespace GeekSpace
{
    internal sealed class BeyondScreenActer
    {
        internal BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen += GoingBeyondScreen;
            GameEventSystem.current.onGoingBeyondScreenEnemy += GoingBeyondScreenEnemy;
            GameEventSystem.current.onGoingBeyondScreenBullet += GoingBeyondScreenBullet;
        }
        private void GoingBeyondScreenEnemy(IDynamicModelEnemy model)
        {
            model.Pool.Push(model.Object);
        }
        private void GoingBeyondScreenBullet(IDynamicModelBullet model)
        {
            model.Pool.Push(model.Object);
        }
        private void GoingBeyondScreen(IDynamicModel model)
        {
            if (model == null) return;

            else if (model is PlayerModel)
            {

                float weightShip = Mathf.Round(model.Object.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.rect.width / 100) + 0.2f;

                float leftBorder = Extention.GetLeftSideValueAccordingCamera(Camera.main, weightShip);
                float rightBorder = Extention.GetRightSideValueAccordingCamera(Camera.main, weightShip);
                float upBorder = Extention.GetUpSideValueAccordingCamera(Camera.main, weightShip / 2);
                float DownBorder = Extention.GetDownSideValueAccordingCamera(Camera.main, weightShip / 2);

                Vector3 newPosition = new Vector3();
                newPosition = model.Object.transform.position;
                if (newPosition.x <= leftBorder || newPosition.x >= rightBorder)
                {
                    newPosition.x *= -1;
                }
                if (newPosition.y <= DownBorder || newPosition.y >= upBorder)
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
            GameEventSystem.current.onGoingBeyondScreenEnemy -= GoingBeyondScreenEnemy;
            GameEventSystem.current.onGoingBeyondScreenBullet -= GoingBeyondScreenBullet;
        }
    }
}

