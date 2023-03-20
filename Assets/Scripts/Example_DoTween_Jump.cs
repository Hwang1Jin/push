using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Example_DoTween_Jump : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        DOTween.Init();
    }

    public void Jump()
    {
        btn.interactable = false;
        transform.DOLocalJump(transform.position, 3.5f, 2, 1, true).OnComplete<Tween>(Grounded);
    }

    public void Grounded()
    {
        transform.position = Vector3.zero;
        btn.interactable = true;
    }
}
