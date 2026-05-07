using UnityEngine;
using TMPro;

public class ManageScore : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    void Start()
    {
        AudioManager.Instance.PlayGameplayMusic();
        UpdateUI();
    }

    public void AddScore()
    {
        score++;
        UpdateUI();
    }

    public void SubtractScore(int value)
    {
        score -= value;
        UpdateUI();
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}