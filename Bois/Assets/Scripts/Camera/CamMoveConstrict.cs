using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Restricts camera movement so that each player
// is on screen.
public class CamMoveConstrict : MonoBehaviour
{
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;
    private Camera cam;
    private float height;
    private float width;
    void Start()
    {
        cam = GetComponent<Camera>();
        // Source: https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        float differenceInX = player1.position.x - player2.position.x;
        var distanceInX = Mathf.Abs(differenceInX);
        if (distanceInX> width)
        {
            if (player1.position.x > player2.position.x) // i.e. player1 in front
            {
                float x = transform.position.x + (width / 2);
                player1.position = new Vector2(x, player1.position.y);
                float x2 = transform.position.x - (width / 2);
                player2.position = new Vector2(x2, player2.position.y);
            }

            else // i.e. player2 in front
            {
                float x = transform.position.x + (width / 2);
                player2.position = new Vector2(x, player2.position.y);
                float x2 = transform.position.x - (width / 2);
                player1.position = new Vector2(x2, player1.position.y);
            }
        }
    }
}
