using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // Replace "GameScene" with the actual game scene name
    }

    public void RetryGame()
    {
        Time.timeScale = 1.0f;
        ScoreManager.ResetStat();
        CharacterMovement.ResetSpeed();
        SceneManager.LoadScene("MainScene");

    }

    public void ToMainMenuGame()
    {
        Time.timeScale = 1.0f;
        ScoreManager.ResetStat();
        SceneManager.LoadScene("StartMenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Only needed for testing in the editor
        #endif
    }
}
