using System.Collections;
using UnityEngine;

public class ManageBalloon : MonoBehaviour
{
    [SerializeField]
    private GameObject balloonPrefab;

    [SerializeField]
    private GameObject blackBalloonPrefab;

    [SerializeField]
    private BoxCollider2D[] walls;

    [SerializeField]
    private ManageScore scoreManager;

    [SerializeField]
    [Range(0f, 1f)]
    private float blackBalloonChance = 0.25f;

    private int balloonSpawnCount = 0;


    void Start()
    {
        foreach (BoxCollider2D wall in walls)
        {
            SpawnBalloon(wall);
        }
    }

    public void SpawnBalloon(BoxCollider2D wall)
    {
        Bounds bounds = wall.bounds;

        Vector3 randomPos = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0f
        );

        GameObject balloonToSpawn;

        if (balloonSpawnCount >= 6)
        {
            balloonToSpawn = blackBalloonPrefab;
            balloonSpawnCount = 0;
        }
        else
        {
            bool spawnBlack = Random.value < blackBalloonChance;

            if (spawnBlack)
            {
                balloonToSpawn = blackBalloonPrefab;
                balloonSpawnCount = 0;
            }
            else
            {
                balloonToSpawn = balloonPrefab;
                balloonSpawnCount++;
            }
        }


        GameObject balloon = Instantiate(balloonToSpawn, randomPos, Quaternion.Euler(0, 180, 0));

        balloon.GetComponent<Popping>().Initialize(this, scoreManager, wall);
    }

    public IEnumerator RespawnBalloon(BoxCollider2D wall)
    {
        yield return new WaitForSeconds(2f);
        SpawnBalloon(wall);
    }
}
