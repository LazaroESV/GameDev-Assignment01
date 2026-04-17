using UnityEngine;
using UnityEngine.UI;

public class ManagePause : MonoBehaviour
{
    [SerializeField]
    public GameObject pausePanel;
    [SerializeField]
    public GameObject resumeButton;

    // vate bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        //isPaused = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        //isPaused = false;

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
