using UnityEngine;

// Key functionality -- chest can only be opened
// when Key is found.
public class Key : MonoBehaviour
{
    public bool keyFound = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BigBoi") || collision.gameObject.CompareTag("LittleBoi"))
        {
            keyFound = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
