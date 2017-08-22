using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
    public GameObject Heart;
    public GameObject Special;
    public float SpawnTime = 20f;
    public float SpecialTime = 40f;
    public Vector3 myVector;
	// Use this for initialization
	void Start () {
        
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        InvokeRepeating("SpecialAttack", SpecialTime, SpecialTime);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void Spawn()
    {
        var x = Random.Range(-10, 10);
        var y = Random.Range(10, 10);
        myVector = new Vector3(x, y, 0);
        Instantiate(Heart, myVector, Quaternion.identity);

    }
    void SpecialAttack()
    {
        var x = Random.Range(-10, 10);
        var y = Random.Range(10, 10);
        myVector = new Vector3(x, y, 0);
        Instantiate(Special, myVector, Quaternion.identity);
    }
}
