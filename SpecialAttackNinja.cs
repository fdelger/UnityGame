using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackNinja : MonoBehaviour
{
    public GameObject BFKunai;
    GameObject Special2;

    // Use this for initialization
    void Start()
    {
        Special2 = GameObject.FindGameObjectWithTag("Port2");

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Special")
        {
            Instantiate(BFKunai, Special2.transform.position, BFKunai.transform.rotation);
            Destroy(collision.gameObject);
            Debug.Log("Hey, we special");
        }
    }
}
