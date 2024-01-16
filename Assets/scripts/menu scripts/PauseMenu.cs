using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Main Stuff")]
    [SerializeField] public bool ispause;
    [SerializeField] public bool IsShop;
    [SerializeField] public GameObject PauseMenuCanvas;
    [SerializeField] public GameObject PausedOptionMenu;
    [SerializeField] public GameObject ShopMenuCanvas;
    [SerializeField] public GameObject PlayerHUD;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject DavePistol;
    [SerializeField] public GameObject Tur = null;

    [SerializeField] public PlayerMoevementActions UIControl;
    [SerializeField] private InputAction Pause;
    [SerializeField] private InputAction GameUI;

    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        ShopMenuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Awake()
    {
        UIControl = new PlayerMoevementActions();
    }

    private void OnEnable()
    {
        Pause = UIControl.Player.PauseMenu;
        GameUI = UIControl.Player.TabbedMenu;
        Pause.Enable();
        GameUI.Enable();
    }

    private void OnDisable()
    {
        Pause.Disable();
        GameUI.Disable();
    }

    void Update()
    {
        if (Pause.WasPressedThisFrame())
        {
            if(ispause)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Player.GetComponent<Player>().enabled= true;
                DavePistol.GetComponent<DavePistol>().enabled= true;
                Cursor.visible = false;
                if(IsShop)
                {
                    ShopMenuCanvas.SetActive(false);
                }
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Player.GetComponent<Player>().enabled = false;
                DavePistol.GetComponent<DavePistol>().enabled = false;
                Cursor.visible = true;
            }
        }

            if (GameUI.WasPressedThisFrame())
            {
                if (IsShop)
                {
                    UnShoped();
                    Cursor.lockState = CursorLockMode.Locked;
                    Player.GetComponent<Player>().enabled = true;
                    DavePistol.GetComponent<DavePistol>().enabled = true;
                    Cursor.visible = false;
                    if (ispause)
                    {
                        PauseMenuCanvas.SetActive(false);
                    }
                }
                else
                {
                    Shoped();
                    Cursor.lockState = CursorLockMode.Confined;
                    Player.GetComponent<Player>().enabled = false;
                    DavePistol.GetComponent<DavePistol>().enabled = false;
                    Cursor.visible = true;
                }
            }
    }

    public void PauseGame()
    {
        PauseMenuCanvas.SetActive(true);
        PlayerHUD.SetActive(false);
        ShopMenuCanvas.SetActive(false);
        ispause = true;
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<Player>().enabled = false;
        DavePistol.GetComponent<DavePistol>().enabled = false;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        PausedOptionMenu.SetActive(false);
        PlayerHUD.SetActive(true);
        ShopMenuCanvas.SetActive(false);
        ispause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<Player>().enabled = true;
        DavePistol.GetComponent<DavePistol>().enabled = true;
        Cursor.visible = false;
    }

    public void Shoped()
    {
        PlayerHUD.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        PausedOptionMenu.SetActive(false);
        ShopMenuCanvas.SetActive(true);
        IsShop = true;
        Cursor.lockState = CursorLockMode.Confined;
        Player.GetComponent<Player>().enabled = false;
        DavePistol.GetComponent<DavePistol>().enabled = false;
        Cursor.visible = true;
    }
    public void UnShoped()
    {
        PlayerHUD.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        PausedOptionMenu.SetActive(false);
        ShopMenuCanvas.SetActive(false);
        IsShop = false;
        Cursor.lockState = CursorLockMode.Confined;
        Player.GetComponent<Player>().enabled = true;
        DavePistol.GetComponent<DavePistol>().enabled = true;
        Cursor.visible = false;
    }
}
