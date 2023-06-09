using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
ToDo
그래픽
UI,UX
Sound
Scene구성
 */
public class GameMgr : MonoBehaviour
{
    public GameObject[] buckets;
    public GameObject[] balls;
    public int curCnt = 0;
    public int maxCnt = 0;
    public int correctCnt;
    public int inCoreect;
    public int curLv = 1;
    public int maxLv = 10;
    public MapGenerator mapGenerator;
    public Text scoreText;
    public Text stageNumText;
    

    public static GameMgr Instance { get; private set; }
    private void Awake()
    {
        /*if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

    public void SetBucketsAndBalls()
    {
        StartCoroutine(FindBucketsAndBalls());
    }

    IEnumerator FindBucketsAndBalls()
    {
        yield return buckets = new GameObject[GameObject.FindGameObjectsWithTag("Bucket").Length];
        yield return balls = new GameObject[GameObject.FindGameObjectsWithTag("Ball").Length];

        buckets = GameObject.FindGameObjectsWithTag("Bucket");
        balls = GameObject.FindGameObjectsWithTag("Ball");

        curCnt = 0;
        maxCnt = balls.Length;

        //scoreText.text = $"{curCnt}/{maxCnt}";
        //stageNumText.text = $"STAGE:{curLv.ToString()}";
        Debug.Log(maxCnt);
    }

    public void CheckBallPosition()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            for (int j = 0; j < balls.Length; j++)
            {
                if(buckets[i].transform.position == balls[j].transform.position)
                {
                    correctCnt++;
                    curCnt = correctCnt;
                }
            }
        }

        correctCnt = 0;
        //scoreText.text = $"{curCnt}/{maxCnt}";

        if(curCnt == maxCnt)
        {
            Debug.Log("Stage Clear");
            curLv++;
            curCnt = 0;
            maxCnt = 0;
            if (curLv != maxLv)
            {
                mapGenerator.LoadMapData(curLv);
                mapGenerator.MapDestroy();
                mapGenerator.MakeMap();
            }
            else
                Debug.Log("All Stage Clear");
        }
    }

    public void Restart()
    {
        curCnt = 0;
        maxCnt = 0;
        mapGenerator.LoadMapData(curLv);
        mapGenerator.MapDestroy();
        mapGenerator.MakeMap();
    }

    public void Next()
    {
        if (curLv != maxLv)
        {
            curCnt = 0;
            maxCnt = 0;
            curLv++;
            mapGenerator.LoadMapData(curLv);
            mapGenerator.MapDestroy();
            mapGenerator.MakeMap();
        }
       
    }
    public void Previous()
    {
        if(curLv != 1)
        {
            curCnt = 0;
            maxCnt = 0;
            curLv--;
            mapGenerator.LoadMapData(curLv);
            mapGenerator.MapDestroy();
            mapGenerator.MakeMap();
        }
        
    }
}
