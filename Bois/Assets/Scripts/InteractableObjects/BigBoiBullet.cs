// From Benno Luders Projectile.cs

using UnityEngine;
using System.Collections;
public class BigBoiBullet : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float lifeTime = 3;
    [SerializeField] Vector2 direction;

    void Start()
    {
        GameObject gun = GameObject.FindGameObjectsWithTag("BigBoiGun")[0];
        Transform gunLocation = gun.GetComponent<Transform>();
        if (gunLocation.position.x > transform.position.x)
        {
            direction = new Vector2(-1, 0);
        }
        else 
        { 
            direction = new Vector2(1, 0); 
        }
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DummyEnemy"))
        {
            Destroy(col.gameObject);
        }

        Destroy(gameObject);
    }

}
