using UnityEngine.Video;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public Camera cam;
    
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("KRAAAJ");

        }
	}
}
