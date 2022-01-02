using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    public GameObject prefabGameObject;
    private TimerSystem timerSystem;
    // Start is called before the first frame update
    void Start()
    {
        timerSystem = new TimerSystem(true, true, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerSystem.CheckEvent())
        {
            GameObject prefGameObject = Instantiate(prefabGameObject, transform.position, transform.rotation) as GameObject;
        }
    }
}
