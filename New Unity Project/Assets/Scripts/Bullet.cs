using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Animator animator;

    private AudioSource audioSource;
    public AudioClip explosionAudio;
    public AudioClip explosionAtWallAudio;
    public AudioClip fireAudio;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(fireAudio);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Brick" || collision.gameObject.tag == "Home")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetTrigger("Explosion");
            audioSource.PlayOneShot(explosionAudio);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            //仿照上面写出当碰撞到Wall时候的反应
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetTrigger("Explosion");
            audioSource.PlayOneShot(explosionAtWallAudio);
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
