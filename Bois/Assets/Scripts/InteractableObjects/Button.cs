using UnityEngine;

// Makes littleBoi buttons pushable.
public class Button : MonoBehaviour
{
    [SerializeField] GameObject actionedItem;
    [SerializeField] bool block;

    [SerializeField]
    private GameObject blocker;

    [SerializeField]
    private GameObject parentBlocker;

    private Vector3 blockerPosition;
    private Vector3 blockerPosition2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LittleBoi"))
        {
            if (actionedItem.CompareTag("Wall"))
            {
                Destroy(gameObject);
                Destroy(actionedItem);
            }
            else
            {
                Destroy(gameObject);
                actionedItem.GetComponent<BulletSpawn>().enabled = !actionedItem.GetComponent<BulletSpawn>().enabled;
            }

            if (block)
            {
                blockerPosition = parentBlocker.transform.position - new Vector3(0, 1, 0);
                blockerPosition2 = parentBlocker.transform.position - new Vector3(1, 1, 0);
                Instantiate(blocker, blockerPosition, Quaternion.identity);
                Instantiate(blocker, blockerPosition2, Quaternion.identity);
            }
        }
    }
}
