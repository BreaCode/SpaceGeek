using System;
using UnityEngine;

namespace GeekSpace
{
    public sealed class GameEventSystem : MonoBehaviour
    {
        public static GameEventSystem current;

        void Awake()
        {
            current = this;
        }

        public event Action onWin;
        public void Win()
        {
            if (onWin != null)
            {
                onWin();
            }
        }
        public event Action<GameObject> onGoingBeyondScreen;
        public void goingBeyondScreen(GameObject gameObject)
        {
            if (onGoingBeyondScreen != null)
            {
                onGoingBeyondScreen(gameObject);
            }
        }
        public event Action onScoreUpdate;
        public void ScoreUpdate()
        {
            if (onScoreUpdate != null)
            {
                onScoreUpdate();
            }
        }
        public event Action onSpeedUpdate;
        public void SpeedUpdate()
        {
            if (onSpeedUpdate != null)
            {
                onSpeedUpdate();
            }
        }
        public event Action<string> onControlUpdate;
        public void ControlUpdate(string controlType)
        {
            if (onControlUpdate != null)
            {
                onControlUpdate(controlType);
            }
        }
    }
}

