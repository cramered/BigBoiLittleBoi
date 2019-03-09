using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scrolling for title screen.
public class TitleScreenCamController : MonoBehaviour
{
    [SerializeField] GameObject firstBackground;
    [SerializeField] GameObject lastBackground;
    void Update()
    {
        if (transform.position.x > lastBackground.transform.position.x)
        {
            transform.position = new Vector3(firstBackground.transform.position.x, transform.position.y, transform.position.z);
        }
        Vector3 pos = transform.position;
        pos.x += 0.01f;
        transform.position = pos;
        
    }
}
