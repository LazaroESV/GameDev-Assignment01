using UnityEngine;
using TMPro;

public class ManageDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    void Start()
    {
        string json = PlayerPrefs.GetString("HighScores", "");

        if (string.IsNullOrEmpty(json))
        {
            scoreText.text = "No scores yet :(";
            return;
        }

        ScoreList list = JsonUtility.FromJson<ScoreList>(json);

        scoreText.text = "";

        foreach (ScoreEntry entry in list.scores)
        {
            scoreText.text += entry.playerName + " - " + entry.score + "\n";
        }

    }
}
