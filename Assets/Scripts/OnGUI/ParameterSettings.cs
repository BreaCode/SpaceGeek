#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace GeekSpace
{
    public class ParameterSettings : EditorWindow
    {
        //private  GeekSpace.Entity _Player = new GeekSpace.Entity
        //    (GeekSpace.PlayerParametrsManager.PLAYER_SPEED, GeekSpace.PlayerParametrsManager.PLAYER_HEALTH, GeekSpace.WeaponParametrsManager.DEFAULT_RELOAD_COOLDOWN);
        //private  GeekSpace.Entity _Ship = new GeekSpace.Entity
        //    (GeekSpace.EnemyParametrsManager.SHIP_SPEED, GeekSpace.EnemyParametrsManager.SHIP_HEALTH,1);
        //private  GeekSpace.Entity _Asteroid = new GeekSpace.Entity
        //    (GeekSpace.EnemyParametrsManager.ASTEROID_SPEED, GeekSpace.EnemyParametrsManager.ASTEROID_HEALTH,1);
        private int[] _posX = new int[] { 80, 200 };
        private const int _height = 20;
        private bool start = true;
        private bool PlayerLockShoot = false;
        private bool ShipLockShoot = false;
        [MenuItem("Инструменты/ Окна/ Настройки объектов")]
        public static void ShowWindowSettingGame()
        {
            GetWindow(typeof(ParameterSettings), false, "Настройки объектов");
        }

        private void OnGUI()
        {
            EntityData._Player._speed = LabelSlider(20, EntityData._Player._speed, EntityData._Player._maxSpeed, "Player Speed");
            EntityData._Player._HP = (int)LabelSlider(40, EntityData._Player._HP, EntityData._Player._maxHP, "Player HP");
            EntityData._Player._speedFire = LabelSlider(60, EntityData._Player._speedFire, EntityData._Player._maxSpeedFire, "Player SpeedFire");
            PlayerLockShoot = GUI.Toggle(new Rect(_posX[0], 80, 150, _height), PlayerLockShoot, "Player Lock Shoot");

            EntityData._Ship._speed = LabelSlider(120, EntityData._Ship._speed, EntityData._Ship._maxSpeed, "Ship Speed");
            EntityData._Ship._HP = (int)LabelSlider(140, EntityData._Ship._HP, EntityData._Ship._maxHP, "Ship HP");
            EntityData._Ship._speedFire = LabelSlider(160, EntityData._Ship._speedFire, EntityData._Ship._maxSpeedFire, "Ship SpeedFire");
            ShipLockShoot = GUI.Toggle(new Rect(_posX[0], 180, 150, _height), ShipLockShoot, "Ship Lock Shoot");

            EntityData._Asteroid._speed = LabelSlider(220, EntityData._Asteroid._speed, EntityData._Ship._maxSpeed, "Asteroid Speed");
            EntityData._Asteroid._HP = (int)LabelSlider(240, EntityData._Asteroid._HP, EntityData._Ship._maxHP, "Asteroid HP");
        }


        float LabelSlider(int posY, float sliderValue, float sliderMaxValue, string labelText)
        {
            string inStr;
            GUILayout.BeginHorizontal();
            Rect labelRect = new Rect(_posX[0], posY, _posX[1] / 2, _height);
            GUI.Label(labelRect, labelText);
            Rect sliderRect = new Rect(_posX[0] + _posX[1] / 2, posY, _posX[1] / 2, _height);
            sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
            Rect labelRect1 = new Rect(_posX[0] + _posX[1] + 5, posY, _posX[1] / 4, _height);
            inStr = GUI.TextField(labelRect1, sliderValue.ToString());
            sliderValue = GetString(inStr);
            GUILayout.EndHorizontal();
            return sliderValue;
        }
        private float GetString(string str)
        {
            float tmp = 0f;
            float.TryParse(str, out tmp);
            return tmp;
        }
    }
}
#endif