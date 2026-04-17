using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject snowball;
    public Transform firePoint;

    public void ShootBall()
    {
        Instantiate(snowball, firePoint.position, Quaternion.identity);
    }
}
