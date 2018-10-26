using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isAwake;

    public float shotReload;
    private float shotReloadStart;

    private Animator animator;

    private AudioSource audioSource;

    public GameObject bulletOrigin;

    private enum Direction {Up, Down, Left, Right};

    private Direction direction;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isAwake = false;
        direction = Direction.Up;
        shotReloadStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey && isAwake)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time - shotReloadStart > shotReload)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Fire();
                shotReloadStart = Time.time;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("MoveUp", true);
                animator.SetBool("MoveDown", false);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                direction = Direction.Up;
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                if (!audioSource.isPlaying)
                    audioSource.Play();
                audioSource.UnPause();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //仿照上面写出坦克向下移动的反应
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", true);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                direction = Direction.Down;
                GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
                if (!audioSource.isPlaying)
                    audioSource.Play();
                audioSource.UnPause();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //仿照上面写出坦克向左移动的反应
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", false);
                animator.SetBool("MoveLeft", true);
                animator.SetBool("MoveRight", false);
                direction = Direction.Left;
                GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
                if (!audioSource.isPlaying)
                    audioSource.Play();
                audioSource.UnPause();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //仿照上面写出坦克向右移动的反应
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", false);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", true);
                direction = Direction.Right;
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 3;
                if (!audioSource.isPlaying)
                    audioSource.Play();
                audioSource.UnPause();
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            audioSource.Pause();
        }
	}

    public void SetAwake()
    {
        isAwake = true;
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(bulletOrigin, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        switch (direction)
        {
            case Direction.Up:
                bullet.transform.Rotate(new Vector3(0, 0, 0));
                bullet.transform.Translate(new Vector3(0, 0.75f, 0));
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
                break;
            case Direction.Down:
                //仿照上面写出坦克向下发炮弹的反应
                bullet.transform.Rotate(new Vector3(0, 0, 180));
                bullet.transform.Translate(new Vector3(0, 0.75f, 0));
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
                break;
            case Direction.Left:
                //仿照上面写出坦克向左发炮弹的反应
                bullet.transform.Rotate(new Vector3(0, 0, 90));
                bullet.transform.Translate(new Vector3(0, 0.75f, 0));
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
                break;
            case Direction.Right:
                //仿照上面写出坦克向右发炮弹的反应
                bullet.transform.Rotate(new Vector3(0, 0, 270));
                bullet.transform.Translate(new Vector3(0, 0.75f, 0));
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 5;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
