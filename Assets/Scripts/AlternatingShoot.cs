using UnityEngine;
using System.Collections;

public class AlternatingShoot : MonoBehaviour
{
    public Shoot[] guns;
    private int currentGun = 0;

    void Start()
    {
        StartCoroutine(SwitchGuns());
    }

    IEnumerator SwitchGuns()
    {
        while (true)
        {
            guns[currentGun].ShootBall();
            Debug.Log("Shoot");

            yield return new WaitForSeconds(Random.Range(5, 20));

            currentGun = (currentGun + Random.Range(1, 4)) % guns.Length;
        }
    }
}
