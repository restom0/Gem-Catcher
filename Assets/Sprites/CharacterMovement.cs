using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        if (isMoving) // nếu nhân vật đang di chuyển
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
