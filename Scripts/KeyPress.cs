using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPress : MonoBehaviour {
    Animator animator;
    Collision2D hit;
    bool air;
    bool fire;

    public float fireRate = 0.5f;
    private float nextFire = 2.0f;
    float speed;
    public GameObject LeftBullet, RightBullet, DiagonalLeft, DiagonalRight;
    Transform FireStraight, FireDiagonal, FireJump, FireStraightLeft, FireDiagonalLeft, FireJumpLeft;
    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        FireDiagonal = transform.FindChild("FireDiagonal");
        FireStraight = transform.FindChild("FireStraight");
        FireJump = transform.FindChild("FireJump");
        FireDiagonalLeft = transform.FindChild("FireDiagonalLeft");
        FireStraightLeft = transform.FindChild("FireStraightLeft");
        FireJumpLeft = transform.FindChild("FireJumpLeft");
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update() {
        air = animator.GetBool("Air");
        fire = animator.GetBool("Fire");
        speed = animator.GetFloat("Speed");
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetBool("Air", true);
                Debug.Log("animation trigger air");
            }
            if (Input.GetKeyDown(KeyCode.M) && Time.time > nextFire)
            {
                animator.SetBool("Fire", true);
                 if(speed > 0.1 && !air)
                 {
                    nextFire = Time.time + fireRate;
                    RunFire();
                 }   
                 else if (speed > 0.1 && air)
                 {
                    nextFire = Time.time + fireRate;
                    JumpFire();
                 } else  {
                    nextFire = Time.time + fireRate;
                    Fire();
                }
                
                Debug.Log("animation trigger gun");
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                animator.SetBool("Fire", false);
                Debug.Log("animation trigger gun");
            }
             if (Input.GetKeyDown(KeyCode.N))
            {
                animator.SetBool("Melee", true);
                Debug.Log("animation trigger melee");
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                animator.SetBool("Melee", false);
                Debug.Log("animation trigger melee");
            }

    }
    void Fire()
    {
        if (sprite.flipX)
        {
            
            Instantiate(DiagonalLeft, FireDiagonalLeft.position, DiagonalLeft.transform.rotation);
            Debug.Log("FireLeft");
        }
        else
        {
            Instantiate(DiagonalRight, FireDiagonal.position, DiagonalRight.transform.rotation);
            Debug.Log("FireRight");
        }
    }
   void RunFire()
   {
        if (sprite.flipX)
        {
            Instantiate(LeftBullet, FireStraightLeft.position, Quaternion.identity);
            Debug.Log("FireLeft");
        }
        else
        {
            Instantiate(RightBullet, FireStraight.position, Quaternion.identity);
            Debug.Log("FireRight");
        }
    }
    void JumpFire()
    {
        if (sprite.flipX)
        {
            Instantiate(LeftBullet, FireJumpLeft.position, Quaternion.identity);
            Debug.Log("FireLeft");
        }
        else
        {
            Instantiate(RightBullet, FireJump.position, Quaternion.identity);
            Debug.Log("FireRight");
        }
    }

    }

