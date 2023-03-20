using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    public Transform player;
    public GameObject poo;
    public Text scoreTxt;
    public int score;
    public float movement;
    public RectTransform canvas;
    public RectTransform hpBar;
    public float hp;
    public float maxHp;
    public Image gameOver;
    public Animator anim;
    bool isMove;
    bool canMove;
    void Start()
    {
        anim = player.GetComponent<Animator>();
        maxHp = 5;
        hp = maxHp;
        DOTween.Init();
        movement = 1f;
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        StartCoroutine(Spawn(0.5f));
        
    }
    void Update()
    {
        
        Vector3 curPos = player.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, Camera.main, out canvasPos);
        hpBar.localPosition = canvasPos + new Vector2(0,100);
        hpBar.transform.GetComponent<Slider>().value = hp / maxHp;

        if (Input.GetKey(KeyCode.LeftArrow))
            PlayerMove(true);
        else if(Input.GetKey(KeyCode.RightArrow))
            PlayerMove(false);
        anim.SetBool("Walk_Anim", isMove);
        isMove = false;
    }
    public void PlayerMove(bool left)
    {
        if (hp <= 0)
        {
            canMove = false;
            anim.SetBool("Open_Anim", false);
        }
        if (!canMove)
            return;
        isMove = true;
        
        if (left)
        {
            player.DOMoveX(player.position.x - movement, 1f);
        }
        else
        {
            player.DOMoveX(player.position.x + movement, 1f);
        }
    }

    IEnumerator Spawn(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(3.5f);
        canMove = true;
        anim.SetBool("Roll_Anim", true);
        while (hp > 0)
        {
            GameObject poos = Instantiate(poo);
            poos.transform.position = player.position + new Vector3(Random.RandomRange(-2.5f, 2.5f),7f, 0);
            yield return new WaitForSeconds(time);
        }
    }
    
}
