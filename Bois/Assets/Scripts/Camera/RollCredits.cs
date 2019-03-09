using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scrolling for credits.
public class RollCredits : MonoBehaviour
{
    [SerializeField] GameObject lastBackground;
    [SerializeField] GameObject firstBackground;

    void Update()
    {
        if (transform.position.y < lastBackground.transform.position.y)
        {
            SceneManager.LoadScene("Title Screen");

        }

        Vector3 pos = transform.position;
        pos.y -= 0.03f;
        transform.position = pos;
    }
}
