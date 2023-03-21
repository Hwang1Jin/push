using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    public Transform player;
    public GameObject poo;
    public GameObject poo1;
    public Text scoreTxt;
    public Text lvUp;
    public Text gameOverTxt;
    public int score;
    public float movement;
    public RectTransform canvas;
    public RectTransform hpBar;
    public float hp;
    public float maxHp;
    public Image gameOverWindow;
    public Animator anim;
    bool isMove;
    bool canMove;
    public bool isDead;
    public float curTime;
    public float maxTime;
    void Start()
    {
        maxTime = 0.5f;
        anim = player.GetComponent<Animator>();
        maxHp = 5;
        hp = maxHp;
        DOTween.Init();
        movement = 0.7f;
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        StartCoroutine(Spawn(0.5f));
        
    }
    void Update()
    {
        if (hp <= 0)
        {
            gameOverWindow.gameObject.SetActive(true);
            gameOverTxt.text = $"SCORE : {score}";
            isDead = true;
            anim.SetBool("Open_Anim", false);
        }
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
    public void LvUp()
    {
        lvUp.gameObject.SetActive(false);

        lvUp.gameObject.GetComponent<Jun_TweenRuntime>().enabled = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayerMove(bool left)
    {
        
        if (isDead || !canMove)
            return;
        isMove = true;
        
        if (left)
        {
            if(player.transform.position.x > -45)
                player.DOMoveX(player.position.x - movement, 1f);
        }
        else
        {
            if (player.transform.position.x < 45)
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
            if (time > 0.2f)
                curTime += Time.deltaTime;
            if(curTime >= maxTime)
            {
                time -= 0.05f;
                curTime = 0;
                lvUp.gameObject.SetActive(true);
                lvUp.gameObject.GetComponent<Jun_TweenRuntime>().enabled = true;
            }
            float ranins = Random.RandomRange(0, 10);
            if(ranins == 1)
            {
                GameObject poos1 = Instantiate(poo1);
                poos1.transform.position = player.position + new Vector3(Random.RandomRange(-5f, 5f),7f, 0);
            }
            else
            {
                GameObject poos = Instantiate(poo);
                poos.transform.position = player.position + new Vector3(Random.RandomRange(-5f, 5f),7f, 0);
            }
            yield return new WaitForSeconds(time);
        }
    }
    
}
