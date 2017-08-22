using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaKeyPress : MonoBehaviour {
    Animator animator;
    Collision2D hit;
    bool air;
    bool fire;

    public float fireRate = 0.5f;
    private float nextFire = 2.0f;
    float speed;
    public GameObject KunaiLeft, KunaiRight, KunaiDiagonalLeft, KunaiDiagonalRight;
    Transform FireStraight, FireJump, FireStraightLeft, FireJumpLeft;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        FireStraight = transform.FindChild("FireStraight");
        FireJump = transform.FindChild("FireJump");
        FireStraightLeft = transform.FindChild("FireStraightLeft");
        FireJumpLeft = transform.FindChild("FireJumpLeft");
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        fire = animator.GetBool("Fire");
        speed = animator.GetFloat("Speed");
        air = animator.GetBool("Air");

        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire)
        {
            animator.SetBool("Fire", true);
            if (speed > 0.1 && !air)
            {
                nextFire = Time.time + fireRate;
                RunFire();
            }
            else if (speed > 0.1 && air)
            {
                nextFire = Time.time + fireRate;
                JumpFire();
            }
            else
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
            Debug.Log("animation trigger gun");
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("Fire", false);
            Debug.Log("animation trigger gun");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("Melee", true);
            Debug.Log("animation trigger melee");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            animator.SetBool("Melee", false);
            Debug.Log("animation trigger melee");
        }

    }
    void Fire()
    {
        if (sprite.flipX)
        {

            Instantiate(KunaiLeft, FireStraightLeft.position, KunaiLeft.transform.rotation);
            Debug.Log("FireLeftStraight");
        }
        else
        {
            Instantiate(KunaiRight, FireStraight.position, KunaiRight.transform.rotation);
            Debug.Log("FireRightStraight");
        }
    }
    void RunFire()
    {
        if (sprite.flipX)
        {
            Instantiate(KunaiLeft, FireStraightLeft.position, KunaiLeft.transform.rotation);
            Debug.Log("FireLeftRun");
        }
        else
        {
            Instantiate(KunaiRight, FireStraight.position, KunaiRight.transform.rotation);
            Debug.Log("FireRightStraightRun");
        }
    }
    void JumpFire()
    {
        if (sprite.flipX)
        {
            Instantiate(KunaiDiagonalLeft, FireJumpLeft.position, KunaiDiagonalLeft.transform.rotation);
            Debug.Log("FireLeftDiagonal");
        }
        else
        {
            Instantiate(KunaiDiagonalRight, FireJump.position, KunaiDiagonalRight.transform.rotation);
            Debug.Log("FireRightDiagonal");
        }
    }
}
