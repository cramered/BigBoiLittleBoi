using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pushes users to either tutorial or real game
public class TitleScreenButton : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}