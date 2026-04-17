using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public ManageScore scoreManager;

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.x = player.position.x;
        data.y = player.position.y;
        data.z = player.position.z;

        data.score = scoreManager.GetScore();

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

    // Just in case it is needed in the future
    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            Debug.Log("No saved game found");
            return;
        }

        string json = PlayerPrefs.GetString("SaveData");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        SceneManager.LoadScene("Adventure of Snowman 2d");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}