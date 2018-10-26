using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour {
    public Rigidbody2D Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Camera.velocity = new Vector2(1.0f, 0.0f);
    }
}
