using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKunai : MonoBehaviour
{
    public float delay;
    Collision2D collision;
    public GameObject BFKunai;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, delay);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }





}
