using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSettings : MonoBehaviour {

    float timer=0;
    public Vector3 platformSpeed;
    int lvl = 0, lvlTime;
    public float[] platformSpeedXValues, platformSpeedYValues;
    public int[] lvlTimeValues;
    public Transform platformPos;
    public GameObject platform;
    public Camera cam;
    public Vector2 camDimensionsScreen, camDimensionsWorld;
    public float topLimit;



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
        CamDimensions();
    }

    void LevelTiming()
    {
        timer += Time.deltaTime;

        if (timer > lvlTime)
        {
            timer = 0;
            lvl++;
            lvlTime = lvlTimeValues[lvl];
            switch (lvl)
            {
                case 1:
                    {
                        platformSpeed.x = platformSpeedXValues[lvl];
                    }
                    break;
                case 2:
                    {
                        StartCoroutine(SpeedChange(.05f, 5f, .3f));
                    }
                    break;
                    //TO DO
            }
        }
    }

    void MovementSettings()
    {
        if (platformPos.position.x + platform.GetComponent<SpriteRenderer>().bounds.size.x/2 > camDimensionsScreen.x)
        {
            platformSpeed.x *= -1;
        }
        if (platformPos.position.x - platform.GetComponent<SpriteRenderer>().bounds.size.x / 2 < -camDimensionsScreen.x)
        {
            platformSpeed.x *= -1;
        }
        if (platformPos.position.y + platform.GetComponent<SpriteRenderer>().bounds.size.y / 2 > topLimit)
        {
            platformSpeed.y *= -1;
        }
        if (platformPos.position.y - platform.GetComponent<SpriteRenderer>().bounds.size.y / 2 < -camDimensionsScreen.y)
        {
            platformSpeed.y *= -1;
        }

        

    }
    void CamDimensions()
    {
        camDimensionsWorld.x = cam.pixelWidth;
        camDimensionsWorld.y = cam.pixelHeight;
        camDimensionsScreen = cam.ScreenToWorldPoint(camDimensionsWorld);
    }

    IEnumerator SpeedChange(float speedChange, float time, float maxSpeed)
    {
        while (Mathf.Abs(platformSpeed.x)<maxSpeed)
        {
            if (platformSpeed.x < 0)
            {
                platformSpeed.x -= speedChange;
            }
            else platformSpeed.x += speedChange;
            
            yield return new WaitForSeconds(time);
        }

    }
}
