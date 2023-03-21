using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Poo : MonoBehaviour
{
    Controller Controller;
    public float speed;
    public GameObject effect;
    public GameObject groundEffect;
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
        if (!collision.gameObject.GetComponent<Poo>() || !collision.gameObject.GetComponent<Heart>())
        {
            Instantiate(groundEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (Controller.isDead)
                return;
            Controller.score++;
            Controller.scoreTxt.text = $"SCORE : {Controller.score}";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Poo>() || !other.gameObject.GetComponent<Heart>())
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (Controller.isDead)
                return;
            Camera.main.transform.DOShakePosition(0.5f, 1, 10, 30, false).OnComplete<Tween>(CameraOrigin);
            Controller.hp--;
        }
    }
    private void CameraOrigin()
    {
        Camera.main.transform.localPosition = new Vector3(0, 0.3f, -2f);
    }
}
