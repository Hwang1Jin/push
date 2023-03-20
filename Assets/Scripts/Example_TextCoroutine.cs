using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_TextCoroutine : MonoBehaviour
{
    public Text targetTxt;
    public string txt;
    public string result;

    void Start()
    {
        DOTween.Init();
        StartCoroutine(NextString());
        
    }
    
    IEnumerator NextString()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            yield return new WaitForSeconds(0.25f);
            result += txt[i];
            targetTxt.text = result;
        }
    }
}
