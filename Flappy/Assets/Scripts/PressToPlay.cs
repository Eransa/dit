using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToPlay : MonoBehaviour {
    public GameObject ReadyScreen;
    public GameObject[] ReadyObjects;
    public GameObject PipeCreator;
    public AudioSource wing;
    private float isFading;
    private float t;

    // Use this for initialization
    void Start () {

        isFading = 2;
        t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.state == GameManager.State.reReady && isFading == -2)
        {
            for (int i = 0; i < ReadyObjects.Length; i++)
                ReadyObjects[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            isFading = 2;
            t = Time.time;
        }
        if (Input.GetMouseButtonDown(0))
        {
            wing.Play(0);
            isFading = 1;
        }
        if(isFading<=1)
        {
            if (Time.time - t > 0.03)
            {
                isFading -= 0.1f;
                for(int i=0;i<ReadyObjects.Length;i++)
                    ReadyObjects[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, isFading);
                if (isFading <= 0)
                {
                    GameManager.state = GameManager.State.Playing;
                    PipeCreator.SetActive(true);
                    isFading = -2;
                    ReadyScreen.SetActive(false);
                    
                    
                }
                t = Time.time;
            }
        }
    }


}
