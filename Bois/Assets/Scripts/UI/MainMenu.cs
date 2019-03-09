using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pausing of the game.
public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MainMenuUI;
    private void Start()
    {
        MainMenuUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        MainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    
    }

    public void Pause()
    {
        MainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void QuitGame(string scene)
    {
        if(GameIsPaused == true)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
