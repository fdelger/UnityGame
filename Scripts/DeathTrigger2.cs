using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger2 : MonoBehaviour {
    Vector3 spawnPoint;
    Animator animator;
    bool air;
    bool melee;
    public HealthBar health;
    GameObject ninja;
    GameObject robot;
    public Vector3 myVector;
    GameObject crate;
    GameObject SideTP, SideTP2;
   

    public void LoadScreen(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    void Start()
    {
        
        animator = GetComponent<Animator>();
        ninja = GameObject.FindGameObjectWithTag("Player2");
        robot = GameObject.FindGameObjectWithTag("Player");
        SideTP = GameObject.FindGameObjectWithTag("SideTP");
        SideTP2 = GameObject.FindGameObjectWithTag("SideTP2");
    }
    void Update()
    {
        melee = ninja.GetComponent<Animator>().GetBool("Melee");

    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "KillBox")
        {
            Debug.Log("hitting");
            LoadScreen("GameOver");
            transform.position = spawnPoint;
        }
        if (hit.gameObject.tag == "Ground")
        {
            animator.SetBool("Air", false);
            Debug.Log("Collision Script Grounded");
        }
        if (hit.gameObject.tag == "Kunai")
        {
            health.TakeDamage();
            if (health.HP == 0)
                LoadScreen("GameOver");
        }
        if (hit.gameObject.tag == "Player2" && melee)
        {
            health.TakeDamage();
            if (health.HP == 0)
                LoadScreen("GameOver");
        }
        if (hit.gameObject.tag == "Teleporter")
        {
            var x = Random.Range(-10, 10);
            var y = 10;
            myVector = new Vector3(x, y, 0);
            robot.transform.position = myVector;
            Debug.Log("Hit Teleporter");
        }
        if (hit.gameObject.tag == "Health")
        {
            health.Heal();
            Destroy(hit.gameObject);

        }
        if (hit.gameObject.tag == "SideTP")
        {
            myVector = SideTP2.transform.position;
            myVector.x = SideTP2.transform.position.x + 1;
            robot.transform.position = myVector;
        }
        if (hit.gameObject.tag == "SideTP2")
        {
            myVector = SideTP.transform.position;
            myVector.x = SideTP.transform.position.x - 1;
            robot.transform.position = myVector;
        }
        if (hit.gameObject.tag == "BFKunai")
        {
            health.TakeSpecial();
            if (health.HP <= 0)
                LoadScreen("GameOver");
        }
    }
}
