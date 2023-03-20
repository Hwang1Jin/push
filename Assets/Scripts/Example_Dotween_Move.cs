using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_Dotween_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    public void MoveRight()
    {
        transform.DOMoveX(8f, 2f);
    }

    public void MoveLeft()
    {
        transform.DOMoveX(-8f, 2f);
    }

    public void RotateBox()
    {
        transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.Fast);
    }
}
