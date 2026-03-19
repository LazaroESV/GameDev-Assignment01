using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject snowball;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("ShootBall", 0f, 20f);
    }

    void ShootBall()
    {
        Instantiate(snowball, firePoint.position, Quaternion.identity);
    }
}
