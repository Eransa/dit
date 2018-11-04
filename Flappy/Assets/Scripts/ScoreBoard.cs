using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {
    public GameObject Scoreboard;
    public Sprite[] ScorePic;
    public GameObject[] NewScore;
    public GameObject[] BestScore;
    public GameObject Medal;
    public Sprite[] medals;
    public GameObject New;
    private static int loaded;
    private int i;
    private float t;
    private bool hasInited;

    private void ScoreCount(GameObject[] Score, int input)
    {
        if (input == 0)
        {
            Score[1].GetComponent<SpriteRenderer>().sprite = null;
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
        }
        if (input <= 9)
        {
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[input];
        }
        else if (input == 10)
        {
            Score[1].SetActive(true);
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[1];
        }
        else if (input <= 99)
        {
            int dit1, dit10;
            dit10 = input / 10;
            dit1 = input % 10;
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];

        }
        else if (input == 100)
        {
            Score[2].SetActive(true);
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[2].GetComponent<SpriteRenderer>().sprite = ScorePic[1];

        }
        else if (input <= 999)
        {
            int dit1, dit10, dit100;
            dit100 = input / 100;
            dit10 = input / 10 - (dit100 * 10);
            dit1 = input % 10;
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];
            Score[2].GetComponent<SpriteRenderer>().sprite = ScorePic[dit100];
        }
        else if (input == 1000)
        {
            Score[3].SetActive(true);
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[2].GetComponent<SpriteRenderer>().sprite = ScorePic[0];
            Score[3].GetComponent<SpriteRenderer>().sprite = ScorePic[1];
        }
        else
        {
            int dit1, dit10, dit100, dit1000;
            dit1000 = input / 1000;
            dit100 = input / 100 - (dit1000 * 10);
            dit1 = input % 10;
            dit10 = (input % 10 - dit1) / 10;
            Score[0].GetComponent<SpriteRenderer>().sprite = ScorePic[dit1];
            Score[1].GetComponent<SpriteRenderer>().sprite = ScorePic[dit10];
            Score[2].GetComponent<SpriteRenderer>().sprite = ScorePic[dit100];
            Score[3].GetComponent<SpriteRenderer>().sprite = ScorePic[dit1000];
        }

    }

    public int ScoreUp(GameObject[] Score,int score,int i)
    {
        if (i <= score)
        {
            ScoreCount(Score, i);
            i++;
        }
        return i;
    }

    public int Read()
    {
        int num;
        bool exist;
        exist = System.IO.File.Exists(@"C:\\Users\\Erans\\dit\\Flappy\\BestScore.txt");
        if (!exist)
        {
            num = 0;
        }
        else
        {
            num = System.BitConverter.ToInt32(System.IO.File.ReadAllBytes(@"C:\\Users\\Erans\\dit\\Flappy\\BestScore.txt"),0);
        }
        return num;
    }

    public void Write(int num)
    {
        Debug.Log("success");
        byte[] bestscore = System.BitConverter.GetBytes(num);
        bool exist;
        exist = System.IO.File.Exists(@"C:\Users\Erans\dit\Flappy\BestScore.txt");
        if (!exist)
        {
            System.IO.File.Create(@"C:\Users\Erans\dit\Flappy\BestScore.txt");
        }

        System.IO.File.WriteAllBytes(@"C:\Users\Erans\dit\Flappy\BestScore.txt", bestscore);

    }


        // Use this for initialization
    void Start () {
        loaded = Read();
        i= 0;
        t = Time.time;
        hasInited = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.state == GameManager.State.End && hasInited==false)
        {
            t = Time.time;
            i = 0;
            hasInited = true;
        }
        if (Time.time - t >= 1)
        {
            ScoreCount(BestScore, loaded);
            if (i <= GameManager.score)
                i = ScoreUp(NewScore, GameManager.score, i);
            if (GameManager.score > loaded)
            {
                New.SetActive(true);
                loaded=ScoreUp(BestScore, GameManager.score, loaded);
                Write(loaded);
            }
            switch (GameManager.score / 10)
            {
                case 0: break;
                case 1: Medal.SetActive(true); Medal.GetComponent<SpriteRenderer>().sprite = medals[0]; break;
                case 2: Medal.SetActive(true); Medal.GetComponent<SpriteRenderer>().sprite = medals[1]; break;
                case 3: Medal.SetActive(true); Medal.GetComponent<SpriteRenderer>().sprite = medals[2]; break;
                case 4: Medal.SetActive(true); Medal.GetComponent<SpriteRenderer>().sprite = medals[3]; break;
            }

            if (GameManager.state == GameManager.State.reReady)
            {
                Medal.SetActive(false);
                New.SetActive(false);
                ScoreCount(NewScore, 0);
                hasInited = false;
                Scoreboard.SetActive(false);
            }
        }
	}
}
