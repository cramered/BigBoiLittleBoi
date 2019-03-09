using UnityEngine;

// bigBoi can step on pressure plates.
public class PressurePlate : MonoBehaviour
{
    [SerializeField] float pushed = 0.3f;
    [SerializeField] GameObject wall;
    private bool IsPushed = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsPushed)
        {
            if (collision.gameObject.CompareTag("BigBoi"))
            {
                IsPushed = true;
                transform.position += new Vector3(0, -1, 0) * pushed;
                Destroy(wall);
            }
        }
    }
}
