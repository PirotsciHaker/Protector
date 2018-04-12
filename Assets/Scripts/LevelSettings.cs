using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSettings : MonoBehaviour {

    float timer=0;
    public Vector3 platformSpeed;
    int lvl = 0, lvlTime, maxLvl = 5;
    public float[] platformSpeedXValues, platformSpeedYValues;
    public int[] lvlTimeValues;
    public Transform platformPos;
    public GameObject platform;
    public Camera cam;
    public Vector2 camDimensionsScreen, camDimensionsWorld, lvl2SpeedChange, lvl4SpeedChange;
    public float topLimit, minXSpeed, maxXSpeed, minYSpeed, maxYSpeed, minTime, maxTime;



    void Start ()
    {
        platformSpeed.x = platformSpeedXValues[0];
        platformSpeed.y = platformSpeedYValues[0];
        lvlTime = lvlTimeValues[0];
    }
	

	void Update ()
    {
        if (lvl < maxLvl)
        {
            LevelTiming();
        }
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
            if (lvl < maxLvl)
            {
                lvlTime = lvlTimeValues[lvl];
            }
            switch (lvl)
            {
                case 1:
                    {
                        platformSpeed.x = platformSpeedXValues[lvl];
                    }
                    break;
                case 2:
                    {
                        StartCoroutine(SpeedChangeX(lvl2SpeedChange.x, lvl2SpeedChange.y, platformSpeedXValues[lvl]));
                    }
                    break;
                case 3:
                    {
                        platformSpeed.y = platformSpeedYValues[lvl];
                    }
                    break;
                case 4:
                    {
                        StartCoroutine(SpeedChangeY(lvl4SpeedChange.x, lvl4SpeedChange.y, platformSpeedYValues[lvl]));
                    }
                    break;
                case 5:
                    {
                        StartCoroutine(RandomSpeed(minXSpeed, maxXSpeed, minYSpeed,maxYSpeed,minTime,maxTime));
                    }
                    break;
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

    IEnumerator SpeedChangeX(float speedChange, float time, float maxSpeed)
    {
        while (Mathf.Abs(platformSpeed.x) < maxSpeed)
        {  
            if (platformSpeed.x < 0)
            {
                platformSpeed.x -= speedChange;
            }
            else platformSpeed.x += speedChange;

            if (Mathf.Abs(platformSpeed.x) > maxSpeed)
            {
                platformSpeed.x = maxSpeed;
            }

            yield return new WaitForSeconds(time);
        }

    }

    IEnumerator SpeedChangeY(float speedChange, float time, float maxSpeed)
    {
        while (Mathf.Abs(platformSpeed.y) < maxSpeed)
        {
            if (platformSpeed.y < 0)
            {
                platformSpeed.y -= speedChange;
            }
            else platformSpeed.y += speedChange;

            if (Mathf.Abs(platformSpeed.y) > maxSpeed)
            {
                platformSpeed.y = maxSpeed;
            }

            yield return new WaitForSeconds(time);
        }

    }
    IEnumerator RandomSpeed(float minXSpeed, float maxXSpeed, float minYSpeed, float maxYSpeed, float minTime, float maxTime)
    {
        while (true)
        {
            platformSpeed.x = Random.Range(minXSpeed, maxYSpeed);
            platformSpeed.y = Random.Range(minYSpeed,maxYSpeed);
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
