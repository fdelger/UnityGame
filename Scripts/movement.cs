using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    float move;
    float maxSpeed;
    private Rigidbody2D rg;
    Animator animator;
    bool air;
    SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

 
    // Update is called once per frame
    void Update () {
        air = animator.GetBool("Air");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", 3.5f);
            maxSpeed = animator.GetFloat("Speed");
            move = Input.GetAxis("Horizontal");
            transform.position += new Vector3(move, 0, 0) * maxSpeed * Time.deltaTime;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 3.5f);
            maxSpeed = animator.GetFloat("Speed");
            move = Input.GetAxis("Horizontal");
           transform.position -= new Vector3(move, 0, 0) * maxSpeed * Time.deltaTime * -1;
            sprite.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !air)
        {
            rg.AddForce(new Vector3(0, 300, 0));
            air = true;
        }

    }
}
