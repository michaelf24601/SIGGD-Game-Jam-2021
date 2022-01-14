using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static bool GAME_IS_OVER = false;
    public static bool GAME_START = false;

    public static int GAME_WIDTH = 12;
    public static int GAME_HEIGHT = 16;

    public GameObject gameOverUI;
    public GameObject levelChanger;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over!");

    }

    public void Restart()
    {
        Debug.Log("Restart the game!");
        Time.timeScale = 1f;
        GAME_START = false;
        GAME_IS_OVER = false;
        SceneManager.LoadScene(1); //load the game scene
    }

    public void Quit()
    {
        Debug.Log("Quit the game!");
        //load main menu scene once it is created 
    }
}
