using UnityEngine;

public class Popping : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // The balloon "pops"
            Destroy(gameObject); 
        }
    }
}
