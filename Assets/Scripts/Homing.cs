using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;


    public float speed = 9f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Use the player's position to know to shoot left or right
        float directionX = Mathf.Sign(player.position.x - transform.position.x);

        // Add random variation
        Vector2 direction = new Vector2(
            directionX + Random.Range(-0.3f, 0.3f), 
            Random.Range(-0.75f, 0f)               
        ).normalized;

        rb.linearVelocity = direction * speed;

        Destroy(this.gameObject, 10f); // destroy the snowball after 10 seconds
    }

}
