using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float jumpForce = 2.5f;
    public static float speed = 5.0f;
    public int jumpCount = 0;
    readonly float xLimitLeft = -9.6f;
    readonly float xLimitRight = 9.6f;
    private Animator animator;
    bool facingRight = true;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
        rb = GetComponent<Rigidbody2D>();
    }
    public static void DoubleSpeed()
    {
        speed *= 2;
    }
    public static void ResetSpeed()
    {
        speed = 2.5f;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            MoveHorizontally(moveHorizontal);

        }
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount >= 2)
            {
                return;
            }
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }
    void MoveHorizontally(float moveHorizontal)
    {
        float newPositionX = transform.position.x + moveHorizontal * speed * Time.deltaTime;
        if (newPositionX <= xLimitLeft)
        {
            transform.position = new Vector3(xLimitLeft, transform.position.y, transform.position.z);
        }
        else if (newPositionX >= xLimitRight)
        {
            transform.position = new Vector3(xLimitRight, transform.position.y, transform.position.z);
        }
        //else if(newPositionX >= -4.5 && newPositionX <= 8.5 && transform.position.y>=-3.5 && transform.position.y <= -2.5)
        //{
        //    return;
        //}
        else
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
    }




    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Check if the collided object has the required tags
    //    if (collision.gameObject.CompareTag("Ground Level 3"))
    //    {
    //        Debug.Log(collision.transform.position.x);
    //    }
    //    else if(collision.gameObject.CompareTag("Ground Level 2")){
    //        Debug.Log(collision.transform.position.x);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }




}
