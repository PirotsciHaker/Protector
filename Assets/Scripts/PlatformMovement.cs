using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public GameObject level;
    public Vector3 position;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();    
	}
	
	// Update is called once per frame
	void Update () {
        position.x = GetComponent<Transform>().position.x + level.GetComponent<LevelSettings>().platformSpeed.x;
        position.y = GetComponent<Transform>().position.y + level.GetComponent<LevelSettings>().platformSpeed.y;
        rb.transform.SetPositionAndRotation(position,transform.rotation);
	}
}
