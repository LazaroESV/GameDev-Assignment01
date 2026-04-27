using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] public Transform player;
    [SerializeField] public Vector3 offset = new Vector3(0, 0, -10);


    void Update()
    {
        Vector3 newPosition = player.position + offset;


        transform.position = newPosition;
    }
}
