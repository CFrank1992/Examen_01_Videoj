using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeKnightController : MonoBehaviour
{
    //public properties
    public float velocityX = 12;
    public float jumpForce = 40;

    // Start is called before the first frame update
    //private components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //private porperties
    private bool isJumping = false;

    //Constants

    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_WALK = 1;
    private const int ANIMATION_RUN = 2;
    private const int ANIMATION_JUMP = 3;
    private const int ANIMATION_ATTACK = 4;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Quieto
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_IDLE);
        
        //caminarDerecha

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_WALK);
            //Correr
            if(Input.GetKey(KeyCode.X))
                {
                    rb.velocity = new Vector2(velocityX, rb.velocity.y);
                    changeAnimation(ANIMATION_RUN);
                }
        }

        //caminarIzquierda

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_WALK);
            //Correr
            if(Input.GetKey(KeyCode.X))
                {
                    rb.velocity = new Vector2(-velocityX, rb.velocity.y);
                    changeAnimation(ANIMATION_RUN);
                }
        }
        //Atacar
        if(Input.GetKey(KeyCode.Z))
        {
            changeAnimation(ANIMATION_ATTACK);
        }

        /*//correrDerecha
        if(Input.GetKey(KeyCode.X) && ANIMATION_WALK)
        {
            rb.velocity = Vector2.right * (velocityX * 2);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }

        //correrIzquierda
        if(Input.GetKey(KeyCode.X) && ANIMATION_WALK)
        {
            rb.velocity = Vector2.right * -(velocityX * 2);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }*/
        //Saltar
        if(Input.GetKeyUp(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
            isJumping = true;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Piso")
        {
            isJumping = false;
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
