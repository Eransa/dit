using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshGround : MonoBehaviour {

    public GameObject Ground;
    float t, tNow,x;
    int i;

	// Use this for initialization
	void Start ()
    {
        t = Time.time;
        x = 10;
        i = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        tNow = Time.time;
        if (tNow - t >= 20)
        {
            x += 20;
            GameObject select = GameObject.Find("g"+i);
            Destroy(select, 0);
            GameObject Refreshed=Transform.Instantiate(Ground, Ground.transform.position = new Vector3(x, -9.5f, 0), transform.rotation);
            i++;
            Refreshed.name = "g" + i;
            t = Time.time;
        }

    }
}
