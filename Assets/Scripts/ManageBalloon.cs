using System.Collections;
using UnityEngine;

public class ManageBalloon : MonoBehaviour
{
    [SerializeField]
    private GameObject balloonPrefab;

    [SerializeField]
    private BoxCollider2D[] walls;

    [SerializeField]
    private ManageScore scoreManager;

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

        GameObject balloon = Instantiate(balloonPrefab, randomPos, Quaternion.Euler(0, 180, 0));

        balloon.GetComponent<Popping>().Initialize(this, scoreManager, wall);
    }

    public IEnumerator RespawnBalloon(BoxCollider2D wall)
    {
        yield return new WaitForSeconds(2f);
        SpawnBalloon(wall);
    }
}
