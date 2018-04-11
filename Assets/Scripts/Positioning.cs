using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Positioning : MonoBehaviour
{
    public GameObject can;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (transform.position.y < - can.GetComponent<LevelSettings>().camDimensionsScreen.y)
        {
            DestroyObject(gameObject);
        }

    }
}
