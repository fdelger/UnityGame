using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMovement : MonoBehaviour
{
    float move;
    float maxSpeed;
    private Rigidbody2D ninjarg;
    Animator animator;
    bool air;
    SpriteRenderer sprite;
    // Use this for initialization
    void Start()
    {
        ninjarg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        air = animator.GetBool("Air");
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Speed", 4.5f);
            maxSpeed = animator.GetFloat("Speed");
            move = Input.GetAxis("Horizontal");
            transform.position += new Vector3(move, 0, 0) * maxSpeed * Time.deltaTime;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Speed", 4.5f);
            maxSpeed = animator.GetFloat("Speed");
            move = Input.GetAxis("Horizontal");
            transform.position -= new Vector3(move, 0, 0) * maxSpeed * Time.deltaTime * -1;
            sprite.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.W) && !air)
        {
            ninjarg.AddForce(new Vector3(0, 300, 0));
            animator.SetBool("Air", true);
            air = true;
            Debug.Log("Ninja e");
        }
    }
}