using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quittt");
    }
}
