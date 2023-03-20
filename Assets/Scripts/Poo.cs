using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Poo : MonoBehaviour
{
    Controller Controller;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.RandomRange(0, 1f);
        GetComponent<Rigidbody>().drag = speed;
        Controller = GameObject.FindObjectOfType<Controller>();
        DOTween.Init();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Controller.score++;
        Controller.scoreTxt.text = $"SCORE : {Controller.score}";
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Camera.main.transform.DOShakePosition(0.5f, 1, 10, 90, true);
        Controller.hp--;
        Destroy(gameObject);
    }
}
