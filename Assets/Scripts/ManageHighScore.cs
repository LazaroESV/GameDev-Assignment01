using UnityEngine;

public class ManageHighScore : MonoBehaviour
{
    public ManageScore scoreManager;

    public void SaveHighScore()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        int score = scoreManager.GetScore();

        string json = PlayerPrefs.GetString("HighScores", "");
        ScoreList list;

        if (string.IsNullOrEmpty(json))
        {
            list = new ScoreList();
        }
        else
        {
            list = JsonUtility.FromJson<ScoreList>(json);
        }

        list.scores.Add(new ScoreEntry(playerName, score));

        // Sort descending (bonus points)
        list.scores.Sort((a, b) => b.score.CompareTo(a.score));

        // Keep only top 5 (not explicitly required)
        if (list.scores.Count > 5)
        {
            list.scores.RemoveRange(5, list.scores.Count - 5);
        }

        // Save back
        string newJson = JsonUtility.ToJson(list);
        PlayerPrefs.SetString("HighScores", newJson);
        PlayerPrefs.Save();
    }
}
