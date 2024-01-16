using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [Header("Death Stuff")]
    [SerializeField] public GameObject DeathScreen;
    [Space]
    [Header("Disabling")]
    [SerializeField] public GameObject UiManager;
    [SerializeField] public GameObject HudManager;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Pistol;

    void Update()
    {
        if (Player.GetComponent<Player>().curHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DeathScreen.SetActive(true);
        Player.GetComponent<Player>().enabled = false;
        UiManager.GetComponent<PauseMenu>().enabled = false;
        UiManager.GetComponent<MainMenu>().enabled = false;
        Pistol.GetComponent<DavePistol>().enabled = false;
        HudManager.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
