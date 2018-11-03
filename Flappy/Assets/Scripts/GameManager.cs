using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Sprite[] ScorePic;
    public GameObject Score1,Score10,Score100,Score1000;
    public GameObject Mover;

    private static GameManager instance =  null;

    public GameManager getInstance()
            {
                return instance;
            }

    public enum State
    {
        Start,
        Ready,
        Playing,
        End,
        reReady
    }

    public static State state;

    public static int score;


    private void ScoreCount()
    {
        if(score==0)
        {
            Score10.GetComponent<SpriteRenderer>().sprite = null;
            Score100.GetComponent<SpriteRenderer>().sprite = null;
            Score1000.GetComponent<SpriteRenderer>().sprite = null;
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score1.transform.localPosition = new Vector3(0, 5.9f, 9.7f);
            Score10.transform.localPosition = new Vector3(0, 5.9f, 9.7f);
            Score100.transform.localPosition = new Vector3(0, 5.9f, 9.7f);
            Score1000.transform.localPosition = new Vector3(0, 5.9f, 9.7f);
        }
        if(score<=9)
        {              
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[score];
        }
        else if(score==10)
        {
            Score10.SetActive(true);
            Score1.transform.localPosition=new Vector3(0.45f, 5.9f, 9.7f);
            Score10.transform.localPosition=new Vector3(-0.45f, 5.9f, 9.7f);
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[1];
        }
        else if(score<=99)
        {
            int dit1, dit10;
            dit10 = score / 10;
            dit1 = score % 10;
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];

        }
        else if(score==100)
        {
            Score100.SetActive(true);
            Score1.transform.localPosition = new Vector3(0.9f, 5.9f, 9.7f);
            Score10.transform.localPosition = new Vector3(0, 5.9f, 9.7f);
            Score100.transform.localPosition = new Vector3(-0.9f, 5.9f, 9.7f);
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score100.GetComponent<SpriteRenderer>().sprite = ScorePic[1];

        }
        else if(score<=999)
        {
            int dit1, dit10, dit100;
            dit100 = score / 100;
            dit10 = score / 10 - (dit100 * 10);
            dit1 = score % 10;
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];
            Score100.GetComponent<SpriteRenderer>().sprite = ScorePic[dit100];
        }
        else if(score==1000)
        {
            Score1000.SetActive(true);
            Score1.transform.localPosition = new Vector3(1.35f, 5.9f, 9.7f);
            Score10.transform.localPosition = new Vector3(0.45f, 5.9f, 9.7f);
            Score100.transform.localPosition = new Vector3(-0.45f, 5.9f, 9.7f);
            Score1000.transform.localPosition = new Vector3(-1.35f, 5.9f, 9.7f);
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score100.GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score1000.GetComponent<SpriteRenderer>().sprite = ScorePic[1];
        }
        else
        {
            int dit1, dit10, dit100, dit1000;
            dit1000 = score / 1000;
            dit100 = score / 100 - (dit1000 * 10);
            dit1 = score % 10;
            dit10 = (score % 10 - dit1)/10;
            Score1.GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score10.GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];
            Score100.GetComponent<SpriteRenderer>().sprite = ScorePic[dit100];
            Score1000.GetComponent<SpriteRenderer>().sprite = ScorePic[dit1000];
        }
        
        

    }

    void Move()
    {
        Mover.transform.Translate(new Vector2(1.0f*Time.deltaTime, 0.0f));//使摄像机移动
    }

    //TODO:End的计分板数字顺序变大功能--》已挪到EndScreen

    private bool restarted1,restarted2;
    void Restart(bool instance)
    {
        if (instance == true)
        {
            Destroy(GameObject.Find("Pipes"));
            new GameObject("Pipes");
            instance = false;
        }
    }

    void RestartScript(bool instance)
    {
        if (instance == true)
        {

            GameObject.Find("PipeCreator").GetComponent<CreatePipes>().enabled = true;
            GameObject.Find("GroundLong").GetComponent<RefreshGround>().enabled = true;
            instance = false;
        }
    }


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);//加载时先判断这是否是唯一的Gamemanager,如不是则摧毁较新的GameManager
        state = State.Start;
    }

    // Use this for initialization
    void Start () {
        score = 0;
        restarted1 = false;
        restarted2 = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        switch(state)
        {
            
            case State.Start:Move(); break;
            case State.Ready:Move(); break;
            case State.Playing:RestartScript(restarted2); ScoreCount();Move(); break;
            case State.End: restarted1 = true;restarted2 = true; break;
            case State.reReady:Restart(restarted1); ScoreCount(); Move();break;
        }
        
	}

    
}
