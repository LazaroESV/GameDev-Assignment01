using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Transform player;

    public ManageScore scoreManager;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SaveData")) return;

        string json = PlayerPrefs.GetString("SaveData");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        player.position = new Vector3(data.x, data.y, data.z);

        scoreManager.SetScore(data.score);
    }
}