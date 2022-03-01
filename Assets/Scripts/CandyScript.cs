using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.Increment();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Boundary")
        {
            GameManager.instance.DecreaseLives();
            Destroy(gameObject);
        }
    }
}
