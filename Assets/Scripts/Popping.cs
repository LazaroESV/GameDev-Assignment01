using UnityEngine;
using UnityEngine.SceneManagement;

public class Popping : MonoBehaviour
{
    private ManageBalloon balloonManager;
    private ManageScore scoreManager;
    private BoxCollider2D wallZone;

    public void Initialize(ManageBalloon bm, ManageScore sm, BoxCollider2D zone)
    {
        balloonManager = bm;
        scoreManager = sm;
        wallZone = zone;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.AddScore();

            balloonManager.StartCoroutine(balloonManager.RespawnBalloon(wallZone));

            Destroy(gameObject); 
        }
    }
}
