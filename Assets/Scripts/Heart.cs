using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Controller Controller;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindObjectOfType<Controller>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Poo>() || !other.gameObject.GetComponent<Heart>())
        {
            if (Controller.hp < Controller.maxHp)
            {
                Controller.hp++;
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<Poo>() || !collision.gameObject.GetComponent<Heart>())
        {
            Destroy(gameObject);
        }
    }
}
