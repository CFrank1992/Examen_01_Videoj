using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeKnightController : MonoBehaviour
{
    public float velocityX = 5;

    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

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
            rb.velocity = Vector2.right * velocityX;
            sr.flipX = false;
            changeAnimation(ANIMATION_WALK);
            //Correr
            if(Input.GetKey(KeyCode.X))
                {
                    rb.velocity = Vector2.right * (velocityX * 2);
                    changeAnimation(ANIMATION_RUN);
                }
        }

        //caminarIzquierda

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.right * -velocityX;
            sr.flipX = true;
            changeAnimation(ANIMATION_WALK);
            //Correr
            if(Input.GetKey(KeyCode.X))
                {
                    rb.velocity = Vector2.right * -(velocityX * 2);
                    changeAnimation(ANIMATION_RUN);
                }
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
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
