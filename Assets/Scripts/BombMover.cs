﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMover : MonoBehaviour
{
    /*
     * khai báo biến tốc độ là một số thực có giá trị bằng 5.
     * Public sẽ cho phép ta truy cập giá trị speed từ UnityEditor
     */
    public float speed = 5f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left); //tạo chuyển động theo phương thẳng đứng hướng xuống với tốc độ trên theo thời gian
    }
    void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
    {
        // thiết lập điều kiện kiểm tra thông tin của OTHER
        if (other.gameObject.CompareTag("Player"))
        // nếu, phương thức so sánh gameobject tag của other với nhãn "Player" là đúng
        { // thì
            ScoreManager.AddScore(-1);
            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa người chơi đang va chạm
        }
        else if (other.gameObject.CompareTag("Ground")) // còn không thì, nếu là mặt đất,
        { // thì
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa mặt đất
        }
    }
}
