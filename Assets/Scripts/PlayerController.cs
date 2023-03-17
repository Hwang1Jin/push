using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckOthers(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckOthers(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckOthers(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckOthers(Vector3.back);
        }
    }

    public void CheckOthers(Vector3 dir)
    {
        if(Physics.Raycast(transform.position,transform.TransformDirection(dir),out hit , 1.0f))
        {
            Transform tr = hit.collider.transform;
            switch (hit.collider.tag)
            {
                case "Ball":
                    if(Physics.Raycast(tr.position,tr.TransformDirection(dir),out hit2, 1.0f))
                    {
                        switch (hit2.collider.tag)
                        {
                            case "Bucket":
                                break;
                            case "Wall":
                                break;
                            case "Ball":
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        transform.Translate(dir);
                        tr.transform.Translate(dir);
                        GameMgr.Instance.CheckBallPosition();
                    }
                    break;
                case "Wall":
                    break;
                default:
                    break;
            }
        }
        else
        {
            transform.Translate(dir);
        }
    }
}
