using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Opening of chest, and movement into
// next level.
public class Chest : MonoBehaviour
{
    public Key correctKey;
    public string nextScene = "";
    public GameObject openChest;
    private SpriteRenderer sr;
    [SerializeField] float movementUp = 0.2f;
    [SerializeField] float movementleft = 0.02f;
    [SerializeField] int nextLevelDelay = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BigBoi") || collision.gameObject.CompareTag("LittleBoi"))
        {
            if (correctKey.keyFound == true)
            {
                StartCoroutine(NextLevel());
            }
        }
    }

    private IEnumerator NextLevel()
    {

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(openChest, transform.position + new Vector3(-1 * movementleft, movementUp, 0), Quaternion.identity);
        yield return new WaitForSeconds(nextLevelDelay);

        SceneManager.LoadScene(nextScene);
    }

}