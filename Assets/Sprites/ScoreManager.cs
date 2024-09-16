using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // tạo một biến số điểm bắt đầu bằng 0 để lưu giá trị điểm của người chơi
    public static int score = 0; //static sẽ được giải thích sau trong chương c#
    public TextMeshProUGUI scoreText; // tạo một biến thuộc kiểu TextMeshProUGUI tên scoreText và có thể truy cập từ Unity Editor

    private float remainingTime;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    private void GameOver()
    {
        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // khai báo một hàm dành cho lớp ScoreManager nhằm tăng số điểm của người chơi
    public static void AddScore(int amount) //(int amount) nghĩa là hàm sẽ chỉ nhận giá trị là integer, và giá trị này sẽ được gán vào biến có tên amount
    {
        score += amount; //tăng điểm theo giá trị của amount được truyền vào tại sự kiện gọi AddScore
    }

    void Start() // đếm giờ khi trò chơi bắt đầu
    {
        remainingTime = 30f; //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }

    void Update()
    {
        scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime); //Mathf.CeilToInt(remainingTime) làm tròn số nguyên dương
        if (remainingTime <= 0)
        {
            GameOver();
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
    }
}
