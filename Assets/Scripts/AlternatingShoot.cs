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

            yield return new WaitForSeconds(20f);

            currentGun = (currentGun + 1) % guns.Length;
        }
    }
}
