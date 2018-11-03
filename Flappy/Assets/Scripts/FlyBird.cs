using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour {
    public GameObject BackGround;
    public Rigidbody2D Bird;
    public GameObject End;
    public GameObject AgainButton;
    public GameObject WhiteFlash;
    public AudioClip Wing;
    public AudioSource wing;
    public AudioSource hit;
    private bool hasInited,restarted;
    private float t,i;

    private float Crush(GameObject Flash,float i)
    {
        if (i <= 0.5f && i>=-0.5f)
        {
            if (i > 0)//屏幕变白阶段
            {
                i -= 0.25f;
                Flash.GetComponent<SpriteRenderer>().color = new Color(255,255,255, 0.5f-i );//白屏透明度逐渐变低
            }
            else
            {
                i -= 0.25f;
                Flash.GetComponent<SpriteRenderer>().color = new Color(255,255,255, 0.5f+i );//白幕逐渐变亮变透明直至消失
                if(i<=-0.5f)
                {
                    End.SetActive(true);
                    //AgainButton.SetActive(true);
                }
            }

            
        }
        return i;
    }

    // Use this for initialization
    void Start() {

        restarted = false;
        hasInited = false;
        Bird.velocity = new Vector2(1.5f, 7.0f);
        t = Time.time;
        i = 2;
        
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.state == GameManager.State.Playing && hasInited == false && restarted==true)
        {
            
            Bird.velocity = new Vector2(1.5f, 7.0f);
            t = Time.time;
            restarted = false;
            i = 2;
        }
        if (GameManager.state != GameManager.State.End)
            Bird.rotation = Bird.velocity.y * 10;
        else
            Bird.rotation = -90;
        if (Time.time-t>1.5f && hasInited==false && restarted==false)
        {
            Bird.velocity = new Vector2(0.0f, Bird.velocity.y);
            hasInited = true;
        }
        if (Input.GetMouseButtonDown(0) && GameManager.state != GameManager.State.End)
        {
            
            Bird.AddForce(new Vector2(0.0f, 10.0f),ForceMode2D.Impulse);
            wing.PlayOneShot(Wing);
        }
        if (GameManager.state == GameManager.State.End)
        {
            i=Crush(WhiteFlash, i);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit.Play(0);
        GameManager.state = GameManager.State.End;
        restarted = true;
        hasInited = false;
        i = 0.5f;
        End.SetActive(true);
        //AgainButton.SetActive(true);
        


    }

}
