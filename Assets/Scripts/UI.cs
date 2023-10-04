using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    #region VARIABLES

    public static UI ui;
    public ScoreManager scoreManager;

    #endregion

    void Awake()
    {
        ui = this;
    }

    #region CONTROL DE ESCENAS
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        // Reset Time.timeScale to 1 before loading the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    #endregion

    public void ExitGame()
    {
#if UNITY_EDITOR
        print("Exit");
#endif
        Application.Quit();
    }
}
