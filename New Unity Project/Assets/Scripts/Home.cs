using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

    private Animator animator;

    public AudioClip loseAudio;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            animator.SetTrigger("Destroyed");
            AudioManager.instance.PlayClip(loseAudio);
        }
    }
}
