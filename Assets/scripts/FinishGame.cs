using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    [Header("Death Stuff")]
    [SerializeField] public GameObject WinningScreen;
    [SerializeField] public GameObject Game;
    [Space]
    [Header("Disabling")]
    [SerializeField] public GameObject UiManager;
    [SerializeField] public GameObject HudManager;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Barrierpannel;
    [SerializeField] public Button FinishButton;
    [Header("what score should the game end at")]
    [SerializeField] public int GetLevel;
    [SerializeField] public TMP_Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Game.GetComponent<GameManager>().Level >= GetLevel)
            {
                EndGame();
            }
        }
    }

    private void Update()
    {
        scoreText.text = Game.GetComponent<GameManager>().Level.ToString();

        if(Game.GetComponent<GameManager>().Level >= GetLevel)
        {
            Barrierpannel.SetActive(false);
            FinishButton.enabled = true;
        }
    }

    public void EndGame()
    {
        Debug.Log("Your a winner");
        WinningScreen.SetActive(true);
        HudManager.SetActive(false);
        Player.GetComponent<Player>().enabled = false;
        Player.GetComponent<Pistiol>().enabled = false;
        UiManager.GetComponent<PauseMenu>().enabled = false;
        UiManager.GetComponent<MainMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
