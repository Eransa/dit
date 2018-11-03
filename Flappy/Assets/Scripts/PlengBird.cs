using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlengBird : MonoBehaviour {
    //标题含义：扑棱扑棱的鸟
    public Rigidbody2D Bird;
    private float t;

	// Use this for initialization
	void Start () {
        t = Time.time;
        Bird.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.state == GameManager.State.reReady)
        {
            t = Time.time;
            Bird.isKinematic = true;
            Bird.velocity = new Vector2(0.0f, 0.03f);
        }
        if (Time.time - t > 0.2f)
        {
            Bird.velocity = new Vector2(0.0f, 1.03f);  
        }
        if(Time.time-t>0.4f)
        {
            Bird.velocity = new Vector2(0.0f, -1.0f);
            t = Time.time;
        }    
        
        if(GameManager.state==GameManager.State.Playing)
        {
            Bird.isKinematic = false;
            GameObject.Find("Bird").GetComponent<FlyBird>().enabled = true;
            GameObject.Find("Bird").GetComponent<PlengBird>().enabled = false;
        }
    }
}
