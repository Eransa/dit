using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour {
    public GameObject sound;
    private string c;

    //public GameObject Score;


    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        
        
            }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string c=collision.gameObject.name;
        if(c=="Bird")
        {
            GameManager.score++;
            sound.GetComponent<AudioSource>().Play(0);
        }

    }
}
