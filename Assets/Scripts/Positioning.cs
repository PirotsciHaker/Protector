using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Positioning : MonoBehaviour {
	
	void Update () {
        if (transform.position.y < -30)
        {
            DestroyObject(gameObject);
        }
		
	}
}
