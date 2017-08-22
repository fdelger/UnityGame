using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaTrigger : MonoBehaviour {
    Vector3 spawnPoint;
    Animator animator;
    bool air;
    public HealthBar healthbar;
    bool melee;
    GameObject robot;
    GameObject ninja;
    public Vector3 myVector;
    GameObject crate;
    GameObject SideTP, SideTP2;

    public void LoadScreen(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    void Start()
    {
        GameObject spawnObject = GameObject.FindGameObjectWithTag("Spawn");
        spawnPoint = spawnObject.transform.position;
        animator = GetComponent<Animator>();
        robot = GameObject.FindGameObjectWithTag("Player");
        ninja = GameObject.FindGameObjectWithTag("Player2");
        crate = GameObject.FindGameObjectWithTag("Health");
        SideTP = GameObject.FindGameObjectWithTag("SideTP");
        SideTP2 = GameObject.FindGameObjectWithTag("SideTP2");
    }

    void Update()
    {
        melee = robot.GetComponent<Animator>().GetBool("Melee");
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Teleporter")
        {
            var x = Random.Range(-10, 10);
            var y = 10;
            myVector = new Vector3(x, y, 0);
            ninja.transform.position = myVector;
            Debug.Log("Hit Teleporter");
        }
        if (hit.gameObject.tag == "Ground")
        {
            animator.SetBool("Air", false);
            Debug.Log("Collision Script Grounded Ninja");
        }
        if (hit.gameObject.tag == "Rocket")
        {
            healthbar.TakeDamage();
            if (healthbar.HP == 0)
                LoadScreen("GameOver2");
        }
        if (hit.gameObject.tag == "Player" && melee)
        {
            healthbar.TakeDamage();
            if (healthbar.HP == 0)
                LoadScreen("GameOver2");
        }
        if (hit.gameObject.tag == "Health")
        {
            healthbar.Heal();
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "SideTP")
        {
            myVector = SideTP2.transform.position;
            myVector.x = SideTP2.transform.position.x + 1;
            ninja.transform.position = myVector;
        }
        if (hit.gameObject.tag == "SideTP2")
        {
            myVector = SideTP.transform.position;
            myVector.x = SideTP.transform.position.x - 1;
            ninja.transform.position = myVector;
        }
        if (hit.gameObject.tag == "BFRocket")
        {
            healthbar.TakeSpecial();
            if (healthbar.HP <= 0)
                LoadScreen("GameOver2");
        }
        
    }
}
