using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls bullets shooting from crossbow.
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] Vector2 direction = new Vector2(-1, 0);

    void Start()
    {
        direction.Normalize();
    }
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BigBoi"))
        {
            other.gameObject.GetComponent<LargeGuyController>().Hit();
        }
        if (other.gameObject.CompareTag("LittleBoi"))
        {
            other.gameObject.GetComponent<SmallGuyController>().Hit();
        }
        Destroy(gameObject);
    }

    IEnumerator KillAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
