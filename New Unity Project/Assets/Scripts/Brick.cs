using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject);
        }
    }
}
