#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace GeekSpace
{
    public class ParameterSettings : EditorWindow
    {
        private int[] _posX = new int[] { 80, 200 };
        private const int _height = 20;
        private bool PlayerLockShoot = false;
        private bool ShipLockShoot = false;
        private static bool CheckStart = true;
        private const int LineString = 20;
        private static int[] _posY;
        [MenuItem("Инструменты/ Окна/ Настройки объектов")]
        public static void ShowWindowSettingGame()
        {
            GetWindow(typeof(ParameterSettings), false, "Настройки объектов");
            Started();
        }

        private void OnGUI()
        {
            EntityData._Player._speed     = LabelSlider(20, EntityData._Player._speed,    ref EntityData._Player._maxSpeed, "Player Speed");//connected
            EntityData._Player._HP   = (int)LabelSlider(40, EntityData._Player._HP,       ref EntityData._Player._maxHP, "Player HP");//connected
            EntityData._Player._speedFire = LabelSlider(60, EntityData._Player._speedFire,ref EntityData._Player._maxSpeedFire, "Player SpeedFire");//connected
            PlayerLockShoot = GUI.Toggle(new Rect(_posX[0], 80, 150, _height), PlayerLockShoot, "Player Lock Shoot");//connected
            if (PlayerLockShoot) EntityData._Player._shootBlocked = 1; else EntityData._Player._shootBlocked = 0;

            EntityData._Ship._speed = LabelSlider(120, EntityData._Ship._speed,        ref EntityData._Ship._maxSpeed, "Ship Speed");
            EntityData._Ship._HP = (int)LabelSlider(140, EntityData._Ship._HP,         ref EntityData._Ship._maxHP, "Ship HP");
            EntityData._Ship._speedFire = LabelSlider(160, EntityData._Ship._speedFire,ref EntityData._Ship._maxSpeedFire, "Ship SpeedFire");//connected
            ShipLockShoot = GUI.Toggle(new Rect(_posX[0], 180, 150, _height), ShipLockShoot, "Ship Lock Shoot");//connected
            if (ShipLockShoot) EntityData._Ship._shootBlocked = 1; else EntityData._Ship._shootBlocked = 0;

            EntityData._Asteroid._speed = LabelSlider(220, EntityData._Asteroid._speed,ref EntityData._Ship._maxSpeed, "Asteroid Speed");
            EntityData._Asteroid._HP = (int)LabelSlider(240, EntityData._Asteroid._HP, ref EntityData._Ship._maxHP, "Asteroid HP");
        }


        float LabelSlider(int posY, float sliderValue, ref float sliderMaxValue, string labelText)
        {
            string inStrVolue;
            string inStrMaxVolue;
            Rect sliderRect1 = new Rect(_posX[0] + _posX[1] / 2, posY, _posX[1] / 2, _height);
            Rect labelRect = new Rect(_posX[0], posY, _posX[1] / 2, _height);
            Rect labelRect2 = new Rect(_posX[0] + _posX[1] + 5, posY, _posX[1] / 4, _height);
            Rect labelRect3 = new Rect(labelRect2);
            Rect labelRect4 = new Rect(labelRect2);
            labelRect3.x += 60;
            labelRect4.x += 100;
            GUILayout.BeginHorizontal();
            inStrMaxVolue = GUI.TextField(labelRect4, sliderMaxValue.ToString());
            sliderMaxValue = GetString(inStrMaxVolue);
            GUI.Label(labelRect, labelText);
            GUI.Label(labelRect3, "Max");
            sliderValue = GUI.HorizontalSlider(sliderRect1, sliderValue, 0.0f, sliderMaxValue);
            inStrVolue = GUI.TextField(labelRect2, sliderValue.ToString());
            sliderValue = GetString(inStrVolue);
            GUILayout.EndHorizontal();
            return sliderValue;
        }
        private float GetString(string str)
        {
            float tmp = 0f;
            float.TryParse(str, out tmp);
            return tmp;
        }
        static void Started()
        {
            if(CheckStart)
            {
                CheckStart = false;
                
                _posY = new int[LineString];
                for(int i=0;i< LineString;i++)
                {
                    _posY[i] =i*20+20;
                }
            }
        }
    }
}
#endif