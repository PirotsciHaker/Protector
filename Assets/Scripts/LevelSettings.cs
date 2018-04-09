using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSettings : MonoBehaviour {

    float timer=0;
    public Vector3 platformSpeed;
    int lvl = 0;
    int lvlTime;
    public float[] platformSpeedXValues, platformSpeedYValues;
    public int[] lvlTimeValues;
    public GameObject platform;
    public Canvas canvas;



    void Start ()
    {
        platformSpeed.x = platformSpeedXValues[0];
        platformSpeed.y = platformSpeedYValues[0];
        lvlTime = lvlTimeValues[0];
    }
	

	void Update ()
    {
        LevelTiming();
        MovementSettings();
    }

    void LevelTiming()
    {
        timer += Time.deltaTime;

        if (timer > lvlTime)
        {
            timer = 0;
            lvl++;
            platformSpeed.x = platformSpeedXValues[lvl];
            platformSpeed.y = platformSpeedYValues[lvl];
            lvlTime = lvlTimeValues[lvl];
        }
    }

    void MovementSettings()
    {
        if (platform)
        { }
        switch (lvl)
        {
            case 1: 
                break;
            //TO DO
        }

    }
}
