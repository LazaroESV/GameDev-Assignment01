using UnityEngine;
using UnityEngine.SceneManagement;

public class Popping : MonoBehaviour
{
    private ManageBalloon balloonManager;
    private ManageScore scoreManager;
    private BoxCollider2D wallZone;

    [SerializeField]
    private bool isBlackBalloon = false;

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
            if (isBlackBalloon)
            {
                AudioManager.Instance.PlayBlackCollectSFX();
                scoreManager.SubtractScore(3);
            }
            else
            {
                AudioManager.Instance.PlayYellowCollectSFX();
                scoreManager.AddScore();
            }

            balloonManager.StartCoroutine(balloonManager.RespawnBalloon(wallZone));

            Destroy(gameObject); 
        }
    }
}
