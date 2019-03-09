using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes speed of crossbow bullets.
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] float spawnRate = 1;
    [SerializeField] GameObject BulletPrefab;

    private float lastSpawnTime = 0;

    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            GameObject curBullet = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);
            curBullet.transform.Rotate(0, 0, 180);
        }
    }
}
