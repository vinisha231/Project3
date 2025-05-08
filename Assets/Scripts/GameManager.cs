using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject instructionsPanel;
    private bool gameStarted = false;

    void Start()
    {
    Time.timeScale = 0f; // freeze everything at first
    instructionsPanel.SetActive(true); // show instructions
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER triggered!");

        // Slow down time
        Time.timeScale = 0.2f;

        // After 1 second in slo-mo, show Game Over UI
        Invoke(nameof(ShowGameOverUI), 1f);
    }

    void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;  // full pause
    }

    public void Win()
    {
        Debug.Log("YOU WIN triggered!");

        // Slow down time
        Time.timeScale = 0.2f;

        // After 1 second in slo-mo, show Win UI
        Invoke(nameof(ShowWinUI), 1f);
    }

    void ShowWinUI()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;  // full pause
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reset timescale before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
{
    if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f;
        gameStarted = true;
    }

    if (gameStarted && Input.GetKeyDown(KeyCode.R))
    {
        Restart();
    }
}
}