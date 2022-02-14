#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class ParameterSettings : EditorWindow
{
    private  GeekSpace.Entity _Player = new GeekSpace.Entity
        (GeekSpace.PlayerParametrsManager.PLAYER_SPEED, GeekSpace.PlayerParametrsManager.PLAYER_HEALTH,1);
    private  GeekSpace.Entity _Ship = new GeekSpace.Entity
        (GeekSpace.EnemyParametrsManager.SHIP_SPEED, GeekSpace.EnemyParametrsManager.SHIP_HEALTH,1);
    private  GeekSpace.Entity _Asteroid = new GeekSpace.Entity
        (GeekSpace.EnemyParametrsManager.ASTEROID_SPEED, GeekSpace.EnemyParametrsManager.ASTEROID_HEALTH,1);
    private int[] _posX = new int[] { 80, 200 };
    private const int _height = 20;
    private bool start = true;
    public  float[] Sliders;
    [MenuItem("Инструменты/ Окна/ Настройки объектов")]
    public static void ShowWindowSettingGame()
    {
        GetWindow(typeof(ParameterSettings), false, "Настройки объектов");
    }

    private void OnGUI()
    {
        SetData();

        Sliders[0] = LabelSlider( 20,  Sliders[0], _Player._maxSpeed, "Player Speed");
        Sliders[1] = LabelSlider( 40,  Sliders[1], _Player._maxHP, "Player HP");
        Sliders[2] = LabelSlider( 60,  Sliders[2], _Player._speedFire, "Player SpeedFire");

        Sliders[3] = LabelSlider( 100,  Sliders[3], _Ship._maxSpeed, "Ship Speed");
        Sliders[4] = LabelSlider( 120, Sliders[4], _Ship._maxHP, "Ship HP");
        Sliders[5] = LabelSlider( 140, Sliders[6], _Ship._speedFire, "Ship SpeedFire");

        Sliders[6] = LabelSlider(180, Sliders[6], _Ship._maxSpeed, "Asteroid Speed");
        Sliders[7] = LabelSlider(200, Sliders[7], _Ship._maxHP, "Asteroid HP");
    }

    
    float LabelSlider(int posY, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUILayout.BeginHorizontal();
        Rect labelRect = new Rect(_posX[0], posY, _posX[1] / 2, _height);
        GUI.Label(labelRect, labelText); 
        Rect sliderRect = new Rect(_posX[0] + _posX[1] / 2, posY, _posX[1] / 2, _height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
        Rect labelRect1 = new Rect(_posX[0]+ _posX[1], posY, _posX[1] / 2, _height);
        GUI.Label(labelRect1, sliderValue.ToString());
        GUILayout.EndHorizontal();
        return sliderValue;
    }
    void SetData()
    {
        if(start)
        {
            start = false;
            Sliders = new float[8]
            {
                _Player._speed,
                _Player._HP,
                _Player._speedFire,
                _Ship._speed,
                _Ship._HP,
                _Ship._speedFire,
                _Asteroid._speed,
                _Asteroid._HP
            };
        }
        
    }
}
#endif