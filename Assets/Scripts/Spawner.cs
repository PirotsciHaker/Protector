using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class Spawner : MonoBehaviour {

    public float spawnTimer = 3, seconds, minXPosition = -8f, maxXposition = 8f;//, timer=0;
    public GameObject spawningObject, spawnedObject;
    public Vector3 pos;
   // public Vector3 platformSpeed;
    public Quaternion rot;
    SpriteRenderer sr;
    public Sprite[] spr;
    int rnd;//, lvl = 0;
  //  public int lvlTime=10;
   // public float[] platformSpeedXValues, platformSpeedYValues;
   // public int[] lvlTimeValues;

    private void Start()
    {
     //   platformSpeed.x = 0;
      //  platformSpeed.y = 0;
    }

    void Update () {

       // LevelTiming();
        SpawnTiming();
                     
	}
    void SpriteChange()
    {
        sr.sprite = spr[rnd];
    }
    void Spawn()
    {
        spawnedObject = Instantiate(spawningObject, pos, rot);
        switch (rnd)
        {
            case 0:
                break;
            case 1: spawnedObject.GetComponent<CircleCollider2D>().enabled = true;
                break;
            //TO DO
        }
        sr = spawnedObject.GetComponent<SpriteRenderer>();
    }
    void SpawnTiming()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            pos.x = UnityEngine.Random.Range(minXPosition, maxXposition);
            rnd = UnityEngine.Random.Range(0, spr.Length);
            pos.z = 0;
            spawnTimer = seconds;
            Spawn();
            SpriteChange();
        }
    }
   /* void LevelTiming()
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
    }*/
}
