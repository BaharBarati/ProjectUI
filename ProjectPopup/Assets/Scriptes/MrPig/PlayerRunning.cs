// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// public class PlayerRunning : MonoBehaviour
// {
//     private Rigidbody2D rb2D;
//     private Animator animator;
//     //[SerializeField] private float jumpForce;
//     [SerializeField]private float movespeed = 1f;
//     // private bool isJumping;
//     private float moveHorizontal;
//     //private float moveVertical;
//     private bool facingRight = true;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         rb2D = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//         
//         // jumpForce = 60f;
//         // isJumping = false;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//         moveHorizontal = Input.GetAxisRaw("Horizontal");
//         // moveVertical = Input.GetAxisRaw("Vertical");
//         animator.SetFloat("RunPlayer" , Mathf.Abs(moveHorizontal));//never - number
//         if (moveHorizontal > 0 && !facingRight)
//         {
//             Flip();
//         }
//         else if (moveHorizontal < 0 && facingRight)
//         {
//             Flip();
//         }
//     }
//
//     void FixedUpdate()
//     {
//         
//         if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
//         {
//             rb2D.AddForce(new Vector2(moveHorizontal * movespeed,0f),  ForceMode2D.Impulse);
//         }
//
//         // if (isJumping && moveVertical > 0.1f)
//         // {
//         //     rb2D.AddForce(new Vector2(0f, moveVertical*jumpForce));
//         // }
//     }
//     // private void OnTre
//     void Flip()
//     {
//         facingRight = !facingRight;
//         Vector2 currentScale = transform.localScale;
//         currentScale.x *= -1;
//         transform.localScale = currentScale;
//     }
// }
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 5f;
    private float moveHorizontal;
    private bool facingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (animator) animator.applyRootMotion = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Animator
        if (animator)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
            animator.SetFloat("YVelocity", rb2D.linearVelocity.y);
        }

        // Flip
        if (moveHorizontal > 0 && !facingRight) Flip();
        else if (moveHorizontal < 0 && facingRight) Flip();

        // Jump (بدون بررسی زمین)
        if (Input.GetButtonDown("Jump"))
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
            if (animator) animator.SetTrigger("JumpPlay");
        }
    }

    void FixedUpdate()
    {
        // حرکت افقی
        rb2D.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb2D.linearVelocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}


