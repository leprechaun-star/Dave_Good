using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Changedscene(string sceneName)
    {
       LevelManager.Instance.LoadScene(sceneName);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
        Time.timeScale = 1f;
        Debug.Log("PLAYING!!!!!");
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("GOING BACK!!!!");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUITED!!");
    }
}
