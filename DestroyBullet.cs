using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {
    public float delay;
    Collision2D collision;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, delay);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }
    }





}
