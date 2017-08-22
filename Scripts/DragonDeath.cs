using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Debug.Log("hitting");
            Destroy(hit.gameObject);
        }
    }
}
