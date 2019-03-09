using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bigBoi's gun, shooting, and audio
public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bigBoiBulletPrefab;
    [SerializeField] AudioClip gunNoise;
    [SerializeField] float cooldown = 1;
    private bool canShoot = true;

    public Transform pointOfFire;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(nextShot(cooldown));
            BigBoiFire();
        }
    }

    private void BigBoiFire()
    {
        // Strange bug where clip plays on bigBoiTutorial.
        AudioSource.PlayClipAtPoint(gunNoise, transform.position);
        Instantiate(bigBoiBulletPrefab, new Vector3(pointOfFire.position.x, pointOfFire.position.y, 10), Quaternion.identity);
    }

    IEnumerator nextShot(float coolDown)
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;

    }
}
