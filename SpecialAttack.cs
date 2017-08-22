using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {
    public GameObject BFBullet;
    GameObject Special1, Special2;

	// Use this for initialization
	void Start () {
        Special1 = GameObject.FindGameObjectWithTag("Port1");

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Special")
        {
            Instantiate(BFBullet, Special1.transform.position, BFBullet.transform.rotation);
            Destroy(collision.gameObject);
            Debug.Log("Hey, we special");
        }
    }
}
