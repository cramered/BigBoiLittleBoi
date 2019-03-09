using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Source: https://www.youtube.com/watch?v=aLpixrPvlB8
// This controls the camera movement. Follows along one/two players.
public class CameraController : MonoBehaviour
{

    [SerializeField] List<Transform> players;

    [SerializeField] Vector3 offset;

    [SerializeField] Transform minCameraY;
    [SerializeField] Transform maxCameraY;

    [SerializeField] Transform minCameraX;
    [SerializeField] Transform maxCameraX;

    private Camera cam;
    private Scene currentScene;
    [SerializeField] float fixationYPoint = 3;


    private void Start()
    {
        cam = GetComponent<Camera>();
        currentScene = SceneManager.GetActiveScene();
    }


    private void LateUpdate()
    {
        Vector3 center = GetCenter();
        Vector3 newPosition = center + offset;

        if (newPosition.y < minCameraY.position.y + cam.orthographicSize)
        {
            newPosition.y = minCameraY.position.y + cam.orthographicSize;
        }

        if (newPosition.y > cam.orthographicSize - maxCameraY.position.y)
        {
            newPosition.y = cam.orthographicSize - maxCameraY.position.y;
        }

        // A note on this: This is not a great workaround. For some reason, the Y bounds
        // were not working for Level 3, so we decided to fix the y point.....
        //this is a bug that, had we had more time could've been worked out.
        if (currentScene.name == "Level 3")
        {
            newPosition.y = fixationYPoint;
        }

        float halfWidth = cam.orthographicSize * cam.aspect;

        if (newPosition.x < minCameraX.position.x + halfWidth)
        {
            newPosition.x = minCameraX.position.x + halfWidth;
        }

        if (newPosition.x > maxCameraX.position.x - halfWidth)
        {
            newPosition.x = maxCameraX.position.x - halfWidth;
        }

        transform.position = new Vector3(newPosition.x, newPosition.y, -10);
    }

    private Vector3 GetCenter()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 0; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }
        return bounds.center;
    }
}