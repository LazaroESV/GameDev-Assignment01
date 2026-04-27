using UnityEngine;
using UnityEngine.UI;

public class ManagePause : MonoBehaviour
{
    [SerializeField]
    public GameObject pausePanel;
    [SerializeField]
    public GameObject resumeButton;
    [SerializeField]
    private SaveSystem saveSystem;

    void Start()
    {
        pausePanel.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);

        saveSystem.SaveGame();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        resumeButton.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

}
