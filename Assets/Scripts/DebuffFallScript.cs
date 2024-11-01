using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffFallScript : MonoBehaviour
{
    // Khai báo biến để chứa prefab của viên ngọc. Đây sẽ là đối tượng mà chúng ta sẽ tạo ra trong trò chơi.
    public GameObject bombPrefab;
    public GameObject cupPrefab;
    private GameObject[] badPrefabs;
    // Biến đếm thời gian kể từ lần sinh viên ngọc cuối cùng.
    public float timer;
    // Khoảng thời gian (tính bằng giây) giữa mỗi lần sinh viên ngọc mới.
    public float spawnInterval = 3f; //tần suất spawn: 3 giây / 1 gem
    void Start()
    {
        badPrefabs = new GameObject[] { bombPrefab, cupPrefab };
    }
    void Update()
    {
        // Cộng dồn thời gian từ lần cuối cập nhật đến bây giờ vào biến timer.
        timer += Time.deltaTime;
        // Kiểm tra nếu thời gian đã đủ lớn bằng hoặc lớn hơn khoảng thời gian sinh viên ngọc.
        if (timer >= spawnInterval)
        {
            SpawnGem(); // Gọi hàm sinh viên ngọc.
            timer = 0; // Đặt lại biến đếm thời gian.
        }
    }

    void SpawnGem()
    {
        /* Khai báo và tạo một biến có giá trị ngẫu nhiên trong khoảng màn hình trước khi tạo gem mới. 
        * Biến này đóng vai trò là tọa độ X (ngang) mới.
        */
        float randomY = Random.Range(-3f, 3f); //Màn hình rộng 16 point nên lề trái là -8 và biên phải là 8
                                               //Khai báo một biến tọa độ vị trí và lưu giá trị tọa độ trên
        Vector3 spawnPosition = new(7.8f, randomY, 0); // Đưa biến số này vào Vector3, để tạo tọa độ vị trí mới

        int randomIndex = Random.Range(0, badPrefabs.Length);
        GameObject randomPrefab = badPrefabs[randomIndex];


        //Đưa tọa độ này vào function (hàm) Instantiate để tạo và thả viên gem mới
        Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
    }
}
