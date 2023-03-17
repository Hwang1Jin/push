using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapObjectPrefab;
    public string dataPath;
    public List<Dictionary<string, object>> data;

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                GameObject ground = Instantiate(mapObjectPrefab[0]) as GameObject;
                ground.name = ground.tag + "(" + j + "," + i + ")";
                ground.transform.parent = GameObject.Find("Ground12x12").transform;
                ground.transform.localPosition = new Vector3(j,0,-i);

            }
        }

        LoadMapData(1);
        MakeMap();
    }

    public void LoadMapData(int stageNum)
    {
        dataPath = $"MapData/Lv{stageNum}";
        data = CSVReader.Read(dataPath);
    }

    public void MakeMap()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                int dataSet = (int)data[i][j.ToString()];

                if(dataSet != 0)
                {
                    GameObject mapObj = Instantiate(mapObjectPrefab[dataSet]);

                    switch (mapObj.tag)
                    {
                        case "Wall":
                            mapObj.name = $"{mapObj.tag}({j},{i})";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;
                        case "Bucket":
                            mapObj.name = $"{mapObj.tag}({j},{i})";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;
                        case "Ball":
                            mapObj.name = $"{mapObj.tag}({j},{i})";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;
                        case "Player":
                            mapObj.name = $"{mapObj.tag}({j},{i})";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        GameMgr.Instance.SetBucketsAndBalls();
    }

    public void MapDestroy()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("Bucket");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        List<GameObject[]> objects = new List<GameObject[]> { walls, balls, buckets };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < objects[i].Length; j++)
            {
                Destroy(objects[i][j]);
            }
        }
        Destroy(player);
    }
}
