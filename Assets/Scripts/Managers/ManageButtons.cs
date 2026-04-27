using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField]
    private GameObject displayPanel;

    private void Start()
    {
        displayPanel.SetActive(false);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("SaveData");

        string playerName = nameInput.text;

        // fallback
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player"; 
        }

        PlayerPrefs.SetString("PlayerName", playerName);

        SceneManager.LoadScene("Adventure of Snowman 2d");
    }

    public void ResumeGame()
    {
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            Debug.Log("No save found");
            return;
        }

        SceneManager.LoadScene("Adventure of Snowman 2d");
    }

    public void ShowDisplay()
    {
        displayPanel.SetActive(true);
    }

    public void HideDisplay()
    {
        displayPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}