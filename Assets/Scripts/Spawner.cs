using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class Spawner : MonoBehaviour {

    public float spawnTimer = 3, seconds, minXPosition = -8f, maxXposition = 8f;
    public GameObject spawningObject, spawnedObject, levelSettings;
    public Vector3 pos;
    public Quaternion rot;
    SpriteRenderer sr;
    public Sprite[] spr;
    int rnd;

    void Update ()
    {
        SpawnTiming();          
	}
    void SpriteChange()
    {
        sr.sprite = spr[rnd];
    }
    void Spawn()
    {
        spawnedObject = Instantiate(spawningObject, pos, rot);
        spawnedObject.GetComponent<Positioning>().can = levelSettings;
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
}
