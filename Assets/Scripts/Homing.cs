using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;

    public float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(this.gameObject, 10f); // destroy the snowball after 10 seconds
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;

        
        rb.linearVelocity = direction * speed;
    }


}
