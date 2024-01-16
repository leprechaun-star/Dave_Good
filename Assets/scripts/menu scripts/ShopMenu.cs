using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{

    public bool isshop;
    public GameObject ShopMenuCanvas;
    public GameObject PauseMenuClose;
    public GameObject PlayerHUD;

    void Start()
    {
        ShopMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(isshop)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }

    public void PauseGame()
    {
        ShopMenuCanvas.SetActive(true);
        isshop = true;
        PlayerHUD.SetActive(false);
        PauseMenuClose.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        ShopMenuCanvas.SetActive(false);
        PlayerHUD.SetActive(true);
        PauseMenuClose.SetActive(false);
        isshop = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
